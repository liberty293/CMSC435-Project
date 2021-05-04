using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
    public Controls control;
    public Music dificulty;
    string keys = "keys";
    bool setControls;

    private void Awake()
    {
        LoadData();
    }
    public void SaveData()
    {
        string key = JsonUtility.ToJson(control);
        PlayerPrefs.SetString(keys, key);

        PlayerPrefs.SetString("difficulty", dificulty.Hardness);
    }

    public void LoadData()
    {
        if(PlayerPrefs.HasKey(keys))
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(keys), control);
        if (PlayerPrefs.HasKey("difficulty"))
            dificulty.Hardness = PlayerPrefs.GetString("difficulty");
        else dificulty.Hardness = "easy";
    }
}
