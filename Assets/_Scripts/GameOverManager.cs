using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; 

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); 
        }
        Time.timeScale = 1f; 
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}