using System.Web;

namespace Pekka.ClashRoyaleApi.Client
{
    public static class UrlPathBuilder
    {
        public const string PlayerUrl = "players";
        public const string BattleLogUrl = "battlelog";
        public const string UpcomingChestUrl = "upcomingchests";

        public const string ClanUrl = "clans";
        public const string MemberUrl = "members";
        public const string WarlogUrl = "warlog";
        public const string CurrentWarUrl = "currentwar";

        public const string TournamentUrl = "tournaments";

        public const string CardUrl = "cards";

        public const string LocationUrl = "locations";
        public const string RankingsClanUrl = "rankings/clans";
        public const string RankingsPlayerUrl = "rankings/players";
        public const string RankingsClanWarUrl = "rankings/clanwars";

        private static readonly string PlayerTemplate = $"{PlayerUrl}/{{0}}";
        private static readonly string BattleLogTemplate = $"{PlayerUrl}/{{0}}/{BattleLogUrl}";
        private static readonly string UpcomingChestsTemplate = $"{PlayerUrl}/{{0}}/{UpcomingChestUrl}";

        private static readonly string ClanTemplate = $"{ClanUrl}/{{0}}";
        private static readonly string MemberTemplate = $"{ClanUrl}/{{0}}/{MemberUrl}";
        private static readonly string WarlogTemplate = $"{ClanUrl}/{{0}}/{WarlogUrl}";
        private static readonly string CurrentWarTemplate = $"{ClanUrl}/{{0}}/{CurrentWarUrl}";

        private static readonly string TournamentTemplate = $"{TournamentUrl}/{{0}}";

        private static readonly string LocationTemplate = $"{LocationUrl}/{{0}}";
        private static readonly string RankingsClanTemplate = $"{LocationUrl}/{{0}}/{RankingsClanUrl}";
        private static readonly string RankingsPlayerTemplate = $"{LocationUrl}/{{0}}/{RankingsPlayerUrl}";
        private static readonly string RankingsClanWarTemplate = $"{LocationUrl}/{{0}}/{RankingsClanWarUrl}";

        public static string GetPlayerUrl(string playerTag)
        {
            return string.Format(PlayerTemplate, HttpUtility.UrlEncode(playerTag));
        }

        public static string GetBattlelogUrl(string playerTag)
        {
            return string.Format(BattleLogTemplate, HttpUtility.UrlEncode(playerTag));
        }

        public static string GetUpcomingChestsUrl(string playerTag)
        {
            return string.Format(UpcomingChestsTemplate, HttpUtility.UrlEncode(playerTag));
        }

        public static string GetClanUrl(string clanTag)
        {
            return string.Format(ClanTemplate, HttpUtility.UrlEncode(clanTag));
        }

        public static string GetMemberUrl(string clanTag)
        {
            return string.Format(MemberTemplate, HttpUtility.UrlEncode(clanTag));
        }

        public static string GetWarlogUrl(string clanTag)
        {
            return string.Format(WarlogTemplate, HttpUtility.UrlEncode(clanTag));
        }

        public static string GetCurrentWarUrl(string clanTag)
        {
            return string.Format(CurrentWarTemplate, HttpUtility.UrlEncode(clanTag));
        }

        public static string GetTournamentUrl(string tournamentTag)
        {
            return string.Format(TournamentTemplate, HttpUtility.UrlEncode(tournamentTag));
        }

        public static string GetLocationUrl(int locationId)
        {
            return string.Format(LocationTemplate, locationId);
        }

        public static string GetRankingsClanUrl(int locationId)
        {
            return string.Format(RankingsClanTemplate, locationId);
        }

        public static string GetRankingsPlayerUrl(int locationId)
        {
            return string.Format(RankingsPlayerTemplate, locationId);
        }

        public static string GetRankingsClanWarUrl(int locationId)
        {
            return string.Format(RankingsClanWarTemplate, locationId);
        }
    }
}