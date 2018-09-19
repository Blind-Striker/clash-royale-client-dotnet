namespace Pekka.RoyaleApi.Client.Models
{
    public sealed class ClanBattleType
    {
        private ClanBattleType()
        {            
        }

        private ClanBattleType(string type)
        {
            Type = type;
        }

        public string Type { get; }

        public static readonly ClanBattleType All = new ClanBattleType("all");
        public static readonly ClanBattleType War = new ClanBattleType("war");
        public static readonly ClanBattleType ClanMate = new ClanBattleType("clanMate");

        public override string ToString()
        {
            return Type;
        }
    }
}
