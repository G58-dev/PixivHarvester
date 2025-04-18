using Core.Interfaces;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Core.Classes
{
    public class Downloader //: IDownloader
    {
        // Fields

        private HttpClient _client = new HttpClient();
        private User _userWeb = new User();
        private User _userLocal = new User();

        // Properties

        public string PixivSession { get; set; }
        public string SavePath { get; set; } = string.Empty;
        public User UserWeb { get { return _userWeb; } }
        public User UserLocal { get { return _userLocal; } }

        // Initialize the Downloader
        public void InitDownloader(string pixivSession)
        {
            PixivSession = pixivSession;
            // Imitating a real client so Pixiv doesn't block us
            _client.DefaultRequestHeaders.Add("Cookie", $"PHPSESSID={PixivSession}");
            _client.DefaultRequestHeaders.Add("Referer", "https://www.pixiv.net/");
            _client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
        }

        // Methods

        // Validates whether the session is legitimate
        public async Task<bool> IsRealSessionAsync(string phpsessid)
        {
            // Imitating a real client so Pixiv doesn't block us
            _client.DefaultRequestHeaders.Add("Cookie", $"PHPSESSID={phpsessid}");
            _client.DefaultRequestHeaders.Add("Referer", "https://www.pixiv.net/");
            _client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

            // Tries to access to your profile settings
            HttpResponseMessage response = await _client.GetAsync("https://www.pixiv.net/settings/profile");

            // If cannot access this page, it means the session is invalid
            if (!response.IsSuccessStatusCode)
            {
                _client.DefaultRequestHeaders.Clear();
                return false;
            }
            _client.DefaultRequestHeaders.Clear();
            return true;
        }

        //// Fetches user profile info from pixiv.net
        //public async Task FetchUserAsync(int userId)
        //{

        //}

        //// Fetches user's illustrations from pixiv.net/ajax
        //public async Task<List<int>> FetchIllustsAsync(int userId)
        //{
            
        //}

        //// Fetches the URL of the specified illustration
        //public async Task<string> FetchIllustUrlAsync(int illustId)
        //{

        //}

        //// Downloads illustration from pixiv.net
        //public async Task DownloadIllustAsync(string originalUrl, int illustId)
        //{

        //}

        //// Saves user data to a JSON file in the local 'User' folder
        //public void SaveUserToSavePath(IUser user)
        //{

        //}

        //// Gets the path to the folder where illustrations will be saved
        //public void SetSavePath()
        //{

        //}

        //// Reads user data from the local JSON file to prevent redundant illustration downloads
        //public int FetchLastIllustFromJsonFile()
        //{

        //}
    }
}
