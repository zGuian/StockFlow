using FlowStockManager.Domain.DTOs.Products;
using FlowStockManager.Domain.Interfaces.Handlers;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;
using FlowStockManager.Domain.Interfaces.UseCases;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.Base;

namespace FlowStockManager.Application.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductUseCase _useCase;
        private readonly IProductService _serviceProduct;

        public ProductHandler(IProductUseCase useCase, IProductService service, IUnitOfWork unitOfWork)
        {
            _useCase = useCase;
            _serviceProduct = service;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponsePage<IEnumerable<ProductDto>>> GetProductsAsync(int take, int skip)
        {
            var products = await _serviceProduct.GetAsync(take, skip);
            var dtos = _useCase.EnumerableToDto(products);
            return ResponsePage<IEnumerable<ProductDto>>.Factories.CreateResponsePaged(dtos, dtos.Count());
        }

        public async Task<Response<ProductDto>> GetProductsAsync(Guid id)
        {
            var product = await _serviceProduct.GetAsync(id);
            var dto = _useCase.ToDto(product);
            return Response<ProductDto>.Factories.CreateResponse(dto, true);
        }

        public async Task<Response<ProductDto>> RegisterProductAsync(CreateProductRequest productRequest)
        {
            var entity = _useCase.CreateProduct(productRequest, productRequest.SupplierId);
            entity = await _serviceProduct.RegisterAsync(entity);
            await _unitOfWork.CommitAsync();
            var dto = _useCase.ToDto(entity);
            return Response<ProductDto>.Factories.CreateResponse(dto, true);
        }

        public async Task<Response<ProductDto>> UpdateProductAsync(UpdateProductRequest productRequest)
        {
            var entity = _useCase.ToEntity(productRequest);
            entity = await _serviceProduct.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
            var dto = _useCase.ToDto(entity);
            return Response<ProductDto>.Factories.CreateResponse(dto, true);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _serviceProduct.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
