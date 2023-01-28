using Pottencial.Domain.Entities;
using Pottencial.Domain.Repositories;

namespace Pottencial.Tests.Repositories;

public class FakeItemRepository : IItemRepository
{
    public async Task Create(Item? item)
    {
        
    }

    public async Task Update(Item? item)
    {
        
    }

    public async Task Delete(Item? item)
    {
        
    }

    public async Task<List<Item?>> GetAll(int page, int pageSize)
    {
        return new List<Item?>();
    }

    public async Task<Item?> GetById(Guid id)
    {
        return new Item("Gabinete", 200, 10);
    }

    public async Task<Item?> GetBySkuid(string skuid)
    {
        return new Item("Gabinete", 200, 10);
    }
}