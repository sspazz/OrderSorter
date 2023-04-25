using Core.Abstractions.Repository;
using Core.Models;
using Serilog;

namespace Repository
{
    public class DeliveryPersonRepository : GenericRepository<DeliveryPerson>, IDeliveryPersonRepository
    {
        public DeliveryPersonRepository(ILogger logger, IOrderSorterContext context) : base(logger, context)
        {
        }
    }

}
