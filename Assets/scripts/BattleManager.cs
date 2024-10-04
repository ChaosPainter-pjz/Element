using System;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class BattleManager : SingletonMonoBase<BattleManager>
{
    private readonly HashSet<Hero> _blueHeroes = new HashSet<Hero>();
    private readonly HashSet<Hero> _redHeroes = new HashSet<Hero>();

    protected override void Awake()
    {
        base.Awake();
        foreach (var hero in FindObjectsOfType<Hero>())
        {
            AddHero(hero);
        }
    }

    public void AddHero(Hero hero)
    {
        if (hero.Camp == Camp.Blue)
        {
            _blueHeroes.Add(hero);
        }
        else
        {
            _redHeroes.Add(hero);
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
                foreach (var redHero in _redHeroes)
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
                foreach (var blueHero in _blueHeroes)
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
