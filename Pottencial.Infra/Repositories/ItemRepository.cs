using Microsoft.EntityFrameworkCore;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Queries;
using Pottencial.Domain.Repositories;
using Pottencial.Infra.Context;

namespace Pottencial.Infra.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly DataContext _context;

    public ItemRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task Create(Item item)
    {
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Item item)
    {
        _context.Items.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Item item)
    {
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Item>> GetAll(int page, int pageSize)
    {
        return await _context.Items
            .AsNoTracking()
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Item> GetById(Guid id)
    {
        var item = await _context.Items
            .FirstOrDefaultAsync(ItemQueries.GetById(id));
        if (item == null)
            return null;

        return item;
    }

    public async Task<Item> GetBySkuid(string skuid)
    {
       
        var item = await _context.Items
            .FirstOrDefaultAsync(ItemQueries.GetBySkuid(skuid));
        if (item == null)
            return null;

        return item;
    }
}