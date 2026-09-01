using System.ComponentModel.DataAnnotations;

namespace GameLibraryBacklogTracker.Entities;

public class GameStore
{
    public int Id { get; private set; }

    [Required]
    [MaxLength(100)]
    public string StoreName { get; private set; }

    [MaxLength(500)]
    public string? WebSiteUrl { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public ICollection<GameListing> GameListings;

    public GameStore(string storeName, string? webSiteUrl)
    {
        StoreName = storeName;
        WebSiteUrl = webSiteUrl;
        CreatedAt = DateTime.UtcNow;
    }
}