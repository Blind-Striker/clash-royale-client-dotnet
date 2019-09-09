namespace Pekka.RoyaleApi.Client.Models.TournamentModels
{
    public class Tournament
    {
        public string Tag { get; set; }

        public bool Open { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }

        public int MaxPlayers { get; set; }

        public int CurrentPlayers { get; set; }

        public int PrepTime { get; set; }

        public int Duration { get; set; }

        public int? EndTime { get; set; }

        public int? StartTime { get; set; }

        public int? CreateTime { get; set; }

        public string Description { get; set; }

        public int UpdatedAt { get; set; }

        private TournamentPlayer Creator { get; set; }

        private TournamentPlayer[] Members { get; set; }
    }
}