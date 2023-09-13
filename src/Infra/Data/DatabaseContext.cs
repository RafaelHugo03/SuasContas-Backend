using Domain.Entities;
using Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Messaging;

namespace Infra.Data
{
    public class DatabaseContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected DatabaseContext(){}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new BillMap());
        }

        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}