using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int bestScore1 = 0;
    public int bestScore2 = 0;
    public string highScoreName1;
    public string highScoreName2;
    public string userName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string highScoreName;
    }

    public void SaveScore1()
    {
        SaveData data = new SaveData
        {
            bestScore = bestScore1,
            highScoreName = highScoreName1
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile1.json", json);
    }

    public void SaveScore2()
    {
        SaveData data = new SaveData
        {
            bestScore = bestScore2,
            highScoreName = highScoreName2
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile2.json", json);
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile1.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore1 = data.bestScore;
            highScoreName1 = data.highScoreName;
        }

        path = Application.persistentDataPath + "/savefile2.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore2 = data.bestScore;
            highScoreName2 = data.highScoreName;
        }
    }
}
