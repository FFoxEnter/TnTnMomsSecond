using UnityEngine;
using UnityEngine.EventSystems;

public class DragArea : MonoBehaviour, IDragHandler
{
    public GameObject RotatePanel;
    public GameObject RotateObj;

    public float rotationSpeed = 0.1f;

    public void OnDrag(PointerEventData eventData)
    {
        if (RotatePanel.activeSelf)
        {
            Vector2 dragDelta = eventData.position;
            float rotationY = dragDelta.x * rotationSpeed;

            RotateObj.transform.rotation = Quaternion.Euler(0, -rotationY, 0);
        }            
    }
}
