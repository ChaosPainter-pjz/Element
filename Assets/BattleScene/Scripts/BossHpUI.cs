using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BossHpUI : MonoBehaviour
{
    [SerializeField] private Text m_bossNameText;
    [SerializeField] private Scrollbar m_bossHpBar;

    private Hero boss;

    public void Init(Hero hero)
    {
        gameObject.SetActive(true);
        boss = hero;
        m_bossNameText.text = hero.HeroData.Name;
        Update();
    }

    private void Update()
    {
        if (!boss) return;
        if (boss.MaxHp > 0)
        {
            m_bossHpBar.size = boss.CurHp / boss.MaxHp;
        }
        else
        {
            m_bossHpBar.size = 0;
        }

        if (boss.CurHp <= 0)
        {
            boss = null;
            gameObject.SetActive(false);
        }
    }
}
