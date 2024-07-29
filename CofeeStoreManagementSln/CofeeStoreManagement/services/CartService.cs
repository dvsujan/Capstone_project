using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.CartDTO;
using CofeeStoreManagement.Models.DTO.CheckoutDTO;
using CofeeStoreManagement.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Text.Json;

namespace CofeeStoreManagement.services
{
    public class CartService:ICartService
    {
        private readonly IRepository<int, Cart> _cartRepository;
        private readonly IRepository<int, CartItem> _cartItemRepository;
        private readonly IRepository<int, Product> _productRepository;
        private readonly IRepository<int, User> _userRepository;
        private readonly IRepository<int, ProductOption> _productOptionRepository;
        private readonly IRepository<int, ProductOptionValue> _productOptionValueRepository;
        private readonly IRepository<int, Order> _orderRepository;
        private readonly IRepository<int, Store> _storeRepository;
        private readonly IRepository<int, OrderItem> _orderItemRepository; 

        public CartService(
            IRepository<int, Cart> cartRepository,
            IRepository<int, CartItem> cartItemRepository,
            IRepository<int, Product> productRepository,
            IRepository<int, User> userRepository,
            IRepository<int, ProductOption> productOptionRepository,
            IRepository<int, ProductOptionValue> productOptionValueRepository,
            IRepository<int, Order> orderRepository,
            IRepository<int, Store> storeRepository,
            IRepository<int, OrderItem> orderItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productOptionRepository = productOptionRepository;
            _productOptionValueRepository = productOptionValueRepository;
            _orderRepository = orderRepository;
            _storeRepository = storeRepository;
            _orderItemRepository = orderItemRepository;
        }

        private async Task<bool> CheckIfValidUser(int userId)
        {
            try
            {
                await _userRepository.GetOneById(userId);
                return true;
            }
            catch (EntityNotFoundException)
            {
                throw new UserDoesNotExistException(); 
            }
            catch
            {
                throw; 
            } 
            
        }
         private async Task<bool> CheckIfValidProduct(int productId)
        {
            try
            {
                await _productRepository.GetOneById(productId);
                return true;
            }
            catch (EntityNotFoundException)
            {
                throw new ProductDoesNotExistException(); 
            }
            catch
            {
                throw; 
            } 
            
        }


        public async Task<bool> CheckIfValidStore(int storeId){
            try
            {   
                var store = await _storeRepository.GetOneById(storeId);  
                return true;
            }
            catch (EntityNotFoundException)
            {
                throw new StoreDoesNotExistException();
            }
            catch
            {
                throw; 
            }
        }

          

        public async Task<CartReturnDto> AddItemToCart(CartDto dto)
        {
            try
            {
                await CheckIfValidUser(dto.UserId);  
                await CheckIfValidProduct(dto.ProductId);

                var carts = await _cartRepository.Get();
                var cart = carts.FirstOrDefault(c => c.UserId == dto.UserId);

                if (cart == null)
                { 
                    throw new CartNotFoundException();
                }
                
                var cartItems = await _cartItemRepository.Get();
                var existingCartItem = cartItems.FirstOrDefault(ci => ci.CartId == cart.CartId && ci.ProductId == dto.ProductId && ci.SelectedOptions == JsonSerializer.Serialize(dto.Options));

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += dto.Quantity;
                    existingCartItem.UpdatedAt = DateTime.UtcNow;
                    await _cartItemRepository.Update(existingCartItem);
                    return new CartReturnDto
                    {
                        CartId = cart.CartId,
                        ProductId = cart.UserId,
                    };
                }
                else
                {
                    var cartItem = new CartItem
                    {
                        CartId = cart.CartId,
                        ProductId = dto.ProductId,
                        Quantity = dto.Quantity,
                        SelectedOptions = JsonSerializer.Serialize(dto.Options),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    await _cartItemRepository.Insert(cartItem);
                    return new CartReturnDto
                    {
                        CartId = cart.CartId,
                        ProductId = cart.UserId,
                    };
                }
            }
            catch
            {
                throw; 
            }
        }
        private async Task ClearCart(int userId)
        {
            try
            {
                var carts = await _cartRepository.Get();
                var cart = carts.FirstOrDefault(c => c.UserId == userId);

                if (cart != null)
                {
                    var cartItems = await _cartItemRepository.Get();
                    var itemsToDelete = cartItems.Where(ci => ci.CartId == cart.CartId).ToList();

                    foreach (var item in itemsToDelete)
                    {
                        await _cartItemRepository.Delete(item.CartItemId);
                    }
                }
            } 
            catch
            {
                throw; 
            }

            
        }


