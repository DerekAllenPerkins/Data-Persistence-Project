using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    // Get UI References
    public InputField playerInputField;

    void Awake()
    {
        
    }

    public void StartGame()
    {
        if (!CheckPlayerNameEntry())
        {
            PlayerDataHandler.Instance.playerName = playerInputField.text;
            PlayerDataHandler.Instance.playerScore = 0;

            SceneManager.LoadScene(1);
        }
        
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private bool CheckPlayerNameEntry()     // Checks if the input is null or empty. Done this way to make it easy to add exception handling later.
    {
        bool isVoid = true;

        if (playerInputField.text != null ||  playerInputField.text != "")
            isVoid = false;

        return isVoid;
    }

    
}
