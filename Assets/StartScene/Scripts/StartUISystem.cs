using System.Collections;
using System.Collections.Generic;
using Ele.Save;
using Esper.ESave;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUISystem : MonoBehaviour
{
    [SerializeField][Header("save")]
    private SaveFileSetup m_saveFileSetup;
    private SaveFile saveFile;
    [Header("ui")][SerializeField]
    private Button m_startButton;
    [SerializeField]
    private Button m_loadButton;
    [SerializeField]
    private Button m_exitButton;
    [SerializeField]
    private GameObject m_namePanel;
    [SerializeField]
    private Button m_namePanelEnterButton;
    [SerializeField]
    private InputField m_nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        saveFile = m_saveFileSetup.GetSaveFile();
        //TODO 此处需要拼个游戏ID+用户ID+main
        if (saveFile.HasData("main"))
        {
            m_startButton.gameObject.SetActive(false);
        }
        else
        {
            m_loadButton.gameObject.SetActive(false);
        }
        m_namePanel.gameObject.SetActive(false);
        m_startButton.onClick.AddListener(OnStartButtonClicked);
        m_loadButton.onClick.AddListener(OnloadButtonClicked);
        m_exitButton.onClick.AddListener(OnExit);
        m_namePanelEnterButton.onClick.AddListener(OnNamePanelEnterButton);
        m_nameInputField.onValueChanged.AddListener(OnInputContextChange);
    }

    private void OnStartButtonClicked()
    {
        m_namePanel.gameObject.SetActive(true);
        m_nameInputField.text = "";
        m_namePanelEnterButton.interactable = false;
    }

    private void OnInputContextChange(string text)
    {
        if (text.Length>0)
        {
            m_namePanelEnterButton.interactable = true;
        }
        else
        {
            m_namePanelEnterButton.interactable = false;
        }
    }

    private void OnNamePanelEnterButton()
    {
        SaveData saveData = new SaveData
        {
            PlayerName = m_nameInputField.text
        };
        saveFile.AddOrUpdateData<SaveData>("main",saveData);
        saveFile.Save();
        //TODO 跳转场景
        SceneManager.LoadScene(1);
    }

    private void OnloadButtonClicked()
    {
        //TODO 跳转场景
        SceneManager.LoadScene(1);
    }
    private void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //在Unity编译器中结束运行
#else
        Application.Quit();//在可执行程序中结束运行
#endif
    }
}
