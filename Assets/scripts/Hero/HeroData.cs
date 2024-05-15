using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "ScriptableObject", menuName = "HeroData", order = 0)]
public class HeroData : ScriptableObject
{
    public int m_id;
    public int m_maxHp;
    public string m_name;
    public int m_speed = 50;
    public AttackRangedType m_attackRangedType;
    /// <summary>
    /// 攻击范围，仅远程有效
    /// </summary>
    public int m_attackRanged = 8;
}
