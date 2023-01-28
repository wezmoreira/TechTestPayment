using Microsoft.EntityFrameworkCore;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Queries;
using Pottencial.Domain.Repositories;
using Pottencial.Infra.Context;

namespace Pottencial.Infra.Repositories;

public class SellerRepository : ISellerRepository
{
    private readonly DataContext _context;

    public SellerRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task Create(Seller seller)
    {
        await _context.Sellers.AddAsync(seller);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Seller seller)
    {
        _context.Entry(seller).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Seller seller)
    {
        _context.Sellers.Remove(seller);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Seller>> GetAll(int page, int pageSize)
    {
        return await _context.Sellers
            .AsNoTracking()
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Seller> GetById(Guid id)
    {
        var seller = await _context.Sellers
            .FirstOrDefaultAsync(SellerQueries.GetById(id));
        if (seller == null)
            return null;

        return seller;
    }
}