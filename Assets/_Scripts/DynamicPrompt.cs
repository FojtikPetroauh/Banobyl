using UnityEngine;
using TMPro;

public class DynamicPrompt : MonoBehaviour
{
    private TMP_Text myText;

    void Start()
    {
        myText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (KeyManager.instance != null && myText != null)
        {
            myText.text = "[ " + KeyManager.instance.GetCleanKeyName(KeyManager.instance.interactKey) + " ]";
        }
    }
}