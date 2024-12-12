using FlowStockManager.Domain.DTOs.Clients;
using FlowStockManager.Domain.Responses.Base;

namespace FlowStockManager.Domain.Responses.ClientResponse
{
    public class ClientResponseView : ResponseView<ClientDto>
    {
        private ClientResponseView(IEnumerable<ClientDto> content)
        {
            Content = new List<ClientDto>(content);
            TotalValue = content.Count();
        }

        private ClientResponseView(ClientDto content)
        {
            Content = new List<ClientDto> { content };
        }

        public static class Factories
        {
            public static ClientResponseView CreateResponseView(IEnumerable<ClientDto> content)
            {
                return new ClientResponseView(content);
            }

            public static ClientResponseView CreateResponseView(ClientDto content)
            {
                return new ClientResponseView(content);
            }
        }
    }
}
