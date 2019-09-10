using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantBuilding
    {
        public string Name { get; set; }

        public string Rarity { get; set; }

        public int SightRange { get; set; }

        public int Hitpoints { get; set; }

        public int HitSpeed { get; set; }

        public int LoadTime { get; set; }

        public bool LoadFirstHit { get; set; }

        public bool LoadAfterRetarget { get; set; }

        public string Projectile { get; set; }

        public bool AllTargetsHit { get; set; }

        public int Range { get; set; }

        public bool AttacksGround { get; set; }

        public bool AttacksAir { get; set; }

        public bool TargetOnlyBuildings { get; set; }

        public int AttachedCharacterHeight { get; set; }

        public bool SpawnEffectOnce { get; set; }

        public bool CrowdEffects { get; set; }

        public bool IgnorePushback { get; set; }

        public int Scale { get; set; }

        public int CollisionRadius { get; set; }

        public int TileSizeOverride { get; set; }

        public bool ShowHealthNumber { get; set; }

        public bool FlyDirectPaths { get; set; }

        public bool FlyFromGround { get; set; }

        public bool HealOnMorph { get; set; }

        public bool MorphKeepTarget { get; set; }

        public bool DashOnlyOnce { get; set; }

        public bool DestroyAtLimit { get; set; }

        public bool SpawnAttach { get; set; }

        public bool DeathSpawnPushback { get; set; }

        public bool DeathInheritIgnoreList { get; set; }

        public bool Kamikaze { get; set; }

        public int ProjectileStartRadius { get; set; }

        public int ProjectileStartZ { get; set; }

        public bool DontStopMoveAnim { get; set; }

        public bool IsSummonerTower { get; set; }

        public int NoDeploySizeW { get; set; }

        public int NoDeploySizeH { get; set; }

        public bool SelfAsAoeCenter { get; set; }

        public bool HidesWhenNotAttacking { get; set; }

        public bool HideBeforeFirstHit { get; set; }

        public bool SpecialAttackWhenHidden { get; set; }

        public bool HasRotationOnTimeline { get; set; }

        public int TurretMovement { get; set; }

        public int ProjectileYOffset { get; set; }

        public bool JumpEnabled { get; set; }

        public bool RetargetAfterAttack { get; set; }

        public bool BurstKeepTarget { get; set; }

        public bool BurstAffectAnimation { get; set; }

        public bool BuildingTarget { get; set; }

        public bool SpawnConstPriority { get; set; }

        public string NameEn { get; set; }

        public string AttachedCharacter { get; set; }

        public int? DeployTime { get; set; }

        public int? LifeTime { get; set; }

        public string Key { get; set; }

        public int? Elixir { get; set; }

        public string Type { get; set; }

        public int? Arena { get; set; }

        public string Description { get; set; }

        public int? Id { get; set; }

        public int? SpawnNumber { get; set; }

        public int? SpawnPauseTime { get; set; }

        public int? SpawnCharacterLevelIndex { get; set; }

        public string SpawnCharacter { get; set; }

        public int? MinimumRange { get; set; }

        public int? Damage { get; set; }

        public int? VariableDamage2 { get; set; }

        public int? VariableDamageTime1 { get; set; }

        public int? VariableDamage3 { get; set; }

        public int? VariableDamageTime2 { get; set; }

        public string TargettedDamageEffect1 { get; set; }

        public string TargettedDamageEffect2 { get; set; }

        public string TargettedDamageEffect3 { get; set; }

        public string DamageLevelTransitionEffect12 { get; set; }

        public string DamageLevelTransitionEffect23 { get; set; }

        public string FlameEffect1 { get; set; }

        public string FlameEffect2 { get; set; }

        public string FlameEffect3 { get; set; }

        public int? TargetEffectY { get; set; }

        public int? SpawnInterval { get; set; }

        public int? HideTimeMs { get; set; }

        public int? UpTimeMs { get; set; }

        public int? ManaCollectAmount { get; set; }

        public int? ManaGenerateTimeMs { get; set; }

        public int? DeathSpawnCount { get; set; }

        public string DeathSpawnCharacter { get; set; }

        public int? DeathDamageRadius { get; set; }

        public int? DeathDamage { get; set; }

        public int? DeathPushBack { get; set; }

        public int? DeathSpawnRadius { get; set; }

        public int? DeathSpawnMinRadius { get; set; }

        public int? DeathSpawnDeployTime { get; set; }
    }
}