using UnityEngine;
using TMPro; 

public class HUDHints : MonoBehaviour
{
    public TMP_Text eatHintText;
    public TMP_Text drinkHintText;

    void Update()
    {
        if (KeyManager.instance != null)
        {
            if (eatHintText != null) 
                eatHintText.text = "[ " + KeyManager.instance.GetCleanKeyName(KeyManager.instance.eatKey) + " ]";
                
            if (drinkHintText != null) 
                drinkHintText.text = "[ " + KeyManager.instance.GetCleanKeyName(KeyManager.instance.drinkKey) + " ]";
        }
    }
}