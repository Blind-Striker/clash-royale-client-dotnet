namespace RoyaleApi.Client.Models
{
    public class Deck
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public string Rarity { get; set; }
        public string RequiredForUpgrade { get; set; }
        public string Icon { get; set; }
        public string Key { get; set; }
        public int Elixir { get; set; }
        public string Type { get; set; }
        public int Arena { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}