        public async Task<CheckoutReturnDto> Checkout(CheckoutDto dto)
        {
            try
            {
                await CheckIfValidUser(dto.UserId);
                await CheckIfValidStore(dto.StoreId); 
                
                var carts = await _cartRepository.Get(); 

                var cart = carts.FirstOrDefault(c => c.UserId == dto.UserId);  
                if(cart == null)
                {
                    throw new CartNotFoundException(); 
                }


                var order = new Order
                {
                    UserId = dto.UserId,
                    StoreId = dto.StoreId,
                    TotalAmount = 0,
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                var orderItems = new List<OrderItem>();
                var cartItems = await _cartItemRepository.Get();  

                decimal discount = 0;
                var userItems = cartItems.Where(ci => ci.CartId == cart.CartId).ToList();  
                if (userItems.Count == 0)
                {
                    throw new CartEmptyException(); 
                }

                foreach (var cartItem in userItems) 
                {
                    var product = await _productRepository.GetOneById(cartItem.ProductId);
                    
                    decimal itemPrice = product.StarCost * cartItem.Quantity; 
                    if (cartItem.Quantity >= 2)
                    {
                        discount = itemPrice * (decimal)0.1;
                        itemPrice = itemPrice*(decimal)0.9; 
                    }

                    order.TotalAmount += itemPrice;

                    var selectedOptionValueIds = JsonSerializer.Deserialize<List<int>>(cartItem.SelectedOptions);
                    var additionalCost = 0m;

                    foreach (var optionId in selectedOptionValueIds)
                    {
                        var optionValue = await _productOptionValueRepository.GetOneById(optionId);
                        additionalCost += optionValue.AdditionalCost;
                    }

                    order.TotalAmount += additionalCost * cartItem.Quantity;

                    var orderItem = new OrderItem
                    {
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        SelectedOptions = cartItem.SelectedOptions,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    orderItems.Add(orderItem);
                }

                var resOrder = await _orderRepository.Insert(order);

                foreach (var orderItem in orderItems)
                {
                    orderItem.OrderId = resOrder.OrderId;
                    await _orderItemRepository.Insert(orderItem);
                }
                
                await ClearCart(dto.UserId);

                return new CheckoutReturnDto
                {
                    FinalPrice = order.TotalAmount,
                    UserId = dto.UserId,
                     Discount = discount 
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<CartReturnDto> DeleteItemFromCart(int userId , int productId)
        {
            try
            {
                await CheckIfValidUser(userId); 
                var carts = await _cartRepository.Get();
                var cart = carts.FirstOrDefault(c => c.UserId == userId);
                if (cart == null)
                {
                    throw new EntityNotFoundException();
                }

                var cartItems = await _cartItemRepository.Get();
                var cartItem = cartItems.FirstOrDefault(ci => ci.CartId == cart.CartId && ci.ProductId == productId);
                if (cartItem == null)
                {
                    throw new EntityNotFoundException();
                }
                await _cartItemRepository.Delete(cartItem.CartItemId);

                var updatedCartItems = cartItems.Where(ci => ci.CartId == cart.CartId && ci.ProductId != productId);

                var products = await _productRepository.Get();

                var productOptions = await _productOptionRepository.Get();
                var productOptionValues = await _productOptionValueRepository.Get();
                
                return new CartReturnDto
                    {
                        CartId = cart.CartId,
                        ProductId = cartItem.ProductId,
                    };
            }
            catch
            {
                throw; 
            }
        }
        
        public async Task<IEnumerable<CartItemDto>> GetAllItemsInCart(int userId)
        {
            try
            {
                await CheckIfValidUser(userId); 
                var carts = await _cartRepository.Get();
                var cart = carts.FirstOrDefault(c => c.UserId == userId);
                if (cart == null)
                {
                    throw new CartNotFoundException(); 
                }

                var cartItems = await _cartItemRepository.Get();
                var cartItemsForUser = cartItems.Where(ci => ci.CartId == cart.CartId);

                var products = await _productRepository.Get();

                var productOptions = await _productOptionRepository.Get();
                var productOptionValues = await _productOptionValueRepository.Get();

                var cartItemDtos = cartItemsForUser.Select(ci =>
                {
                    var product = products.FirstOrDefault(p => p.ProductId == ci.ProductId);

                    var selectedOptionValueIds = JsonSerializer.Deserialize<List<int>>(ci.SelectedOptions);

                    var selectedOptionsDtos = selectedOptionValueIds?.Select(ovId =>
                    {
                        var optionValue = productOptionValues.FirstOrDefault(pov => pov.OptionValueId == ovId);
                        var option = productOptions.FirstOrDefault(po => po.OptionId == optionValue?.OptionId);

                        return new ProductOptionDto
                        {
                            OptionId = optionValue?.OptionValueId ?? 0,
                            OptionName = $"{option?.Name} ({optionValue?.Value})",
                            OptionCost = optionValue?.AdditionalCost ?? 0
                        };
                    }).ToList();

                    return new CartItemDto
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Description = product.Description,
                        Calories = product.Calories,
                        Cost = product.StarCost,
                        ImageUrl = product.ImageUri,
                        Quantity = ci.Quantity ,
                        SelectedOptions = selectedOptionsDtos
                    };
                }).ToList();

                return cartItemDtos;
            }
            catch
            {
                throw; 
            }
        }
    }
}
