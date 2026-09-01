namespace GameLibraryBacklogTracker.Entities;

public class Game
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public string Developer { get; set; }

    public string Publisher { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public ICollection<GameListing> GameListings { get; private set; }

    public Game(string name, DateOnly releaseDate, string developer, string publisher, string? description = null)
    {
        Name = name;
        ReleaseDate = releaseDate;
        Developer = developer;
        Publisher = publisher;
        Description = description;
        CreatedAtUtc = DateTime.Now;
    }
}