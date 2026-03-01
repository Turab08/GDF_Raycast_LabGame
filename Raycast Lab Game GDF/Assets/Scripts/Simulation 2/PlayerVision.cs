using UnityEngine;
using UnityEngine.Timeline;

public class Player: MonoBehaviour
{
    public float maxDistance = 100f;
    public LayerMask layerMask;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
        {
            // Calculate the direction from the player to the hit point and set the y component to 0 to keep it horizontal
            Vector3 direction = (hit.point - transform.position).normalized;
            direction.y = 0;

            // Draw a ray in the Scene view for visualization
            Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
        }
    }
}
