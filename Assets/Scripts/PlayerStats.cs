using UnityEngine;
using UnityEngine.UI; 

public class PlayerStats : MonoBehaviour
{
    [Header("Hlavní statistiky")]
    public float maxHealth = 100f;
    public float currentHealth;

    public float maxHunger = 100f;
    public float currentHunger;
    
    public float maxThirst = 100f;
    public float currentThirst;

    [Header("Rychlost ubývání (za sekundu)")]
    public float hungerDecayRate = 1f; 
    public float thirstDecayRate = 1.5f; 
    public float damageFromLackOfNeeds = 5f; 

    [Header("UI Reference")]
    
    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;

    void Start()
    {
        
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;

        UpdateUI(); 
    }

    void Update()
    {
        
        currentHunger -= hungerDecayRate * Time.deltaTime;
        currentThirst -= thirstDecayRate * Time.deltaTime;

        if (currentHunger < 0) currentHunger = 0;
        if (currentThirst < 0) currentThirst = 0;


        if (currentHunger <= 0 || currentThirst <= 0)
        {
            currentHealth -= damageFromLackOfNeeds * Time.deltaTime;
        }

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (healthSlider != null) healthSlider.value = currentHealth / maxHealth;
        if (hungerSlider != null) hungerSlider.value = currentHunger / maxHunger;
        if (thirstSlider != null) thirstSlider.value = currentThirst / maxThirst;
    }

    void Die()
    {
        Debug.Log("Hráč zemřel!");

        // GetComponent<PlayerMovement>().enabled = false;
    }
}