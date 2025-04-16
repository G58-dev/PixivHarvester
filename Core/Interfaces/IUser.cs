namespace Core.Interfaces
{
    internal interface IUser
    {
        // Properties

        int Id { get; set; }
        string Name { get; set; }
        string WebLink { get; set; }
        List<int>? Illusts { get; set; }

        // Methods

        // Clears all data for a new User
        void ResetProperties();

        // Add new data instead of creating a new instance of User
        void FetchNewData(int id, string name, string webLink, List<int>? Illusts);
    }
}
