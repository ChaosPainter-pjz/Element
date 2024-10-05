using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Button m_continueButton;

    [SerializeField] private Button m_abandonButton;
    private float lastTimeScale = 1;
    private void Awake()
    {
        m_continueButton.onClick.AddListener(ContinueButtonClicked);
        m_abandonButton.onClick.AddListener(AbandonButtonClicked);
    }

    public void OnView()
    {
        gameObject.SetActive(true);
        lastTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    void ContinueButtonClicked()
    {
        Time.timeScale = lastTimeScale;
        gameObject.SetActive(false);
    }

    void AbandonButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
