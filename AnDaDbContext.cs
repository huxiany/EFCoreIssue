using Microsoft.EntityFrameworkCore;
using EFCoreTileTests.Entity;

namespace EFCoreTileTests
{
    public class AnDaDbContext : DbContext
    {
        public AnDaDbContext() { }
        public AnDaDbContext(DbContextOptions<AnDaDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;database=AnDaSMT_test;uid=root;password=EaseSource");
        }

        public virtual DbSet<Tile> Tiles { get; set; }
    }
}
