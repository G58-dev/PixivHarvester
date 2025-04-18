namespace Core.Interfaces
{
    public interface IDownloader
    {
        // Properties

        string PixivSession { get; set; }
        string SavePath { get; set; }

        // Methods

        // Validates whether the session is legitimate
        Task<bool> IsRealSessionAsync(string phpsessid);

        // Fetches user profile info from pixiv.net
        Task<bool> FetchUserAsync(int userId);

        // Fetches user's illustrations from pixiv.net/ajax
        Task<List<int>> FetchIllustsAsync(int userId);

        // Fetches the URL of the specified illustration
        Task<string> FetchIllustUrlAsync(int illustId);

        // Downloads illustration from pixiv.net
        Task DownloadIllustAsync(string originalUrl, int illustId);

        // Saves user data to a JSON file in the local 'User' folder
        void SaveUserToSavePath();

        // Gets the path to the folder where illustrations will be saved
        void SetSavePath();

        // Reads user data from the local JSON file to prevent redundant illustration downloads
        int FetchLastIllustFromJsonFile();
    }
}
