using Pottencial.Domain.Entities;
using Pottencial.Domain.Repositories;

namespace Pottencial.Tests.Repositories;

public class FakeSellerRepository : ISellerRepository
{
    public async Task Create(Seller? seller)
    {
    }

    public async Task Update(Seller? seller)
    {
    }

    public async Task Delete(Seller? seller)
    {
    }

    public async Task<List<Seller?>> GetAll(int page, int pageSize)
    {
        return new List<Seller?>();
    }

    public async Task<Seller?> GetById(Guid id)
    {
        return new Seller("Wesley", "11122233344", "44999999999", "wesley@gmail.com");
    }
}