using AutoMapper;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.OrderRequest.DtoRequest;
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

            CreateMap<Product, UpdateProductRequest>();

            CreateMap<ProductDtoRequest, Product>()
                .ForMember(src => src.Id,
                    opts 
                    => opts.MapFrom(dest => dest.ProductId))
                .ForMember(src => src.QtdValueProduct,
                    opts 
                    => opts.MapFrom(dest => dest.QtdProduct));
        }
    }
}
