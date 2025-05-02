using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class Downloader
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

        // Clears the phpsessid downloader for a new account
        public void ResetDownloader()
        {
            _client.DefaultRequestHeaders.Clear();
            _userLocal.ResetProperties();
            _userWeb.ResetProperties();
        }

        // Methods

        // Fetches user profile info from pixiv.net
        public async Task FetchUserAsync(int userId)
        {
            string urlProfile = $"https://www.pixiv.net/en/users/{userId}";

            // Gets xml from User profile
            HttpResponseMessage response = await _client.GetAsync(urlProfile);

            // If connection was not success
            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            string result = await response.Content.ReadAsStringAsync();

            // Fetches the User's name, ID and background image (profile image is not available in HTML plain text)
            string name = Regex.Match(result, "<meta property=\"og:title\" content=\"(.*?)\"").Groups[1].Value;
            string bgImage = Regex.Match(result, "<meta property=\"og:image\" content=\"(.*?)\"").Groups[1].Value;
            string url = Regex.Match(result, "<meta property=\"twitter:url\" content=\"(.*?)\"").Groups[1].Value;
            string idFromUrl = Regex.Match(url, @"users/(\d+)").Groups[1].Value;

            _userWeb.ResetProperties();
            _userWeb.FetchNewData(int.Parse(idFromUrl), name, bgImage, urlProfile, await FetchIllustsAsync(userId));

        }

        // Fetches user's illustrations from pixiv.net/ajax
        public async Task<List<int>> FetchIllustsAsync(int userId)
        {
            string urlIllusts = $"https://www.pixiv.net/ajax/user/{userId}/profile/all";

            HttpResponseMessage response = await _client.GetAsync(urlIllusts);

            if (!response.IsSuccessStatusCode)
            {
                return new List<int>();
            }

            string result = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(result);

            if (!doc.RootElement.TryGetProperty("body", out JsonElement body))
            {
                return new List<int>();
            }

            if (!body.TryGetProperty("illusts", out JsonElement illusts))
            {
                return new List<int>();
            }

            // Saves all illust ids in a list
            List<int> illustList = new List<int>();
            int illustId;

            foreach (JsonProperty illust in illusts.EnumerateObject())
            {
                if (int.TryParse(illust.Name, out illustId))
                {
                    illustList.Add(illustId);
                }
            }

            // Delay Task to prevent Pixiv from blocking our connection for many petitions at a fast rate.
            await Task.Delay(2000);
            return illustList;
        }

        public async Task<string> FetchIllustURLAsync(int illustID)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://www.pixiv.net/artworks/{illustID}");
            string originalURL;

            if (!response.IsSuccessStatusCode)
            {
                return string.Empty;
            }

            string result = await response.Content.ReadAsStringAsync();

            string embedURL = Regex.Match(result, "<meta property=\"og:image\" content=\"(.*?)\" data-next-head=\"\"/>").Groups[1].Value;
            string unixTimestamp = Regex.Match(embedURL, @"mdate=(\d+)").Groups[1].Value;


            // Converts the Unix timestamp to a DateTime object
            if (!long.TryParse(unixTimestamp, out long timestamp)) { return "No Image"; }


            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(timestamp);

            // Changes the TimeZone to Japan
            DateTime japan = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dt, "JST");

            string month = japan.Month < 10 ? $"0{japan.Month}" : japan.Month.ToString();
            string day = japan.Day < 10 ? $"0{japan.Day}" : japan.Day.ToString();
            string hour = japan.Hour < 10 ? $"0{japan.Hour}" : japan.Hour.ToString();
            string minute = japan.Minute < 10 ? $"0{japan.Minute}" : japan.Minute.ToString();
            string second = japan.Second < 10 ? $"0{japan.Second}" : japan.Second.ToString();

            originalURL = $"https://i.pximg.net/img-original/img/{japan.Year}/{month}/{day}/{hour}/{minute}/{second}/{illustID}";

            return originalURL;
        }

        public async Task DownloadIllustAsync(string originalURL)
        {
            string userBg = $@"{SavePath}\{_userWeb.Id}\user_bg.png";

            if (File.Exists(userBg))
            {
                return;
            }

            HttpResponseMessage response = await _client.GetAsync(originalURL);
            await using FileStream fileStream = new FileStream(userBg, FileMode.Create);
            await response.Content.CopyToAsync(fileStream);
        }

        public async Task DownloadIllustAsync(string originalURL, int illustID)
        {
            Random random = new Random();

            int waitTime = random.Next(2000, 6000); // entre 2 y 6 segundos
            await Task.Delay(waitTime);

            HttpResponseMessage response;
            // If it has multiple illustrations from one ID
            StringBuilder multipleIllust = new StringBuilder($"{originalURL}_p0.png");
            int iterator = 0;

            response = await _client.GetAsync(multipleIllust.ToString());

            // Illust not available or not found
            if (!response.IsSuccessStatusCode)
            {
                multipleIllust.Replace("_p0.png", "_p0.jpg");
                response = await _client.GetAsync(multipleIllust.ToString());
            }

            while (true)
            {
                response = await _client.GetAsync(multipleIllust.ToString());
                if (!response.IsSuccessStatusCode) { break; }

                if (multipleIllust.ToString().EndsWith(".png"))
                {
                    await using FileStream fileStream = new FileStream($@"{SavePath}\{_userWeb.Id}\{illustID}_p{iterator}.png", FileMode.Create);
                    await response.Content.CopyToAsync(fileStream);

                    // In case it has multiple images, it will increase the iterator by 1
                    multipleIllust.Replace($"_p{iterator}.png", $"_p{iterator + 1}.png");
                }
                else if (multipleIllust.ToString().EndsWith(".jpg"))
                {
                    await using FileStream fileStream = new FileStream($@"{SavePath}\{_userWeb.Id}\{illustID}_p{iterator}.jpg", FileMode.Create);
                    await response.Content.CopyToAsync(fileStream);

                    // In case it has multiple images, it will increase the iterator by 1
                    multipleIllust.Replace($"_p{iterator}.jpg", $"_p{iterator + 1}.jpg");
                }

                iterator++;

                // Delay Task to prevent Pixiv from blocking our connection for too many petitions at a fast rate.
                await Task.Delay(2000);
            }
        }

        public async Task DownloadAllIllusts(CancellationToken token, IProgress<int> progressBar)
        {
            int i = 0;

            foreach (int illustID in _userWeb.Illusts)
            {
                string originalURL = await FetchIllustURLAsync(illustID);
                if (originalURL == "No Image")
                {
                    continue;
                }
                else
                {
                    i++;
                    var percentComplete = (i * 100) / _userWeb.Illusts.Count;
                    progressBar.Report(percentComplete);
                    await DownloadIllustAsync(originalURL, illustID);
                }

                token.ThrowIfCancellationRequested();
            }

            await SaveUserToJSON();
        }

        public void CreateUserFolder()
        {
            string userFolderPath = @$"{SavePath}\{UserWeb.Id}";
            if (!Directory.Exists(userFolderPath))
            {
                Directory.CreateDirectory(@$"{SavePath}\{UserWeb.Id}");
            }
        }
        public async Task SaveUserToJSON()
        {
            string userJSONPath = @$"{SavePath}\{UserWeb.Id}\{UserWeb.Id}.json";
            _userWeb.Illusts = await FetchIllustsAsync(UserWeb.Id);
            string userJSON = JsonSerializer.Serialize(_userWeb);

            File.WriteAllText(userJSONPath, userJSON);
        }

        public void UpdateUserIllusts()
        {
            string userJSONPath = @$"{SavePath}\{UserWeb.Id}\{UserWeb.Id}.json";

            if (!File.Exists(userJSONPath))
            {
                return;
            }

            int lastIllust = GetLastIllust();

            string userFilePath = @$"{SavePath}\{UserWeb.Id}\{UserWeb.Id}.json";

            List<int> updateIllusts = new List<int>();

            foreach (int illust in _userWeb.Illusts)
            {
                if (illust == lastIllust)
                {
                    break;
                }
                else
                {
                    updateIllusts.Add(illust);
                }
            }
            _userWeb.Illusts = updateIllusts;
        }

        public int GetLastIllust()
        {
            _userLocal.ResetProperties();

            // Path to User JSON 
            string path = @$"{SavePath}\{_userWeb.Id}\{_userWeb.Id}.json";

            string userJson = File.ReadAllText(path);
            _userLocal = JsonSerializer.Deserialize<User>(userJson)!;

            return _userLocal.Illusts[0];
        }
    }
}
