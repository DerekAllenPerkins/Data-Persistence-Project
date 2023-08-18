using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using System.IO;

public class PlayerDataHandler : MonoBehaviour
{

    public static PlayerDataHandler Instance;

    public string playerName;
    public int playerScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }    

    [Serializable]
    class HighScore
    {
        public string bestName;
        public int highScore;
    }

    public void SaveHighScore()
    {

    }

    public void LoadHighScore()
    {

    }
    
}
