using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    public float pixelsPerUnit = 32f; 

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            float roundX = Mathf.Round(smoothedPosition.x * pixelsPerUnit) / pixelsPerUnit;
            float roundY = Mathf.Round(smoothedPosition.y * pixelsPerUnit) / pixelsPerUnit;

            transform.position = new Vector3(roundX, roundY, -10f);
        }
    }
}