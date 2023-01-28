using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Repositories;

public interface IOrderRepository
{
    Task Create(Order? order);
    Task PatchStatus(Order order);
    Task Delete(Order? order);
    Task<List<Order>> GetAll(int page, int pageSize);
    Task<Order> GetById(Guid id);
}