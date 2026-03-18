using UnityEngine;
using System.Collections; 

public class CollectableItem : MonoBehaviour
{
    public enum ItemType { Berries, Water, Wood }
    
    [Header("Settings")]
    public ItemType type;
    public int amount = 1;
    public GameObject visualPrompt; 

    [Header("Respawn")]
    public bool canRespawn = true;
    public float respawnTime = 180f; 

    private bool isPlayerInRange;
    private bool isCollected = false; 
    private SimpleInventory playerInventory;

    // schovat objekt
    private SpriteRenderer spriteRenderer;
    private Collider2D itemCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<Collider2D>();
        
        if (visualPrompt) visualPrompt.SetActive(false);
    }

    void Update()
    {
        if (!isCollected && isPlayerInRange && Input.GetKeyDown(KeyManager.instance.interactKey))
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
            if (!isCollected && visualPrompt) visualPrompt.SetActive(true);
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
            
            if (canRespawn)
            {
                StartCoroutine(RespawnRoutine());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    // časovač
    IEnumerator RespawnRoutine()
    {
        isCollected = true;
        
        spriteRenderer.enabled = false;
        itemCollider.enabled = false;
        if (visualPrompt) visualPrompt.SetActive(false);

        yield return new WaitForSeconds(respawnTime);

        spriteRenderer.enabled = true;
        itemCollider.enabled = true;
        isCollected = false;
    }
}