using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterUIController : MonoBehaviour
{
    [SerializeField]
    private Text m_characterNameText;
    private bool isInitialized = false;
    [SerializeField] private Scrollbar m_hp;
    private Hero CurrentHero = null;
    public void Init(Hero hero)
    {
        if (hero)
        {
            m_characterNameText.text = hero.HeroData.Name;

            gameObject.SetActive(true);
            CurrentHero = hero;
        }
        else
        {
            gameObject.SetActive(false);
        }

        isInitialized = hero != null;
    }
    void Update()
    {
        if (!isInitialized) return;
        if (CurrentHero.MaxHp != 0)
        {
            m_hp.size = CurrentHero.CurHp / CurrentHero.MaxHp;
        }
        else
        {
            m_hp.size = 0;
        }
    }
}
