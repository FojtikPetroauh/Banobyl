using UnityEngine;

public class ToxicPuddle : MonoBehaviour
{
    [Header("Settings")]
    public float damagePerSecond = 10f; 

    [Header("Audio")]
    private AudioSource puddleAudio;

    [Header("Audio settings")]
    public float soundCooldown = 1.5f;
    private float lastSoundTime = -100f;

    private bool isPlayerInside = false;
    private SurvivalManager playerSurvival;

    void Start()
    {
        puddleAudio = GetComponent<AudioSource>();
    }
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
            if(puddleAudio != null && Time.time >= lastSoundTime + soundCooldown)
            {
               puddleAudio.Play(); 
               lastSoundTime = Time.time;
            } 
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