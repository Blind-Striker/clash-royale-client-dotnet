namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerSeason
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        public int Trophies { get; set; }
        public int? BestTrophies { get; set; }
    }
}