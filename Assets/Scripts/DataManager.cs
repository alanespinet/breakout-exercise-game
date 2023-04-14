using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEditor.PackageManager;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;

    public string HighScore_PlayerName;
    public int Score;

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class ScoreInfo
    {
        public string playerName;
        public int score;
    }

    public void SaveData()
    {
        ScoreInfo info = new ScoreInfo();
        info.playerName = HighScore_PlayerName;
        info.score = Score;

        string json = JsonUtility.ToJson(info);
        File.WriteAllText(Application.persistentDataPath + "/hscore.json", json);
    }

    public void LoadData()
    {
        string file = Application.persistentDataPath + "/hscore.json";
        if(File.Exists(file))
        {
            string json = File.ReadAllText(file);
            ScoreInfo info = JsonUtility.FromJson<ScoreInfo>(json);

            HighScore_PlayerName = info.playerName;
            Score = info.score;
        }
        else
        {
            HighScore_PlayerName = "No High Score";
            Score = 0;
        }
    }
}
