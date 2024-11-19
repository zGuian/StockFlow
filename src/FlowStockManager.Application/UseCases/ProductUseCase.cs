using AutoMapper;
using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.UseCases
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IMapper _mapper;

        public ProductUseCase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductDto ToDto(Product product)
        {
            throw new NotImplementedException();
            //return _mapper.Map<ProductDto>(product);
        }

        public Product ToEntity(CreateProductRequest productRequest)
        {
            throw new NotImplementedException();
            //return _mapper.Map<Product>(productRequest);
        }

        public Product ToEntity(UpdateProductRequest productRequest)
        {
            throw new NotImplementedException();
            //return _mapper.Map<Product>(productRequest);
        }

        public IEnumerable<ProductDto> ToIEnumerableDto(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
            //return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
