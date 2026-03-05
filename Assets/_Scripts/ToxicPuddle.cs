using UnityEngine;

public class ToxicPuddle : MonoBehaviour
{
    [Header("Settings")]
    public float damagePerSecond = 10f; 

    private bool isPlayerInside = false;
    private SurvivalManager playerSurvival;

    void Update()
    {
        if (isPlayerInside && playerSurvival != null)
        {
            playerSurvival.currentHealth -= damagePerSecond * Time.deltaTime;
            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = true;
            playerSurvival = collision.GetComponent<SurvivalManager>();
            Debug.Log("Entered toxic puddle.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = false;
            playerSurvival = null;
            Debug.Log("Left toxic puddle.");
        }
    }
}