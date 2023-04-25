using Core.Abstractions.Repository;
using Core.Models;
using Serilog;

namespace Repository
{
    public class HistoricalDataRepository : GenericRepository<HistoricalData>, IHistoricalDataRepository
    {
        public HistoricalDataRepository(ILogger logger, IOrderSorterContext context) : base(logger, context)
        {
        }
    }

}
