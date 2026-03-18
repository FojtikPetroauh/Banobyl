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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadKeys();
        }
        else
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
}