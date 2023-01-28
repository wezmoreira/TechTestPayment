using Microsoft.EntityFrameworkCore;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Queries;
using Pottencial.Domain.Repositories;
using Pottencial.Infra.Context;

namespace Pottencial.Infra.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task Create(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task PatchStatus(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAll(int page, int pageSize)
    {
        return await _context.Orders
            .AsNoTracking()
            .Skip(page * pageSize)
            .Take(pageSize)
            .Include(x => x.Items)
            .Include(x => x.Seller)
            .ToListAsync();
    }

    public async Task<Order> GetById(Guid id)
    {
        var order = await _context.Orders
            .Include(x => x.Items)
            .Include(x => x.Seller)
            .FirstOrDefaultAsync(OrderQueries.GetById(id));
        if (order == null)
            return null;

        return order;
    }
}