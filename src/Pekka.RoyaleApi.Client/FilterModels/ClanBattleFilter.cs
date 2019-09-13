using Pekka.Core.Attributes;
using Pekka.RoyaleApi.Client.Models;
using Pekka.RoyaleApi.Client.Models.PlayerModels;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class ClanBattleFilter : BaseFilter<PlayerBattle>
    {
        [Query("type")] public ClanBattleType ClanBattleType { get; set; }
    }
}