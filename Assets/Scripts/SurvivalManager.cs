using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class SurvivalManager : MonoBehaviour
{
    [Header("Hunger")]
    [SerializeField] private float _maxHunger = 100f;
    [SerializeField] private float _hungerDepletionRate = 1f;
    private float _currentHunger;
    public float HungerPercent => _currentHunger / _maxHunger;

    [Header("Thirst")]
    [SerializeField] private float _maxThirst = 100f;
    [SerializeField] private float _thirstDepletionRate = 1f;
    private float _currentThirst;
    public float ThirstPercent => _currentThirst / _maxThirst;

    [Header("Damage Over Time")]
    [SerializeField] private float _damageInterval = 1f;
    [SerializeField] private int _damageAmount = 1;
    private float _damageTimer = 0f;

    // Player References
    // put the health system references here
    public static UnityAction OnPlayerDied;

    private void Start()
    {
        _currentHunger = _maxHunger;
        _currentThirst = _maxThirst;
    }

    private void Update()
    {
        _currentHunger -= _hungerDepletionRate * Time.deltaTime;
        _currentThirst -= _thirstDepletionRate * Time.deltaTime;

        if (_currentHunger < 0) _currentHunger = 0;
        if (_currentThirst < 0) _currentThirst = 0;

        if (_currentHunger <= 0 || _currentThirst <= 0)
        {
            _damageTimer += Time.deltaTime;
            if (_damageTimer >= _damageInterval)
            {
                _damageTimer = 0f;

                // damage player
                GameManager.gameManager._playerHealth.DmgUnit(_damageAmount);

                //update HB UI
                PlayerBehavior player = FindObjectOfType<PlayerBehavior>();
                if (player != null)
                {
                    player.UpdateHealthBar();
                }

                // check death
                if (GameManager.gameManager._playerHealth.Health <= 0)
                {
                    OnPlayerDied?.Invoke();
                }
            }
        }
        else
        {
            _damageTimer = 0f;
        }
    }

    private Dictionary<FoodType, int> _foodInventory = new Dictionary<FoodType, int>();

    [SerializeField] private List<FoodItem> availableFoods;

    public static System.Action OnInventoryChanged;

    public void AddFood(FoodItem food, int amount)
    {
        if (_foodInventory.ContainsKey(food.type))
        {
            _foodInventory[food.type] += amount;
        }
        else
        {
            _foodInventory[food.type] = amount;
        }
        OnInventoryChanged?.Invoke();
    }

    public bool UseFood(FoodType type)
    {
        if (_foodInventory.ContainsKey(type) && _foodInventory[type] > 0)
        {
            _foodInventory[type]--;

            FoodItem food = availableFoods.Find(f => f.type == type);
            if (food != null)
            {
                ReplenishHungerThirst(food.hungerRestore, food.thirstRestore);

                if (food.hpRestore > 0)
                {
                    GameManager.gameManager._playerHealth.HealUnit(food.hpRestore);
                    PlayerBehavior player = FindObjectOfType<PlayerBehavior>();
                    if (player != null)
                        player.UpdateHealthBar();
                }
            }
            
            OnInventoryChanged?.Invoke();
            return true;
        }
        return false;
    }



    public int GetFoodCount(FoodType type)
    {
        return _foodInventory.ContainsKey(type) ? _foodInventory[type] : 0;
    }

    public void ReplenishHungerThirst(float hungerAmount, float thirstAmount)
    {
        Debug.Log($"Before Replenish: Hunger={_currentHunger}, Thirst={_currentThirst}");
        Debug.Log($"Adding: Hunger={hungerAmount}, Thirst={thirstAmount}");

        _currentHunger += hungerAmount;
        _currentThirst += thirstAmount;

        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;
        if (_currentThirst > _maxThirst) _currentThirst = _maxThirst;

        Debug.Log($"After Replenish: Hunger={_currentHunger}, Thirst={_currentThirst}");
    }
}


