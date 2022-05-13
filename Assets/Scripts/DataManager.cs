using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    [SerializeField] private MenuUIHandler menuUI;
    public static DataManager dataManagerInstance;

    int bestScore;
    string playerName;
    string bestScoreName;

    private void Awake()
    {
        if (dataManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        dataManagerInstance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }
    /*
    public int GetScore()
    {
        return score;
    }

    public void SetScore()
    {
        score = GetScore();
    }*/

    public int GetBestScore()
    {
        return bestScore;
    }

    public void SetBestScore(int score)
    {
        bestScore = score;
    }

    public string GetBestScoreName()
    {
        return bestScoreName;
    }

    public void SetBestScoreName(string name)
    {
        bestScoreName = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    [System.Serializable]
    class PlayerData
    {
        public int playerScore;
        public string playerName;
    }

    public void SaveData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        PlayerData data = new PlayerData();

        data.playerScore = bestScore;
        data.playerName = bestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            bestScoreName = data.playerName;
            bestScore = data.playerScore;
        }
    }

    public void DeleteData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        File.Delete(path);
        bestScore = 0;
        bestScoreName = "";
    }
}
