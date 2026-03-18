using UnityEngine;
using System;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;

    [Header("Current keybinds")]
    public KeyCode interactKey = KeyCode.E;
    public KeyCode eatKey = KeyCode.Alpha1;
    public KeyCode drinkKey = KeyCode.Alpha2;

    void Awake()
    {
        InitializeManager();
    }

    public void InitializeManager()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadKeys();
        }
        else if (instance != this) 
        {
            Destroy(gameObject);
        }
    }

    public void LoadKeys()
    {
        interactKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InteractKey", "E"));
        eatKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("EatKey", "Alpha1"));
        drinkKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("DrinkKey", "Alpha2"));
    }

    public void SaveKeys()
    {
        PlayerPrefs.SetString("InteractKey", interactKey.ToString());
        PlayerPrefs.SetString("EatKey", eatKey.ToString());
        PlayerPrefs.SetString("DrinkKey", drinkKey.ToString());
        PlayerPrefs.Save();
    }

    public string GetCleanKeyName(KeyCode key)
    {
        string keyName = key.ToString();
        keyName = keyName.Replace("Alpha", "");
        keyName = keyName.Replace("Keypad", "Num ");

        return keyName;
    }
}