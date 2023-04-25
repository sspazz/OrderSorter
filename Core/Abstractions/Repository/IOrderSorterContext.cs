using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Core.Abstractions.Repository
{
    public interface IOrderSorterContext : IDbContext
    {
        DbSet<HistoricalData> HistoricalData { get; set; }
        DbSet<DeliveryPerson> DeliveryPerson { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<DailyRoute> DailyRoute { get; set; }
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
