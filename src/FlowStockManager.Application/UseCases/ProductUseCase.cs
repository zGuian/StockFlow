using AutoMapper;
using FlowStockManager.Domain.DTOs.Products;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.UseCases;
using FlowStockManager.Domain.Requests.OrderRequest.DtoRequest;
using FlowStockManager.Domain.Requests.ProductRequests;

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
            return _mapper.Map<ProductDto>(product);
        }

        public Product CreateProduct(CreateProductRequest productRequest, Guid supplierId)
        {
            return Product.Factories.NewProduct(productRequest.Name, productRequest.Description, productRequest.Price,
                productRequest.StockQuantity, supplierId);
        }

        public Product ToEntity(UpdateProductRequest productRequest)
        {
            return _mapper.Map<Product>(productRequest);
        }

        public IEnumerable<ProductDto> EnumerableToDto(IEnumerable<Product> products)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public IEnumerable<Product> EnumerableToEntity(IEnumerable<ProductDtoRequest> products)
        {
            return products.Select(p => _mapper.Map<Product>(p));
        }
    }
}
