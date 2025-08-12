using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.ProductApp.Interfaces;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.ProductApp.Command
{
    public sealed class CreateProductCommand : ICreateProductCommand
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ISupplierQueryRepository _supplierQueryRepository;
        private readonly IProductConverter _productConverter;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommand(IProductConverter productUseCase, IUnitOfWork unitOfWork,
            IProductQueryRepository productQueryRepository, IProductCommandRepository productCommandRepository,
            ISupplierQueryRepository supplierQueryRepository)
        {
            _productConverter = productUseCase;
            _productCommandRepository = productCommandRepository;
            _unitOfWork = unitOfWork;
            _productQueryRepository = productQueryRepository;
            _supplierQueryRepository = supplierQueryRepository;
        }

        public async Task<ProductResponseView<ProductDto>> ExecuteAsync(CreateProductRequest productRequest)
        {
            await ValidateData(productRequest);
            var entity = _productConverter.CreateProduct(productRequest, productRequest.SupplierId);
            await _productCommandRepository.RegisterAsync(entity);
            await _unitOfWork.CommitAsync();
            var dto = _productConverter.ToDto(entity);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView([dto]);
        }

        private async Task ValidateData(CreateProductRequest productRequest)
        {
            ArgumentNullException.ThrowIfNull(productRequest);
            var hasRegistered = await _supplierQueryRepository.HasRegistered(productRequest.SupplierId);
            if (!hasRegistered)
            {
                throw new NotFoundRegisterSupplierException("Não foi encontrado fornecedor cadastrado");
            }
        }
    }
}
