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
        public int bestScore1;
        public int bestScore2;
        public string highScoreName1;
        public string highScoreName2;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore1 = bestScore1;
        data.bestScore2 = bestScore2;
        data.highScoreName1 = highScoreName1;
        data.highScoreName2 = highScoreName2;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore1 = data.bestScore1;
            bestScore2 = data.bestScore2;
            highScoreName1 = data.highScoreName1;
            highScoreName2 = data.highScoreName2;
        }
    }
}
