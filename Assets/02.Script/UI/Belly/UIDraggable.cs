using UnityEngine;

public class UIDraggable : MonoBehaviour
{
    public Camera targetCamera;
    private bool isDragging;
    private Vector3 mousePosition;

    private void Update()
    {
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        mousePosition = Input.mousePosition;

        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                Debug.Log("Raycast");
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 newPosition = targetCamera.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("isDragging");
        }
    }
}
