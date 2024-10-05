using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

public class BattleUISystem : MonoBehaviour
{
    /// <summary>
    /// 单位的信息列表
    /// </summary>
    [SerializeField]
    private Transform m_units;
    [SerializeField]
    private BossHpUI m_bossHpUI;
    [SerializeField]
    private GameMode m_gameMode;
    // Start is called before the first frame update
    private void Awake()
    {
        m_gameMode.OnBattleStart += OnBattleStart;
    }

    private void OnBattleStart()
    {
        //我方单位血条
        CharacterUIController[] units = m_units.GetComponentsInChildren<CharacterUIController>();
        Hero[] blueHeroes = BattleManager.Instance.BlueHeroes.ToArray();
        int lenght = Mathf.Min(units.Length, blueHeroes.Length);
        for (int i = 0; i < lenght; i++)
        {
            units[i].Init(blueHeroes[i]);
        }

        for (int i = lenght; i < units.Length; i++)
        {
            units[i].Init(null);
        }
        //boss 血条
        if (BattleManager.Instance.RedHeroes.Count > 0)
        {
            float maxHp = 0;
            Hero target = null;
            foreach (var hero in BattleManager.Instance.RedHeroes)
            {
                if (hero.CurHp>maxHp)
                {
                    maxHp = hero.CurHp;
                    target = hero;
                }
            }
            m_bossHpUI.Init(target);
        }
        else
        {
            m_bossHpUI.gameObject.SetActive(false);
        }

    }
}
