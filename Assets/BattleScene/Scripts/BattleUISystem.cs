using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BattleUISystem : MonoBehaviour
{
    [SerializeField]
    private GameMode m_gameMode;
    /// <summary>
    /// 单位的信息列表
    /// </summary>
    [SerializeField]
    private Transform m_units;
    [SerializeField]
    private BossHpUI m_bossHpUI;

    [SerializeField] private Button m_speedButton;
    [SerializeField] private Text m_speedText;
    [SerializeField] private Button m_returnButton;
    [SerializeField] private SettingUI m_pauseView;
    // Start is called before the first frame update
    private void Awake()
    {
        m_gameMode.OnBattleStart += OnBattleStart;
        m_speedButton.onClick.AddListener(SpeedButtonOnClick);
        m_returnButton.onClick.AddListener(ReturnButtonOnClick);
        m_pauseView.gameObject.SetActive(false);
    }

    private void OnBattleStart()
    {
        //我方单位血条
        CharacterUI[] units = m_units.GetComponentsInChildren<CharacterUI>();
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

    void SpeedButtonOnClick()
    {
        if (Time.timeScale >1.5f)
        {
            Time.timeScale = 1;
            m_speedText.text = "x1";
        }
        else
        {
            Time.timeScale = 2;
            m_speedText.text = "x2";
        }
        //Debug.Log("速度："+Time.timeScale);
    }
    void ReturnButtonOnClick()
    {
        m_pauseView.OnView();
    }
}
