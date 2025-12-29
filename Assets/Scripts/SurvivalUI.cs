using UnityEngine;
using UnityEngine.UI; 

public class SurvivalUI : MonoBehaviour
{
    [Header("UI Obrázky (nastavit Image Type: Filled)")]
    public Image healthImage;
    public Image hungerImage;
    public Image thirstImage;

    [Header("Reference")]
    public SurvivalManager survivalManager; 
    

    void Update()
    {
        
        if (survivalManager != null)
        {
            hungerImage.fillAmount = survivalManager.HungerPercent;
            thirstImage.fillAmount = survivalManager.ThirstPercent;
        }

        
        if (GameManager.gameManager != null && GameManager.gameManager._playerHealth != null)
        {
            float currentHp = GameManager.gameManager._playerHealth.Health;
            float maxHp = GameManager.gameManager._playerHealth.MaxHealth;
            
            healthImage.fillAmount = currentHp / maxHp;
        }
    }
}