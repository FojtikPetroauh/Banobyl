using UnityEngine;

public class WaterWell : MonoBehaviour
{
    [Header("Settings")]
    public int waterAmount = 1;      
    public float cooldownTime = 60f; 

    public GameObject promptE;       

    private bool isReady = true;     
    private float timer = 0f;
    private bool isPlayerInRange = false;
    
    private SimpleInventory playerInventory;
    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        if (promptE) promptE.SetActive(false);
        isReady = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        if (!isReady)
        {
            timer -= Time.deltaTime; 
            
            if (timer <= 0) 
            {
                isReady = true;
                if (spriteRenderer) spriteRenderer.color = Color.white; 
                
                if (isPlayerInRange && promptE) promptE.SetActive(true);
            }
        }


        if (isPlayerInRange && isReady && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null)
            {
                playerInventory.waterCount += waterAmount; 
                Debug.Log("Water collected, total: " + playerInventory.waterCount);
                
                isReady = false; 
                timer = cooldownTime;
                
                if (promptE) promptE.SetActive(false); 
                if (spriteRenderer) spriteRenderer.color = Color.gray; 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            playerInventory = collision.GetComponent<SimpleInventory>();
            
            if (isReady && promptE) promptE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (promptE) promptE.SetActive(false);
        }
    }
}