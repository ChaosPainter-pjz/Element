using System;
using System.Collections.Generic;
using Base;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleManager : SingletonMonoBase<BattleManager>
{
    private readonly HashSet<Hero> blueHeroes = new();
    private readonly HashSet<Hero> redHeroes = new();

    public HashSet<Hero> BlueHeroes => blueHeroes;

    public HashSet<Hero> RedHeroes => redHeroes;

    public void AddHero(Hero hero)
    {
        if (hero.Camp == Camp.Blue)
        {
            BlueHeroes.Add(hero);
        }
        else
        {
            RedHeroes.Add(hero);
        }
    }

    /// <summary>
    /// 试着获取距离指定单位最近的敌人
    /// </summary>
    /// <returns></returns>
    public bool TryGetEnemy(Hero hero, out Hero enemy)
    {
        enemy = null;
        float minDistance = float.MaxValue;
        Vector3 heroPosition = hero.transform.position;
        switch (hero.Camp)
        {
            case Camp.Blue:
                foreach (var redHero in RedHeroes)
                {
                    if (redHero.CurUnitState == UnitState.Die)
                    {
                        continue;
                    }
                    float distance = Vector3.Distance(heroPosition, redHero.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        enemy = redHero;
                    }
                }

                return enemy;
            case Camp.Red:
                foreach (var blueHero in BlueHeroes)
                {
                    if (blueHero.CurUnitState == UnitState.Die)
                    {
                        continue;
                    }
                    float distance = Vector3.Distance(heroPosition, blueHero.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        enemy = blueHero;
                    }
                }
                return enemy;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
