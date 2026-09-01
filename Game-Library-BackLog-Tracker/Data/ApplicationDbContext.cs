
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

    public DbSet<GameListing> GameListings { get; set; }

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

        modelBuilder.Entity<GameListing>().HasOne(g => g.Game).WithMany(gl => gl.GameListings).HasForeignKey(gi => gi.GameId).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<GameListing>().HasOne(gs => gs.GameStores).WithMany(gl => gl.GameListings).HasForeignKey(gsi => gsi.GameStoreId).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<GameListing>().HasIndex(gl => new { gl.GameId, gl.GameStoreId }).IsUnique();
    }
}