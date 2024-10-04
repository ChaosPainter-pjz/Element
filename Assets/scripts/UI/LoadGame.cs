using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class LoadGame : MonoBehaviour
{
    public float delayTime = 1;

    public void LoadSceneAfterDelay()
    {
        Invoke("Jump", delayTime);
    }
    public void Jump()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
