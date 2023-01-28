using System.Linq.Expressions;
using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Queries;

public class OrderQueries
{
    public static Expression<Func<Order, bool>> GetById(Guid id)
    {
        return x => x.Id == id;
    }
    
    public static Expression<Func<Order, bool>> GetAllOrdersBySeller(Guid id)
    {
        return x => x.SellerId == id;
    }
}