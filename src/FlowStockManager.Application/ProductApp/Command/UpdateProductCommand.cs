using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.ProductApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.ProductApp.Command
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly IProductCommandRepository _repository;
        private readonly IProductConverter _productConverter;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommand(IProductCommandRepository repository, IProductConverter productUseCase, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _productConverter = productUseCase;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponseView<ProductDto>> ExecuteAsync(UpdateProductRequest productRequest)
        {
            var entity = _productConverter.ToEntity(productRequest);
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            var dto = _productConverter.ToDto(entity);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView([dto]);
        }
    }
}
