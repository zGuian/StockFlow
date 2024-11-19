using AutoMapper;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Infra.CrossCutting.Profiles
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();

            CreateMap<Product, UpdateProductRequest>()
                .ReverseMap();
        }
    }
}
