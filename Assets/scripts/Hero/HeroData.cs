using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// 元素的固有属性值
/// </summary>
[CreateAssetMenu(fileName = "HeroData", menuName = "ScriptableObject/HeroData", order = 0)]
public class HeroData : ScriptableObject
{
    [FormerlySerializedAs("m_id")] public int Id;
    [FormerlySerializedAs("m_maxHp")] public int MaxHp;
    public string MasuriumName;
    [FormerlySerializedAs("m_name")] public string Name;
    public int m_speed = 50;
    [FormerlySerializedAs("m_attackRangedType")] public AttackRangedType AttackRangedType;
    /// <summary>
    /// 攻击范围，仅远程有效
    /// </summary>
    [FormerlySerializedAs("m_attackRanged")] public int AttackRanged = 8;
    /// <summary>
    /// 攻击力
    /// </summary>
    [FormerlySerializedAs("m_attack")] public int Attack = 1;
    /// <summary>
    /// 攻击时的冲击力
    /// </summary>
    [FormerlySerializedAs("m_impactForce")] public int ImpactForce = 0;

}
