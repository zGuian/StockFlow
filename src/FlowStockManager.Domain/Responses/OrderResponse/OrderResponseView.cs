using FlowStockManager.Domain.DTOs.Orders;
using FlowStockManager.Domain.Responses.Base;

namespace FlowStockManager.Domain.Responses.OrderResponse
{
    public class OrderResponseView : ResponseView<OrderDto>
    {
        private OrderResponseView(IEnumerable<OrderDto> content)
        {
            Content = new List<OrderDto>(content);
        }

        private OrderResponseView(OrderDto content)
        {
            Content = [content];
        }

        public static class Factories
        {
            public static OrderResponseView CreateResponseView(IEnumerable<OrderDto> content)
            {
                return new OrderResponseView(content);
            }

            public static OrderResponseView CreateResponseView(OrderDto content)
            {
                return new OrderResponseView(content);
            }
        }
    }
}
