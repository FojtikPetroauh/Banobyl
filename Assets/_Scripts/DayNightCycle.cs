using UnityEngine;
using UnityEngine.UI; 

public class DayNightCycle : MonoBehaviour
{
    [Header("Settings")]
    public float dayDuration = 30f; 
    public Gradient dayNightColor;   
    
    [Header("Winter settings")]
    public int daysBeforeWinter = 3; 
    public Gradient winterColor;     
    public bool isWinter = false;    

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

        if (daysPassed >= daysBeforeWinter)
        {
            isWinter = true;
        }

        if (overlayImage != null)
        {
            if (isWinter && winterColor != null)
            {
                overlayImage.color = winterColor.Evaluate(timeOfDay); 
            }
            else
            {
                overlayImage.color = dayNightColor.Evaluate(timeOfDay); 
            }
        }
    }
}