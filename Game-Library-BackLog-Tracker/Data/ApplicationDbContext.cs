
using GameLibraryBacklogTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryBacklogTracker.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }

    public DbSet<GameStore> GameStores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>().Property(g => g.Name).HasMaxLength(200).IsRequired();

        modelBuilder.Entity<Game>().Property(g => g.Description).HasMaxLength(2000);

        modelBuilder.Entity<Game>().Property(g => g.ReleaseDate).IsRequired();

        modelBuilder.Entity<Game>().Property(g => g.Developer)
        .HasMaxLength(150).IsRequired();

        modelBuilder.Entity<Game>().Property(g => g.Publisher).HasMaxLength(150).IsRequired();

        modelBuilder.Entity<GameStore>().HasIndex(gs => gs.StoreName).IsUnique();
    }
}