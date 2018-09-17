namespace Pekka.RoyaleApi.Client.Models
{
    public class Mode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Deck { get; set; }
        public string CardLevels { get; set; }
        public int OvertimeSeconds { get; set; }
        public string Players { get; set; }
        public bool SameDeck { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Id}";
        }
    }
}