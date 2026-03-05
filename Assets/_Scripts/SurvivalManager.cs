using UnityEngine;
using UnityEngine.Events;

public class SurvivalManager : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth;
    public float healthDepletionRate = 2f;

    [Header("Hunger")]
    public float maxHunger = 100f;
    public float currentHunger;
    public float hungerDepletionRate = 0.5f;

    [Header("Thirst")]
    public float maxThirst = 100f;
    public float currentThirst;
    public float thirstDepletionRate = 0.5f;

    [Header("Warmth")]
    public float maxWarmth = 100f;
    public float currentWarmth;
    public float warmthDepletionRate = 0.5f;

    public float healthPercent => currentHealth / maxHealth;
    public float hungerPercent => currentHunger / maxHunger;
    public float thirstPercent => currentThirst / maxThirst;
    public float warmthPercent => currentWarmth / maxWarmth;

    public UnityEvent OnPlayerDied;

    public DayNightCycle timeManager;

    void Start()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;
        currentWarmth = maxWarmth;
    }
    
    void Update()
    {
        currentHunger -= hungerDepletionRate * Time.deltaTime;
        currentThirst -= thirstDepletionRate * Time.deltaTime;
        if(timeManager != null && timeManager.timeOfDay > 0.3f && timeManager.timeOfDay < 0.7f)
        {
            currentWarmth -= warmthDepletionRate * Time.deltaTime;
        }

        if (currentHunger < 0) currentHunger = 0;
        if (currentThirst < 0) currentThirst = 0;
        if (currentWarmth < 0) currentWarmth = 0;

        if(currentHunger <= 0 || currentThirst <= 0 || currentWarmth <= 0)
        {
            currentHealth -= healthDepletionRate * Time.deltaTime;
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player Died");
            OnPlayerDied.Invoke();
        }
    }

    public void replenishHunger(float amount)
    {
        currentHunger += amount;
        if(currentHunger > maxHunger) currentHunger = maxHunger;
    }

    public void replenishThirst(float amount)
    {
        currentThirst += amount;
        if(currentThirst > maxThirst) currentThirst = maxThirst;
    }

    public void replenishWarmth(float amount)
    {
        currentWarmth += amount;
        if(currentWarmth > maxWarmth) currentWarmth = maxWarmth;
    }

    public void heal(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth) currentHealth = maxHealth;
    }

}