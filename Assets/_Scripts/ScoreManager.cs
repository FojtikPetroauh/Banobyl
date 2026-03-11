using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;          
    public TextMeshProUGUI gameOverTimeText;  
    public TextMeshProUGUI highScoreText;     

    private float timer = 0f;
    private bool isPlayerAlive = true;
    private float bestTime = 0f;              

    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("PersonalBest", 0f);
    }

    void Update()
    {
        if (isPlayerAlive)
        {
            timer += Time.deltaTime;
            UpdateTimeUI();
        }
    }

    private void UpdateTimeUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeText != null)
        {
            timeText.text = "Time alive: " + timeString;
        }
    }

    public void StopTimerAndShowScore()
    {
        isPlayerAlive = false;

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        string finalTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (gameOverTimeText != null)
        {
            gameOverTimeText.text = "Time survived: " + finalTime;
        }

        
        if (timer > bestTime)
        {
            bestTime = timer; 
            
            PlayerPrefs.SetFloat("PersonalBest", bestTime);
            PlayerPrefs.Save(); 
            
            Debug.Log("New record saved!");
        }

        int bestMinutes = Mathf.FloorToInt(bestTime / 60F);
        int bestSeconds = Mathf.FloorToInt(bestTime % 60F);
        string bestTimeString = string.Format("{0:00}:{1:00}", bestMinutes, bestSeconds);

        if (highScoreText != null)
        {
            highScoreText.text = "Personal best: " + bestTimeString;
        }
    }
}