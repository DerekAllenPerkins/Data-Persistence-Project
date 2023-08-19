using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerDataHandler : MonoBehaviour
{

    public static PlayerDataHandler Instance;

    public string playerName;
    public int playerScore;

    public string bestName;
    public int bestScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;

        LoadHighScore();

        DontDestroyOnLoad(gameObject);
    }    

    [System.Serializable]
    class HighScore
    {
        public string highName;
        public string highScore;
    }

    public void CheckScore()
    {
        if (playerScore >= bestScore)
            SaveHighScore();
    }

    public void SaveHighScore()
    {
        HighScore hs = new HighScore();

        hs.highName = playerName;
        hs.highScore = playerScore.ToString();

        string json = JsonUtility.ToJson(hs);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            HighScore hs = JsonUtility.FromJson<HighScore>(json);
            bestName = hs.highName;
            bestScore = Convert.ToInt32(hs.highScore);
        }
        

    }
    
}
