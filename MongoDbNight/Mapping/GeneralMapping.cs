using AutoMapper;
using MongoDbNight.Dtos.CategoryDtos;
using MongoDbNight.Dtos.CustomerDtos;
using MongoDbNight.Dtos.OrderDtos;
using MongoDbNight.Dtos.OrderItemDtos;
using MongoDbNight.Dtos.ProductDtos;
using MongoDbNight.Entities;

namespace MongoDbNight.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerDto>().ReverseMap();

            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, GetByIdOrderDto>().ReverseMap();

            CreateMap<OrderItem, ResultOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, UpdateOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, GetByIdOrderItemDto>().ReverseMap();
        }
    }
}
