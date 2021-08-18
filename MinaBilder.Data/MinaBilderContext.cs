using Microsoft.EntityFrameworkCore;
using MinaBilder.Domain;

namespace MinaBilder.Data
{
    public class MinaBilderContext : DbContext
    {
        public DbSet<Fil> Filer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=MinaBilder");
        }
    }
}
