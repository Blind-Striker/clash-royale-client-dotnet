using System.Text;
using Pekka.Core.Helpers;
using Pekka.RoyaleApi.Client.Models;

namespace Pekka.RoyaleApi.Client
{
    public static class UrlPathBuilder
    {
        public const string Version = "version";

        public const string PlayerUrl = "player";
        public const string BattlesUrl = "battles";
        public const string ChestsUrl = "chests";
        public const string TopPlayersUrl = "top/players";
        public const string PopularPlayersUrl = "popular/players";

        public const string ClanUrl = "clan";
        public const string ClanWarLog = "warlog";
        public const string ClanWar = "war";
        public const string ClanTracking = "tracking";

        private static readonly string PlayerTemplate = $"{PlayerUrl}/{{0}}";
        private static readonly string BattlesTemplate = $"{PlayerUrl}/{{0}}/{BattlesUrl}";
        private static readonly string ChestsTemplate = $"{PlayerUrl}/{{0}}/{ChestsUrl}";
        private static readonly string TopPlayersTemplate = $"{TopPlayersUrl}/{{0}}";

        private static readonly string ClanTemplate = $"{ClanUrl}/{{0}}";
        private static readonly string ClanBattlesTemplate = $"{ClanUrl}/{{0}}/{BattlesUrl}";
        private static readonly string ClanWarLogTemplate = $"{ClanUrl}/{{0}}/{ClanWarLog}";
        private static readonly string ClanWarTemplate = $"{ClanUrl}/{{0}}/{ClanWar}";
        private static readonly string ClanTrackingTemplate = $"{ClanUrl}/{{0}}/{ClanTracking}";

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
    }
}
