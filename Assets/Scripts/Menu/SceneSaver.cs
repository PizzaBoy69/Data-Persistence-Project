using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SceneSaver : MonoBehaviour
{
    public static SceneSaver Instance;
    public string playerName;
    public string bestName;
    public int highScore;
    
    [System.Serializable]
    class SaveData {
    public string recordName;
    public int recordPoints;
    }

private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        LoadRecord();
    }

    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.recordName = bestName;
        data.recordPoints = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestName = data.recordName;
            highScore = data.recordPoints;
        }
    }
}
