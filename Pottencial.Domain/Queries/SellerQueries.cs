using System.Linq.Expressions;
using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Queries;

public class SellerQueries
{
    public static Expression<Func<Seller, bool>> GetById(Guid id)
    {
        return x => x.Id == id;
    }
}