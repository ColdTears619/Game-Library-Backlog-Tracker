namespace GameLibraryBacklogTracker.Entities;

public class GameListing
{
    public int Id { get; private set; }

    public string? StorePageUrl { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    public int GameId { get; private set; }

    public Game Game;

    public int GameStoreId { get; private set; }

    public GameStore GameStores;

    public GameListing(int gameId, int gameStoreId, string? storePageUrl = null)
    {
        GameId = gameId;
        GameStoreId = gameStoreId;
        StorePageUrl = storePageUrl;
        CreatedAtUtc = DateTime.Now;
    }
}