using Microsoft.EntityFrameworkCore;
using MinaBilder.Domain;

namespace MinaBilder.Data
{
    public class MinaBilderContext : DbContext
    {
        public DbSet<Fil> Filer { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<AlbumAntalFiler> AlbumAntalFiler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=MinaBilder");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumAntalFiler>()
                .HasNoKey()
                .ToView("AlbumAntalFiler");
        }
    }
}
