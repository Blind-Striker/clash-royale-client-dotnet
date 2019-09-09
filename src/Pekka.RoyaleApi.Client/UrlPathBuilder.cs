using Pekka.Core;
using Pekka.Core.Extensions;

namespace Pekka.RoyaleApi.Client
{
    public static class UrlPathBuilder
    {
        public const string VersionUrl = "version";

        public const string ConstantsUrl = "constants";

        public const string PlayerUrl = "player";
        public const string BattlesUrl = "battles";
        public const string ChestsUrl = "chests";
        public const string TopPlayersUrl = "top/players";
        public const string PopularPlayersUrl = "popular/players";

        public const string ClanUrl = "clan";
        public const string ClanSearchUrl = "clan/search";
        public const string ClanWarLog = "warlog";
        public const string ClanWar = "war";
        public const string ClanTracking = "tracking";
        public const string ClanHistoryDaily = "history";
        public const string ClanHistoryWeekly = "history/weekly";
        public const string TopClansUrl = "top/clans";
        public const string PopularClansUrl = "popular/clans";
        public const string TopWarClanWarsUrl = "top/clans";

        public const string TournamentUrl = "tournament";
        public const string KnownTournamentUrl = "tournaments/known";
        public const string OpenTournamentUrl = "tournaments/open";
        public const string OneKTournamentUrl = "tournaments/1k";
        public const string InPrepTournamentUrl = "tournaments/inprep";
        public const string FullTournamentUrl = "tournaments/full";
        public const string JoinableTournamentUrl = "tournaments/joinable";
        public const string TournamentSearchUrl = "tournaments/search";
        public const string PopularTournamentUrl = "popular/tournaments";

        private static readonly string PlayerTemplate = $"{PlayerUrl}/{{0}}";
        private static readonly string BattlesTemplate = $"{PlayerUrl}/{{0}}/{BattlesUrl}";
        private static readonly string ChestsTemplate = $"{PlayerUrl}/{{0}}/{ChestsUrl}";
        private static readonly string TopPlayersTemplate = $"{TopPlayersUrl}/{{0}}";

        private static readonly string ClanTemplate = $"{ClanUrl}/{{0}}";
        private static readonly string ClanBattlesTemplate = $"{ClanUrl}/{{0}}/{BattlesUrl}";
        private static readonly string ClanWarLogTemplate = $"{ClanUrl}/{{0}}/{ClanWarLog}";
        private static readonly string ClanWarTemplate = $"{ClanUrl}/{{0}}/{ClanWar}";
        private static readonly string ClanTrackingTemplate = $"{ClanUrl}/{{0}}/{ClanTracking}";
        private static readonly string ClanHistoryDailyTemplate = $"{ClanUrl}/{{0}}/{ClanHistoryDaily}";
        private static readonly string ClanHistoryWeeklyTemplate = $"{ClanUrl}/{{0}}/{ClanHistoryWeekly}";
        private static readonly string TopClansTemplate = $"{TopClansUrl}/{{0}}";
        private static readonly string TopWarClanWarsTemplate = $"{TopWarClanWarsUrl}/{{0}}";

        private static readonly string TournamentTemplate = $"{TournamentUrl}/{{0}}";

        public static string GetPlayerUrl(params string[] playerTags)
        {
            return string.Format(PlayerTemplate, playerTags.JoinToString(","));
        }

        public static string GetPlayerBattlesUrl(params string[] playerTags)
        {
            return string.Format(BattlesTemplate, playerTags.JoinToString(","));
        }

        public static string GetPlayerChestsUrl(params string[] playerTags)
        {
            return string.Format(ChestsTemplate, playerTags.JoinToString(","));
        }

        public static string GetTopPlayersUrl(Locations location)
        {
            return string.Format(TopPlayersTemplate, location.ToString());
        }

        public static string GetClanUrl(params string[] clanTags)
        {
            return string.Format(ClanTemplate, clanTags.JoinToString(","));
        }

        public static string GetClanBattleUrl(string clanTag)
        {
            return string.Format(ClanBattlesTemplate, clanTag);
        }

        public static string GetClanWarLogUrl(string clanTag)
        {
            return string.Format(ClanWarLogTemplate, clanTag);
        }

        public static string GetClanWarUrl(string clanTag)
        {
            return string.Format(ClanWarTemplate, clanTag);
        }

        public static string GetClanTrackingUrl(string clanTag)
        {
            return string.Format(ClanTrackingTemplate, clanTag);
        }

        public static string GetClanHistoryDailyUrl(string clanTag)
        {
            return string.Format(ClanHistoryDailyTemplate, clanTag);
        }

        public static string GetClanHistoryWeeklyUrl(string clanTag)
        {
            return string.Format(ClanHistoryWeeklyTemplate, clanTag);
        }

        public static string GetTopClansUrl(Locations location)
        {
            return string.Format(TopClansTemplate, location.ToString());
        }

        public static string GetTopWarClanWarsUrl(Locations location)
        {
            return string.Format(TopWarClanWarsTemplate, location.ToString());
        }

        public static string GetTournamentUrl(params string[] tournamentTags)
        {
            return string.Format(TournamentTemplate, tournamentTags.JoinToString(","));
        }
    }
}