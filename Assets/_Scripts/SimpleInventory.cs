using UnityEngine;

public class SimpleInventory : MonoBehaviour
{
    [Header("Resources")]
    public int berriesCount = 0;
    public int waterCount = 0;
    public int woodCount = 0;

    public SurvivalManager survivalManager;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        if (Input.GetKeyDown(KeyManager.instance.eatKey))
        {
            if(berriesCount > 0)
            {
                berriesCount--;
                survivalManager.replenishHunger(20f);
                Debug.Log("You ate a berry. Remaining: " + berriesCount);
            }
        }

        if (Input.GetKeyDown(KeyManager.instance.drinkKey))
        {
            if(waterCount > 0)
            {
                waterCount--;
                survivalManager.replenishThirst(50f);
                Debug.Log("You drank water. Remaining: " + waterCount);
            }
        }
    }


    public void AddResource(string type, int amount)
    {
        switch (type)
        {
            case "Berries":
                berriesCount += amount;
                break;
            case "Water":
                waterCount += amount;
                break;
            case "Wood":
                woodCount += amount;
                break;
        }
        Debug.Log($"Picked up: {type}, total: {berriesCount}/{waterCount}/{woodCount}");
    }
}