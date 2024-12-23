using FlowStockManager.Domain.DTOs.Products;
using FlowStockManager.Domain.Responses.Base;

namespace FlowStockManager.Domain.Responses.ProductResponse
{
    public class ProductResponseView : ResponseView<ProductDto>
    {
        private ProductResponseView(IEnumerable<ProductDto> content)
        {
            Content = new List<ProductDto>(content);
            TotalValue = content.Count();
        }        
        
        private ProductResponseView(ProductDto content)
        {
            Content = new List<ProductDto> { content };
        }

        public static class Factories
        {
            public static ProductResponseView CreateResponseView(IEnumerable<ProductDto> @object)
            {
                return new ProductResponseView(@object);
            }

            public static ProductResponseView CreateResponseView(ProductDto product)
            {
                return new ProductResponseView(product);
            }
        }
    }
}
