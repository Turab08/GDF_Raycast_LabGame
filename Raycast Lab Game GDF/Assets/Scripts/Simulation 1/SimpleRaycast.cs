using TMPro;
using UnityEngine;

public class SimpleRaycast : MonoBehaviour
{
    [SerializeField] TMP_Text outputText;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetectObject();
        }
    }

    void DetectObject()
    {
        // Create a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.Log("Hit object: " + hitInfo.collider.gameObject.name);
            outputText.text = hitInfo.collider.gameObject.name;
        }
    }
}
