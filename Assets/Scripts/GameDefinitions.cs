using UnityEngine;

public enum FoodType
{
    Berry,
    Water,
    Medkit
}

[System.Serializable]
public class FoodItem
{
    public string name;      
    public FoodType type;    
    public float hungerRestore; 
    public float thirstRestore; 
    public int hpRestore;       
}