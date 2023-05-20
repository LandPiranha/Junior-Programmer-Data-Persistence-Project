using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField inputText;

    public void MenuStart()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuQuit()
    {
        Persistent.Instance.SaveUserInfo();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void RecordPlayerName()
    {
        Persistent.Instance.playerName = inputText.text;
    }
}
