using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantSpell
    {
        public string Name { get; set; }

        public string Rarity { get; set; }

        public int LifeDuration { get; set; }

        public int LifeDurationIncreasePerLevel { get; set; }

        public int LifeDurationIncreaseAfterTournamentCap { get; set; }

        public bool AffectsHidden { get; set; }

        public int Radius { get; set; }

        public int HitSpeed { get; set; }

        public int Damage { get; set; }

        public bool NoEffectToCrownTowers { get; set; }

        public int CrownTowerDamagePercent { get; set; }

        public bool HitBiggestTargets { get; set; }

        public string Buff { get; set; }

        public int BuffTime { get; set; }

        public int BuffTimeIncreasePerLevel { get; set; }

        public int BuffTimeIncreaseAfterTournamentCap { get; set; }

        public bool CapBuffTimeToAreaEffectTime { get; set; }

        public int BuffNumber { get; set; }

        public bool OnlyEnemies { get; set; }

        public bool OnlyOwnTroops { get; set; }

        public bool IgnoreBuildings { get; set; }

        public bool IgnoreHero { get; set; }

        public string Projectile { get; set; }

        public string SpawnCharacter { get; set; }

        public int SpawnInterval { get; set; }

        public bool SpawnRandomizeSequence { get; set; }

        public string SpawnDeployBaseAnim { get; set; }

        public int SpawnTime { get; set; }

        public int SpawnCharacterLevelIndex { get; set; }

        public int SpawnInitialDelay { get; set; }

        public int SpawnMaxCount { get; set; }

        public int SpawnMaxRadius { get; set; }

        public int SpawnMinRadius { get; set; }

        public bool SpawnFromMinToMax { get; set; }

        public int SpawnAngleShift { get; set; }

        public bool HitsGround { get; set; }

        public bool HitsAir { get; set; }

        public string Key { get; set; }

        public int Elixir { get; set; }

        public string Type { get; set; }

        public int Arena { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }
    }
}