using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;       

    private Animator anim;
    private Vector2 movement;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (anim != null)
        {
            if (movement.x != 0 || movement.y != 0)
            {
                anim.SetFloat("MoveX", movement.x);
                anim.SetFloat("MoveY", movement.y);
                
                anim.speed = 1f; 
            }
            else
            {
                anim.speed = 0f; 
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}