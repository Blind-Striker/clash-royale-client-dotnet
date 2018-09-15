using System.Collections.Generic;

namespace RoyaleApi.Client.Models
{
    public class Clan
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Score { get; set; }
        public int MemberCount { get; set; }
        public int RequiredScore { get; set; }
        public int Donations { get; set; }
        public Badge Badge { get; set; }
        public Location Location { get; set; }
        public IList<Member> Members { get; set; }
        public Tracking Tracking { get; set; }
    }
}