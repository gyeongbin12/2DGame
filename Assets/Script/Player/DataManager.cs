using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int score;
}

public class DataManager : MonoBehaviour
{
    public Data data = new Data();

    readonly int value;

    public DataManager()
    {
        value = 3000;
    }

    void Awake()
    {
        // Load();

        data.score++;
        Save();
    }

    void Update()
    {
        
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(data);

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
        string code = System.Convert.ToBase64String(bytes);

        File.WriteAllText(Application.dataPath + "/GameData.json", code);
    }

    public void Load()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/GameData.json");

        byte[] bytes = System.Convert.FromBase64String(jsonData);
        string code = System.Text.Encoding.UTF8.GetString(bytes);

        data = JsonUtility.FromJson<Data>(code);    
    }
}
