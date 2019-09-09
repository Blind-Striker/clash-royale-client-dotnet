namespace Pekka.RoyaleApi.Client.Models
{
    public class ArenaInfo
    {
        public string Name { get; set; }

        public string Arena { get; set; }

        public int ArenaId { get; set; }

        public int TrophyLimit { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Arena}";
        }
    }
}