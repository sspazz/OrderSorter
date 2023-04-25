using Core.Abstractions.Repository;
using Core.Models;
using Serilog;

namespace Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ILogger logger, IOrderSorterContext context) : base(logger, context)
        {
        }
    }

}
