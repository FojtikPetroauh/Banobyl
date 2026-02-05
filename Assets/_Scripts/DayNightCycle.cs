using UnityEngine;
using UnityEngine.UI; 

public class DayNightCycle : MonoBehaviour
{
    [Header("Nastavení")]
    public float dayDuration = 30f; 
    public Gradient dayNightColor;   
    
    [Header("Propojení")]
    public Image overlayImage;       

    [Header("Info")]
    public float timeOfDay;          
    public int daysPassed = 0;     

    private float timer;

    void Update()
    {
        
        timer += Time.deltaTime;


        timeOfDay = timer / dayDuration;

        if (timer >= dayDuration)
        {
            timer = 0;
            daysPassed++;
        }

        if (overlayImage != null)
        {
            overlayImage.color = dayNightColor.Evaluate(timeOfDay);
        }
    }
}