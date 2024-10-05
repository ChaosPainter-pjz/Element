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
    private GameMode m_gameMode;
    // Start is called before the first frame update
    private void Awake()
    {
        m_gameMode.OnBattleStart += OnBattleStart;
    }

    private void OnBattleStart()
    {
        CharacterUIController[] units = m_units.GetComponentsInChildren<CharacterUIController>();
        Hero[] blueHeroes =BattleManager.Instance.BlueHeroes.ToArray();
        int lenght = Mathf.Min(units.Length, blueHeroes.Length);
        for (int i = 0; i < lenght; i++)
        {
            units[i].Init(blueHeroes[i]);
        }

        for (int i = lenght; i < units.Length; i++)
        {
            units[i].Init(null);
        }
    }
}
