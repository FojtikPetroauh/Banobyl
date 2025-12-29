using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] HealthBar _healthBar;

    private void OnEnable()
    {
        SurvivalManager.OnPlayerDied += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        SurvivalManager.OnPlayerDied -= HandlePlayerDeath;
    }

    void Start()
    {
        _healthBar.SetMaxHealth(GameManager.gameManager._playerHealth.MaxHealth);
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player has died!");
        FindObjectOfType<DeathMenuUI>().ShowDeathMenu();
    }

   // private IEnumerator RestartGameWithDelay(float delay)
   // {
   //     yield return new WaitForSeconds(delay);
   //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   // }


    [SerializeField] private SurvivalManager survivalManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseFood(FoodType.Berry);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseFood(FoodType.Water);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseFood(FoodType.Medkit);
        }
        

        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerTakeDmg(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }

    private void UseFood(FoodType type)
    {
        if (survivalManager.UseFood(type))
        {
            Debug.Log($"Used {type}");
        }
        else
        {
            Debug.Log($"No {type} in inventory!");
        }
    }


    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }

}