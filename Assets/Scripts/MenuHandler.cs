using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameField;

    public void StartGame()
    {
        string playerName = playerNameField.text;
        if (string.IsNullOrWhiteSpace(playerName))
        {
            playerName = "Guest Player";
        }

        DataManager.Instance.PlayerName = playerName;
        Debug.Log(playerName);

        MH_LoadScene(1);
    }

    public void BackToMenu()
    {
        MH_LoadScene(0);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void MH_LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
