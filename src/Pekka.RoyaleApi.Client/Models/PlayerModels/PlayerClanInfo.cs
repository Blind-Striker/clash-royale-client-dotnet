namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerClanInfo
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int Donations { get; set; }
        public int DonationsReceived { get; set; }
        public int DonationsDelta { get; set; }
        public Badge Badge { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}