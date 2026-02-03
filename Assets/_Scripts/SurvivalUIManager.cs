using UnityEngine;
using UnityEngine.UI;

public class SurvivalUIManager : MonoBehaviour
{
    public SurvivalManager survivalManager;

    public Image healthBar;
    public Image hungerBar;
    public Image thirstBar;
    public Image warmthBar;

    void Update()
    {
        if(healthBar) healthBar.fillAmount = survivalManager.healthPercent;
        if(hungerBar) hungerBar.fillAmount = survivalManager.hungerPercent;
        if(thirstBar) thirstBar.fillAmount = survivalManager.thirstPercent;
        if(warmthBar) warmthBar.fillAmount = survivalManager.warmthPercent;
    }
}