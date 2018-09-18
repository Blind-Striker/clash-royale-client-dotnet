namespace Pekka.ClashRoyaleApi.Client
{
    public static class UrlPathBuilder
    {
        public const string PlayerUrl = "players";
        public const string BattleLogUrl = "battlelog";
        public const string UpcomingChests = "upcomingchests";

        private static readonly string PlayerTemplate = $"{PlayerUrl}/{{0}}";
        private static readonly string BattleLogTemplate = $"{PlayerUrl}/{{0}}/{BattleLogUrl}";
        private static readonly string UpcomingChestsTemplate = $"{PlayerUrl}/{{0}}/{UpcomingChests}";

        public static string GetPlayerUrl(string playerTag)
        {
            return string.Format(PlayerTemplate, playerTag);
        }

        public static string GetBattlelogUrl(string playerTag)
        {
            return string.Format(BattleLogTemplate, playerTag);
        }

        public static string GetUpcomingChestsUrl(string playerTag)
        {
            return string.Format(UpcomingChestsTemplate, playerTag);
        }
    }
}
