
using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Repositories;
using CofeeStoreManagement.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CofeeStoreManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                 };
             });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            });
            #region database_connection
            builder.Services.AddDbContext<CofeeStoreManagementContext>(options =>
            {
                options.UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeFirst; TrustServerCertificate=True");
            });
            #endregion

            #region repos

            builder.Services.AddScoped<IRepository<int, User>, UserRepository>(); 
            builder.Services.AddScoped<IRepository<int, CartItem>, CartItemRepository>(); 
            builder.Services.AddScoped<IRepository<int, Cart>, CartRepository>(); 
            builder.Services.AddScoped<IRepository<int, Category>, CategoryRepository>(); 
            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>(); 
            builder.Services.AddScoped<IRepository<int, OrderItem>, OrderItemRepository>(); 
            builder.Services.AddScoped<IRepository<int, Order>, OrderRepository>(); 
            builder.Services.AddScoped<IRepository<int, ProductCategory>, ProductCategoryRepository>(); 
            builder.Services.AddScoped<IRepository<int, ProductOptionCategory>, ProductOptionCategoryRepository>(); 
            builder.Services.AddScoped<IRepository<int, ProductOption>, ProductOptionRepository>(); 
            builder.Services.AddScoped<IRepository<int, ProductOptionValue>, ProductOptionValueRepository>(); 
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>(); 
            builder.Services.AddScoped<IRepository<int, Store>, StoreRepository>(); 
            builder.Services.AddScoped<IRepository<int, SuperCategory>, SuperCategoryRepository>();

            #endregion


            #region services 
            builder.Services.AddScoped<ITokenService, TokenService>(); 
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMenuService, MenuService>(); 
            builder.Services.AddScoped<IProductService, ProductService>(); 
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IStoreService, StoreService>();  
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();   
            #endregion



            #region CORS 
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyCors");


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
