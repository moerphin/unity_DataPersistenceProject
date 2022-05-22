using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersManager : MonoBehaviour
{
    public static PersManager Instance;
    public string path;
    public string playerName;
    public int score = 0;
    public string prevName;
    public int prevScore;
    // Start is called before the first frame update
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        path = Application.persistentDataPath + "/savegame.json";
    }

    [System.Serializable]
    class SaveData
    {
        public string highName;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highName = playerName;
        data.highScore = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public void LoadScore()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            prevName = data.highName;
            prevScore = data.highScore;
        }
    }
}