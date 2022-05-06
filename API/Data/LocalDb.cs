using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    
    public class LocalDb : DbContext
    {
        public LocalDb(DbContextOptions<LocalDb> opt) : base(opt)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(b => b.Address)
                .WithOne(i => i.Client)
                .HasForeignKey<Address>(b => b.ClientId);

            modelBuilder.Entity<Address>()
                .HasOne(c => c.Client)
                .WithOne(a => a.Address)
                .HasPrincipalKey<Client>(t => t.Tax_id);
        }

    }
}
