using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.CartDTO;
using CofeeStoreManagement.Models.DTO.OrderDTO;
using CofeeStoreManagement.Models.DTO.StoreDTO;
using CofeeStoreManagement.Repositories;
using Microsoft.Identity.Client;
using System.Text.Json;

namespace CofeeStoreManagement.services
{
    public class StoreService : IStoreService
    {
        private readonly IRepository<int, Store> _storeRepository;
        private readonly IRepository<int, Product> _productRepository;
        private readonly IRepository<int, ProductOptionValue> _productOptionValueRepository;
        private readonly IRepository<int, ProductOption> _productOptionRepository;
        private readonly IRepository<int, OrderItem> _orderItemRepository;
        private readonly IRepository<int, User> _userRepository;
        private readonly IRepository<int, Order> _orderRepository;
        public StoreService(IRepository<int, Store> storeRepository,
            IRepository<int, Product> productRepository,
            IRepository<int, ProductOptionValue> productOptionValueRepository,
            IRepository<int, ProductOption> productOptionRepository,
            IRepository<int, OrderItem> orderItemRepository,
            IRepository<int, User> userRepository,
            IRepository<int, Order> orderReopsitory
            )
        {
            _storeRepository = storeRepository;
            _productRepository = productRepository;
            _productOptionValueRepository = productOptionValueRepository;
            _productOptionRepository = productOptionRepository;
            _orderItemRepository = orderItemRepository;
            _userRepository = userRepository;
            _orderRepository = orderReopsitory;
        }

        public async Task<bool> IsValidOrder(int orderId)
        {
            try
            {
                await _orderRepository.GetOneById(orderId);
                return true;

            }
            catch (EntityNotFoundException)
            {
                throw new OrderNotFoundException();

            }
        }
        
        public async Task<ModifyOrderReturnDTO> AcceptOrder(int orderid, int storeId)
        {
            try
            {
                await IsValidOrder(orderid);
                var order = await _orderRepository.GetOneById(orderid);
                if (order.StoreId != storeId)
                {
                    throw new OrderNotFoundException();
                }
                order.Status = "Accepted";
                await _orderRepository.Update(order);
                return new ModifyOrderReturnDTO
                {
                    UserId = order.UserId,
                    StoreId = order.StoreId,
                    TotalAmount = order.TotalAmount,
                    UpdatedStatus = order.Status
                };
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<ModifyOrderReturnDTO> DeclineOrder(int OrderId, int storeId)
        {
            try
            {
                await IsValidOrder(OrderId);
                var order = await _orderRepository.GetOneById(OrderId);
                if (order.StoreId != storeId)
                {
                    throw new OrderNotFoundException();
                }
                order.Status = "Declined";
                order = await _orderRepository.Update(order);
                return new ModifyOrderReturnDTO
                {
                    UserId = order.UserId,
                    StoreId = order.StoreId,
                    TotalAmount = order.TotalAmount,
                    UpdatedStatus = order.Status
                };
            }
            catch
            {
                throw;
            }
        }

        private async Task<OrderReturnDto> CreateOrderDto(Order order)
        {
            var user = await _userRepository.GetOneById(order.UserId);

            var orderDto = new OrderReturnDto
            {
                OrderId = order.OrderId,
                Username = user.Name,
                OrderAmount = order.TotalAmount,
                Status = order.Status,
                orderItems = await GetOrderItems(order.OrderId)
            };

            return orderDto;
        }

        private async Task<List<OrderItemDto>> GetOrderItems(int orderId)
        {
            var orderItems = await _orderItemRepository.Get();
            var orderItemDtos = new List<OrderItemDto>();

            foreach (var orderItem in orderItems.Where(oi => oi.OrderId == orderId))
            {
                var orderItemDto = await CreateOrderItemDto(orderItem);
                orderItemDtos.Add(orderItemDto);
            }

            return orderItemDtos;
        }

        private async Task<OrderItemDto> CreateOrderItemDto(OrderItem orderItem)
        {
            var product = await _productRepository.GetOneById(orderItem.ProductId);

            var orderItemDto = new OrderItemDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Calories = product.Calories,
                Quantity = orderItem.Quantity,
                ImageUrl = product.ImageUri,
                SelectedOptions = await GetSelectedOptions(orderItem.SelectedOptions)
            };

            return orderItemDto;
        }

        private async Task<List<OrderItemOptionDto>> GetSelectedOptions(string selectedOptionsJson)
        {
            var selectedOptionIds = JsonSerializer.Deserialize<List<int>>(selectedOptionsJson);
            var selectedOptions = new List<OrderItemOptionDto>();

            foreach (var optionId in selectedOptionIds)
            {
                var optionValue = await _productOptionValueRepository.GetOneById(optionId);
                var option = await _productOptionRepository.GetOneById(optionValue.OptionId);

                var orderItemOptionDto = new OrderItemOptionDto
                {
                    OptionId = optionValue.OptionId,
                    OptionName = $"{option.Name} ({optionValue.Value})",
                    OptionCost = optionValue.AdditionalCost
                };

                selectedOptions.Add(orderItemOptionDto);
            }

            return selectedOptions;
        }

        public async Task<IEnumerable<OrderReturnDto>> GetStoreOrders(int storeId)
        {
            var userOrders = await ((OrderRepository)_orderRepository).GetAllValidOrdersByStore(storeId);

            var orderDtos = new List<OrderReturnDto>();

            foreach (var order in userOrders)
            {
                var orderDto = await CreateOrderDto(order);
                orderDtos.Add(orderDto);
            }

            return orderDtos;
        }

        public async Task<IEnumerable<OrderReturnDto>> GetUserOrders(int userId, int storeId)
        {
            var userOrders = await ((OrderRepository)_orderRepository).GetAllValidOrdersByUser(userId, storeId);
            var orderDtos = new List<OrderReturnDto>();

            foreach (var order in userOrders)
            {
                var orderDto = await CreateOrderDto(order);
                orderDtos.Add(orderDto);
            }
            return orderDtos;
        }

        public async Task<IEnumerable<ReturnStoreinfoDto>> GetStoresByCity(string city)
        {
            try
            {
                var stores = await _storeRepository.Get();
                var store = stores.Where(x => x.City == city);
                IEnumerable<ReturnStoreinfoDto> storeDtos = store.Select(x => new ReturnStoreinfoDto
                {
                    StoreId = x.StoreId,
                    Address = x.Address,
                    City = x.City,
                    Email = x.Email,
                    Phone = x.PhoneNumber,
                });
                return storeDtos;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ModifyOrderReturnDTO> MakeOrderReady(int ordreId, int storeId)
        {
            try
            {
                await IsValidOrder(ordreId);
                var order = await _orderRepository.GetOneById(ordreId);
                if (order.StoreId != storeId) throw new ForbiddenStoreException();
                if (order.Status != "Accepted") throw new InvalidOrderStatusException();
                order.Status = "Ready";
                await _orderRepository.Update(order);
                return new ModifyOrderReturnDTO
                {
                    UserId = order.UserId,
                    StoreId = order.StoreId,
                    TotalAmount = order.TotalAmount,
                    UpdatedStatus = order.Status
                };
            }
            catch
            {
                throw;
            }
        }

    }
}
