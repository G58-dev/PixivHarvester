namespace Core.Classes
{
    public class User
    {
        // Properties

        public int Id { get; set; }
        public string Name { get; set; } = "[No username]";
        public string BgImage { get; set; } = string.Empty;
        public string WebLink { get; set; } = string.Empty;
        public List<int>? Illusts { get; set; } // The user may not have uploaded any illustrations

        // Methods

        // Resets all properties to prepare for a new user without creating a new instance
        public void ResetProperties()
        {
            Id = 0;
            Name = "[No username]";
            BgImage = string.Empty;
            WebLink = string.Empty;
            Illusts?.Clear();
        }

        // Custom method that functions like a constructor for a new User instance
        public void FetchNewData(int id, string name, string bgImage, string webLink, List<int>? illusts)
        {
            Id = id;
            Name = name;
            BgImage = bgImage;
            WebLink = webLink;
            Illusts = illusts;
        }
    }
}
