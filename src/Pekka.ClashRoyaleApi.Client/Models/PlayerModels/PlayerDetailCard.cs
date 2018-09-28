namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    public class PlayerDetailCard
    {
        public string Name { get; set; }

        public int? Level { get; set; }

        public int? MaxLevel { get; set; }

        public int? Count { get; set; }

        public IconUrl IconUrls { get; set; }
    }
}
