using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<Calisanlar, ApplicationRole, int>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Unvanlar> Unvanlar { get; set; }
        public DbSet<Departmanlar> Departmanlar { get; set; }
        public DbSet<Calisanlar> Calisanlar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Departmanlar>()
            .HasOne<Calisanlar>(d => d.Sorumlu)
            .WithMany(c => c.SorumluDepartman).HasForeignKey(d => d.SorumluId);

            builder.Entity<Calisanlar>()
            .HasOne<Departmanlar>(d => d.Birim)
            .WithMany(c => c.Calisanlar).HasForeignKey(d => d.BirimID);


            builder.Entity<Calisanlar>()
            .HasOne<Unvanlar>(d => d.Unvan)
            .WithMany(c => c.Calisanlar).HasForeignKey(d => d.UnvanID);
        }
    }
}