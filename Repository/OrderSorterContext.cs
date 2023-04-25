using Core.Abstractions.Repository;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderSorterContext : DbContext, IOrderSorterContext
    {
        public OrderSorterContext(DbContextOptions<OrderSorterContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<DeliveryPerson> DeliveryPerson { get; set; }
        public DbSet<HistoricalData> HistoricalData { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<DailyRoute> DailyRoute { get; set; }

    }
}
