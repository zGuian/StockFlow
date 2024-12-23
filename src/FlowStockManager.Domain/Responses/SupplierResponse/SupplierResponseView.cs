using FlowStockManager.Domain.DTOs.Suppliers;
using FlowStockManager.Domain.Responses.Base;

namespace FlowStockManager.Domain.Responses.SupplierResponse
{
    public class SupplierResponseView : ResponseView<SupplierDto>
    {
        private SupplierResponseView(IEnumerable<SupplierDto> content)
        {
            Content = new List<SupplierDto>(content);
            TotalValue = content.Count();
        }

        private SupplierResponseView(SupplierDto content)
        {
            Content = new List<SupplierDto> { content };
        }

        public static class Factories
        {
            public static SupplierResponseView CreateResponseView(IEnumerable<SupplierDto> content)
            {
                return new SupplierResponseView(content);
            }

            public static SupplierResponseView CreateResponseView(SupplierDto content)
            {
                return new SupplierResponseView(content);
            }
        }
    }
}
