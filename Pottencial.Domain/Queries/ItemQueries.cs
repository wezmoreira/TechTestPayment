using System.Linq.Expressions;
using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Queries;

public static class ItemQueries
{
    public static Expression<Func<Item, bool>> GetById(Guid id)
    {
        return x => x.Id == id;
    }
    
    public static Expression<Func<Item, bool>> GetBySkuid(string skuid)
    {
        return x => x.Skuid == skuid;
    }
}