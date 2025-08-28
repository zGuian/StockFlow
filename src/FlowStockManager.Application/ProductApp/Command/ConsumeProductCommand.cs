using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.ProductApp.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.ProductApp.Command
{
    public class ConsumeProductCommand : IConsumeProductCommand
    {
        private readonly IProductCommandRepository _productCommand;
        private readonly IProductQueryRepository _productQuery;
        private readonly IProductConverter _converter;
        private readonly IUnitOfWork _unitOfWork;

        public ConsumeProductCommand(IProductCommandRepository productCommand, IProductQueryRepository productQuery,
            IUnitOfWork unitOfWork, IProductConverter converter)
        {
            _productCommand = productCommand;
            _productQuery = productQuery;
            _unitOfWork = unitOfWork;
            _converter = converter;
        }

        public async Task<ProductResponseView<ProductDto>> ExecuteAsync(ConsumeProductRequest[] requests)
        {
            var dict = new Dictionary<string, int>();
            foreach (var request in requests)
            {
                dict.Add(request.ProductId, request.Quantity);
            }
            var products = await FindAndConsumeProducts(requests, dict);
            _productCommand.Update(products);
            await _unitOfWork.CommitAsync();
            var dto = _converter.ToIEnumerableDto(products);
            var view = ProductResponseView<ProductDto>.Factories.CreateResponseView(dto);
            return view;
        }

        private async Task<Product[]> FindAndConsumeProducts(ConsumeProductRequest[] requests, Dictionary<string, int> values)
        {
            var products = await _productQuery.FindProductsAsync(values);
            for (int i = 0; i < requests.Length; i++)
            {
                var item = products[i];
                if (item.Id == requests[i].ProductId)
                {
                    item.ConsumeProduct(requests[i].Quantity);
                }
            }
            return products;
        }
    }
}
