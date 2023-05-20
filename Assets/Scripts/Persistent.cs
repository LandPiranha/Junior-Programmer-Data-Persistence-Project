using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Persistent : MonoBehaviour
{
    public static Persistent Instance;

    public string playerName;
    private int highScore;
    private string highScorePlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadUserInfo();
    }

    public void UpdateHighScore(int newScore)
    {
        if(newScore > highScore)
        {
            highScore = newScore;
            highScorePlayerName = playerName;
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public string GetHighScoreName()
    {
        return highScorePlayerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveUserInfo()
    {
        SaveData data = new SaveData();
        data.highScorePlayerName = highScorePlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUserInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highScorePlayerName;
            highScore = data.highScore;
        }
        else
        {
            highScorePlayerName = "?";
            highScore = 0;
        }
    }
}
