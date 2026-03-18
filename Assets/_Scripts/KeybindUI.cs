using UnityEngine;
using TMPro; 

public class KeybindUI : MonoBehaviour
{
    [Header("Button Texts")]
    public TMP_Text interactText; 
    public TMP_Text eatText;      
    public TMP_Text drinkText;    

    private bool isWaitingForKey = false;
    private string keyToRebind = "";

    void Start()
    {
        Invoke("DelayedUpdateUI", 0.1f);
    }

    public void StartRebind(string actionName)
    {
        if (isWaitingForKey) return; 

        isWaitingForKey = true;
        keyToRebind = actionName;

        if (actionName == "Interact") interactText.text = "?";
        else if (actionName == "Eat") eatText.text = "?";
        else if (actionName == "Drink") drinkText.text = "?";
    }

    void OnGUI()
    {
        if (isWaitingForKey)
        {
            Event e = Event.current;
            
            if (e.isKey && e.type == EventType.KeyDown && e.keyCode != KeyCode.None)
            {
                AssignKey(e.keyCode);
            }
        }
    }

    private void AssignKey(KeyCode newKey)
    {
        if (keyToRebind == "Interact") KeyManager.instance.interactKey = newKey;
        else if (keyToRebind == "Eat") KeyManager.instance.eatKey = newKey;
        else if (keyToRebind == "Drink") KeyManager.instance.drinkKey = newKey;

        KeyManager.instance.SaveKeys(); 
        
        isWaitingForKey = false; 
        UpdateUI(); 
    }

    public void UpdateUI()
    {
        if (interactText != null) interactText.text = KeyManager.instance.GetCleanKeyName(KeyManager.instance.interactKey);
        if (eatText != null) eatText.text = KeyManager.instance.GetCleanKeyName(KeyManager.instance.eatKey);
        if (drinkText != null) drinkText.text = KeyManager.instance.GetCleanKeyName(KeyManager.instance.drinkKey);
    }

    private void DelayedUpdateUI()
    {
        if (KeyManager.instance != null)
        {
             UpdateUI(); 
        }
        else
        {
             Debug.LogWarning("KeyManager didn't load in time!!!.");
             KeyManager km = FindFirstObjectByType<KeyManager>();
             if(km != null)
             {
                 km.InitializeManager();
                 UpdateUI();
             }
        }
    }

}