using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public enum ItemType { Berries, Water, Wood }
    
    [Header("Resource settings")]
    public ItemType type;
    public int amount = 1;
    public GameObject visualPrompt; // objekt na pickup (E)

    private bool isPlayerInRange;
    private SimpleInventory playerInventory;

    void Start()
    {
        if (visualPrompt) visualPrompt.SetActive(false);
    }

    void Update()
    {
        
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            playerInventory = collision.GetComponent<SimpleInventory>();
            if (visualPrompt) visualPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (visualPrompt) visualPrompt.SetActive(false);
        }
    }

    void PickUp()
    {
        if (playerInventory != null)
        {
            playerInventory.AddResource(type.ToString(), amount);
            Destroy(gameObject);
        }
    }
}