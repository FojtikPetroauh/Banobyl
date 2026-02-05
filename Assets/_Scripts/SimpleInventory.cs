using UnityEngine;

public class SimpleInventory : MonoBehaviour
{
    [Header("Resources")]
    public int berriesCount = 0;
    public int waterCount = 0;
    public int woodCount = 0;

    
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