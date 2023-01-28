using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Repositories;

public interface ISellerRepository
{
    Task Create(Seller seller);
    Task Update(Seller seller);
    Task Delete(Seller seller);
    Task<List<Seller>> GetAll(int page, int pageSize);
    Task<Seller> GetById(Guid id);
}