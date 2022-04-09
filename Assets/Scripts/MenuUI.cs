using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class MenuUI : MonoBehaviour
{
    public static MenuUI Instance;

    public string playerName;
    public int highscore;

    public Text HighScoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayer();
    }

       
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highscore;
    }

    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highscore = data.highscore;

            HighScoreText.text = $"HighScore : {playerName}{highscore}";
        }
    }


}
