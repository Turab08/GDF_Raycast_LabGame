using UnityEngine;
using UnityEngine.Timeline;

public class PlayerRotation : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 direction = (hit.point - transform.position).normalized;
            direction.y = 0;
            
            transform.rotation = Quaternion.LookRotation(direction);

            Debug.DrawRay(transform.position, new Vector3(direction.x, 0, direction.z) * 100, Color.red);
        }
    }
}
