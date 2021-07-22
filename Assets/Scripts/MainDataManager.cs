using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class MainDataManager : MonoBehaviour
{
    public static MainDataManager instance;
    public string currentPlayerName;
    public int bestScore;
    public string bestScorePlayerName;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
    }

    class SaveData
    {
        public string currentPlayerName;
        public int bestScore;
        public string bestScorePlayerName;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestScorePlayerName = bestScorePlayerName;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(GetSaveDataPath(), jsonData);
    }

    private void LoadData()
    {
        if (File.Exists(GetSaveDataPath()))
        {
            string jsonData = File.ReadAllText(GetSaveDataPath());
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            bestScore = data.bestScore;
            bestScorePlayerName = data.bestScorePlayerName;
        }
    }

    private string GetSaveDataPath()
    {
        return Application.persistentDataPath + "/savefile.json";
    }
}
