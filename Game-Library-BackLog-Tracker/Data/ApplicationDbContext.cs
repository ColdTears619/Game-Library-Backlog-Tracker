
using GameLibraryBacklogTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryBacklogTracker.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }
}