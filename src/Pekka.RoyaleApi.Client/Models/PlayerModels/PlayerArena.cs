namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerArena
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Arena { get; set; }

        public int TrophyLimit { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Arena}";
        }
    }
}