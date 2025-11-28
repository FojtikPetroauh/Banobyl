using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Rychlost pohybu, kterou můžeš měnit v Unity
    public Rigidbody2D rb;       // Odkaz na fyzikální komponentu

    Vector2 movement;            // Ukládá směr pohybu (X a Y)

    // Update se volá jednou za snímek (zde čteme klávesnici)
    void Update()
    {
        // Získá vstup z klávesnice (WASD nebo šipky)
        // Vrátí číslo mezi -1 a 1 (např. -1 je vlevo, 1 je vpravo)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate se používá pro fyziku (pohyb postavy)
    void FixedUpdate()
    {
        // Pohneme s Rigidbody na novou pozici
        // Aktuální pozice + směr * rychlost * čas
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}