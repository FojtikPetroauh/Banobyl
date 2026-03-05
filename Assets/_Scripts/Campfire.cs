using UnityEngine;

public class Campfire : MonoBehaviour
{
    [Header("Settings")]
    public float burnDuration = 60f; 
    public float warmthReplenishRate = 15f; 

    public GameObject fireVisuals; 
    public GameObject promptE;     

    private bool isLit = false;
    private float burnTimer = 0f;
    private bool isPlayerInRange = false;

    private SimpleInventory playerInventory;
    private SurvivalManager playerSurvival; 

    void Start()
    {
        isLit = false;
        if (fireVisuals) fireVisuals.SetActive(false);
        if (promptE) promptE.SetActive(false);
    }

    void Update()
    {
        
        if (isPlayerInRange && !isLit && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null && playerInventory.woodCount > 0)
            {
                playerInventory.woodCount--; 
                LightFire(); 
            }
            else
            {
                Debug.Log("Not enough wood!");
            }
        }

        
        if (isLit)
        {
            burnTimer -= Time.deltaTime; 

            
            if (isPlayerInRange && playerSurvival != null)
            {
                
                playerSurvival.replenishWarmth(warmthReplenishRate * Time.deltaTime);
            }

            if (burnTimer <= 0)
            {
                ExtinguishFire();
            }
        }
    }

    private void LightFire()
    {
        isLit = true;
        burnTimer = burnDuration;
        if (fireVisuals) fireVisuals.SetActive(true); 
        if (promptE) promptE.SetActive(false); 
    }

    private void ExtinguishFire()
    {
        isLit = false;
        if (fireVisuals) fireVisuals.SetActive(false); 
        if (isPlayerInRange && promptE) promptE.SetActive(true); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            playerInventory = collision.GetComponent<SimpleInventory>();
            playerSurvival = collision.GetComponent<SurvivalManager>(); 
            
            if (!isLit && promptE) promptE.SetActive(true);
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