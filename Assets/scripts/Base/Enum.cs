public enum UnitState
{
    Idle,
    Move,
    Attack,
    /// <summary>
    /// 被击退
    /// </summary>
    BeatBack,
    Die
}
/// <summary>
/// 阵营
/// </summary>
public enum Camp
{
    Blue,
    Red
}
/// <summary>
/// 攻击范围类型
/// </summary>
public enum AttackRangedType
{
    MeleeAttacks,
    RangedAttacks
}
