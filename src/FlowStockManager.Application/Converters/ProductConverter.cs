using AutoMapper;
using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.Converters
{
    public sealed class ProductConverter : IProductConverter
    {
        private readonly IMapper _mapper;

        public ProductConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductDto ToDto(Product product)
        {
            return _mapper.Map<ProductDto>(product);
        }

        public Product ToEntity(UpdateProductRequest productRequest)
        {
            return _mapper.Map<Product>(productRequest);
        }

        public Product ToEntity(ConsumeProductRequest productRequest)
        {
            return _mapper.Map<Product>(productRequest);
        }

        public IEnumerable<ProductDto> ToIEnumerableDto(IEnumerable<Product> products)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public Product CreateProduct(CreateProductRequest productRequest, string supplierId)
        {
            return Product.Factories.NewProduct(productRequest.Name, productRequest.Description, productRequest.Price,
                productRequest.StockQuantity, supplierId);
        }
    }
}
