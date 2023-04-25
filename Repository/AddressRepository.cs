using Core.Abstractions.Repository;
using Core.Models;
using Serilog;

namespace Repository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ILogger logger, IOrderSorterContext context) : base(logger, context)
        {
        }
    }

}
