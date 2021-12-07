using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        
        public DbSet<Unvanlar> Unvanlar {get;set;}
        public DbSet<Departmanlar> Departmanlar {get;set;}
        public DbSet<Calisanlar> Calisanlar {get;set;}

        
    }
}