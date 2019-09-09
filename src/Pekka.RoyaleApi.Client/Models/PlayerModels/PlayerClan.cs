namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerClan : PlayerClanLight
    {
        public string Role { get; set; }

        public int Donations { get; set; }

        public int DonationsDelta { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}