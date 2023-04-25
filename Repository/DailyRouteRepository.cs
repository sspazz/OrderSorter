using Core.Abstractions.Repository;
using Core.Models;
using Serilog;

namespace Repository
{
    public class DailyRouteRepository : GenericRepository<DailyRoute>, IDailyRouteRepository
    {
        public DailyRouteRepository(ILogger logger, IOrderSorterContext context) : base(logger, context)
        {
        }
    }

}
