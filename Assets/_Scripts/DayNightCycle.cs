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

    [Header("Music")]
    public AudioSource dayAudio;         
    public AudioSource nightAudio;       
    public float maxMusicVolume = 0.3f;  

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
                overlayImage.color = winterColor.Evaluate(timeOfDay); 
            else
                overlayImage.color = dayNightColor.Evaluate(timeOfDay); 
        }

        if (dayAudio != null && nightAudio != null)
        {
            bool isNight = (timeOfDay > 0.4f && timeOfDay < 0.8f);

            float fadeSpeed = 0.5f * Time.deltaTime;

            if (isNight)
            {
                if (nightAudio.volume < maxMusicVolume) nightAudio.volume += fadeSpeed;
                if (dayAudio.volume > 0f) dayAudio.volume -= fadeSpeed;
            }
            else
            {
                if (dayAudio.volume < maxMusicVolume) dayAudio.volume += fadeSpeed;
                if (nightAudio.volume > 0f) nightAudio.volume -= fadeSpeed;
            }
        }
    }
}