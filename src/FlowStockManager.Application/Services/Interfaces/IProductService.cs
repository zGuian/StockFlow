﻿using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAsync(int take, int skip);
        Task<Product> GetAsync(Guid id);
        Task<IEnumerable<Product>> GetAsync(IEnumerable<Product> products);
        Task<Product> RegisterAsync(Product entity);
        Task<Product> UpdateAsync(Product entity);
        Task DeleteAsync(Guid id);
        bool VerifyDisponible(IEnumerable<Product> products);
        //bool VerifyDisponible(IEnumerable<OrderProduct> orderProducts);
        Task ConsumeProducts(IEnumerable<Product> products);

    }
}
