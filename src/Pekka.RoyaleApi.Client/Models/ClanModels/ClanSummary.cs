namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    public class ClanSummary
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Score { get; set; }

        public int MemberCount { get; set; }

        public int RequiredScore { get; set; }

        public int Donations { get; set; }

        public Badge Badge { get; set; }

        public ClanRegion Location { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}