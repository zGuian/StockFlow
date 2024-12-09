﻿using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrderAsync();
        Task<Order> GetOrderAsync(Guid orderId);
        Task<Order> RegisterAsync(Order order);
        Task UpdateAsync(Order order);
    }
}