using System;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    public class ClanMember
    {
        public string Name { get; set; }

        public string Tag { get; set; }

        public int Rank { get; set; }

        public int PreviousRank { get; set; }

        public string Role { get; set; }

        public int ExpLevel { get; set; }

        public int Trophies { get; set; }

        public DateTime LastSeen { get; set; }

        public int Donations { get; set; }

        public int DonationsReceived { get; set; }

        public int DonationsDelta { get; set; }

        public ClanArena Arena { get; set; }

        public double DonationsPercent { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}