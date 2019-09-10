using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantTroop
    {
        public string Name { get; set; }

        public string Rarity { get; set; }

        public int SightRange { get; set; }

        public int DeployTime { get; set; }

        public int Speed { get; set; }

        public int Hitpoints { get; set; }

        public int HitSpeed { get; set; }

        public int LoadTime { get; set; }

        public int Damage { get; set; }

        public bool LoadFirstHit { get; set; }

        public bool LoadAfterRetarget { get; set; }

        public bool AllTargetsHit { get; set; }

        public int Range { get; set; }

        public bool AttacksGround { get; set; }

        public bool AttacksAir { get; set; }

        public bool TargetOnlyBuildings { get; set; }

        public bool SpawnEffectOnce { get; set; }

        public bool CrowdEffects { get; set; }

        public bool IgnorePushback { get; set; }

        public int Scale { get; set; }

        public int CollisionRadius { get; set; }

        public int Mass { get; set; }

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

        public bool SelfAsAoeCenter { get; set; }

        public bool HidesWhenNotAttacking { get; set; }

        public bool HideBeforeFirstHit { get; set; }

        public bool SpecialAttackWhenHidden { get; set; }

        public bool HasRotationOnTimeline { get; set; }

        public bool JumpEnabled { get; set; }

        public bool RetargetAfterAttack { get; set; }

        public bool BurstKeepTarget { get; set; }

        public bool BurstAffectAnimation { get; set; }

        public bool BuildingTarget { get; set; }

        public bool SpawnConstPriority { get; set; }

        public string NameEn { get; set; }

        public string Key { get; set; }

        public int Elixir { get; set; }

        public string Type { get; set; }

        public int Arena { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string SpeedEn { get; set; }

        public double? Dps { get; set; }

        public string Projectile { get; set; }

        public int? DeployDelay { get; set; }

        public int? StopMovementAfterMs { get; set; }

        public int? WaitMs { get; set; }

        public int? SightClip { get; set; }

        public int? SightClipSide { get; set; }

        public int? WalkingSpeedTweakPercentage { get; set; }

        public int? FlyingHeight { get; set; }

        public string DeathSpawnCharacter { get; set; }

        public int? SpawnStartTime { get; set; }

        public int? SpawnInterval { get; set; }

        public int? SpawnNumber { get; set; }

        public int? SpawnPauseTime { get; set; }

        public int? SpawnCharacterLevelIndex { get; set; }

        public string SpawnCharacter { get; set; }

        public int? DeathDamageRadius { get; set; }

        public int? DeathDamage { get; set; }

        public int? DeathPushBack { get; set; }

        public int? DeathSpawnCount { get; set; }

        public int? DeathSpawnRadius { get; set; }

        public int? AreaDamageRadius { get; set; }

        public int? SpawnRadius { get; set; }

        public int? ChargeRange { get; set; }

        public int? DamageSpecial { get; set; }

        public string DamageEffectSpecial { get; set; }

        public int? ChargeSpeedMultiplier { get; set; }

        public int? JumpHeight { get; set; }

        public int? JumpSpeed { get; set; }

        public string CustomFirstProjectile { get; set; }

        public int? MultipleProjectiles { get; set; }

        public int? ShieldHitpoints { get; set; }

        public int? CrownTowerDamagePercent { get; set; }

        public int? SpawnPathfindSpeed { get; set; }

        public int? AttackPushBack { get; set; }

        public string ProjectileEffectSpecial { get; set; }

        public string LoadAttackEffect1 { get; set; }

        public string LoadAttackEffect2 { get; set; }

        public string LoadAttackEffect3 { get; set; }

        public string LoadAttackEffectReady { get; set; }

        public int? RotateAngleSpeed { get; set; }

        public int? VariableDamage2 { get; set; }

        public int? VariableDamageTime1 { get; set; }

        public int? VariableDamage3 { get; set; }

        public int? VariableDamageTime2 { get; set; }

        public string TargettedDamageEffect1 { get; set; }

        public string TargettedDamageEffect2 { get; set; }

        public string TargettedDamageEffect3 { get; set; }

        public string FlameEffect1 { get; set; }

        public string FlameEffect2 { get; set; }

        public string FlameEffect3 { get; set; }

        public int? TargetEffectY { get; set; }

        public int? VisualHitSpeed { get; set; }

        public string SpawnDeployBaseAnim { get; set; }

        public int? SpawnAngleShift { get; set; }

        public int? DeathSpawnDeployTime { get; set; }

        public int? AttackShakeTime { get; set; }

        public int? MultipleTargets { get; set; }

        public string BuffOnDamage { get; set; }

        public int? BuffOnDamageTime { get; set; }

        public string SpawnAreaObject { get; set; }

        public int? SpawnAreaObjectLevelIndex { get; set; }

        public int? DashImmuneToDamageTime { get; set; }

        public int? DashCooldown { get; set; }

        public int? DashDamage { get; set; }

        public string DashFilter { get; set; }

        public int? DashMinRange { get; set; }

        public int? DashMaxRange { get; set; }

        public int? HideTimeMs { get; set; }

        public string BuffWhenNotAttacking { get; set; }

        public int? BuffWhenNotAttackingTime { get; set; }

        public string AttachedCharacter { get; set; }

        public int? TargetedEffectVisualPushback { get; set; }

        public int? AttackDashTime { get; set; }

        public string LoopingFilter { get; set; }

        public int? LifeTime { get; set; }

        public int? MorphTime { get; set; }

        public int? DashPushBack { get; set; }

        public int? DashRadius { get; set; }

        public int? DashConstantTime { get; set; }

        public int? DashLandingTime { get; set; }

        public int? SpawnLimit { get; set; }

        public int? SpawnPushback { get; set; }

        public int? SpawnPushbackRadius { get; set; }

        public int? KamikazeTime { get; set; }
    }
}