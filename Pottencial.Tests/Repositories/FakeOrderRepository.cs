using Pottencial.Domain.Entities;
using Pottencial.Domain.Repositories;

namespace Pottencial.Tests.Repositories;

public class FakeOrderRepository : IOrderRepository
{
    public async Task Create(Order? order)
    {
        
    }

    public async Task PatchStatus(Order order)
    {
    }

    public async Task Delete(Order? order)
    {
    }

    public async Task<List<Order>> GetAll(int page, int pageSize)
    {
        return new List<Order>();
    }

    public async Task<Order?> GetById(Guid id)
    {
        return new Order(null, 10, null);
    }
}