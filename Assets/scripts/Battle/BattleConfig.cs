using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 战斗配置，需要在进入战斗场景前设置好
/// </summary>
[CreateAssetMenu(fileName = "BattleConfig", menuName = "ScriptableObject/BattleConfig", order = 0)]
public class BattleConfig : ScriptableObject
{
    public List<HeroData> BlueHeroes = new();
    public List<HeroData> RedHeroes = new();
}
