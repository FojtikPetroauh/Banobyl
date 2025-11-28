using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Sem přetáhneme hráče
    public float smoothSpeed = 0.125f;  // Rychlost "dobíhání" (čím menší, tím plynulejší)
    public Vector3 offset;         // Odsazení (aby kamera nebyla "v hlavě" hráče, ale nad ním)

    // LateUpdate se spouští až poté, co se všechno ostatní (hráč) pohne.
    // To zabraňuje nepříjemnému cukání obrazu.
    void LateUpdate()
    {
        // 1. Vypočítáme, kde by kamera měla být (pozice hráče + odsazení)
        Vector3 desiredPosition = target.position + offset;

        // 2. Pomocí Lerp (lineární interpolace) vypočítáme plynulý přesun z bodu A do bodu B
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 3. Posuneme kameru
        transform.position = smoothedPosition;
    }
}