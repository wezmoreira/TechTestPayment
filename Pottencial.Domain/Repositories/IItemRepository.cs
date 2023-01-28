using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Repositories;

public interface IItemRepository
{
    Task Create(Item item);
    Task Update(Item item);
    Task Delete(Item item);
    Task<List<Item>> GetAll(int page, int pageSize);
    Task<Item> GetById(Guid id);
    Task<Item> GetBySkuid(string skuid);
}