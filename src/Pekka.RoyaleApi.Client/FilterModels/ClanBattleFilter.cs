using Pekka.Core;
using Pekka.Core.Attributes;
using Pekka.RoyaleApi.Client.Models;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class ClanBattleFilter : BaseFilter<Battle>
    {
        [Query("type")] public ClanBattleType ClanBattleType { get; set; }
    }
}