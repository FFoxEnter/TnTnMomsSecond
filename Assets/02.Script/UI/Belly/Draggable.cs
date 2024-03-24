using UnityEngine;

public class Draggable : MonoBehaviour
{
    public Camera targetCamera;
    public GameObject stopDragObject; // 드래그를 멈출 오브젝트
    private GameObject objectToDrag;
    private bool isDragging = false;
    private Vector3 originalPosition; // 이전 드래그 위치 저장 변수
     
    void Update()
    {
        // 마우스 왼쪽 버튼을 클릭했을 때 오브젝트가 있으면 해당 오브젝트를 드래그 대상으로 설정
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Draggable")) // 드래그 가능한 오브젝트인지 확인
                {
                    objectToDrag = hit.collider.gameObject;
                    isDragging = true; // 드래그 상태로 설정

                    // 이전 드래그 위치 저장
                    originalPosition = objectToDrag.transform.position;
                }
            }
        }

        // 드래그 중일 때
        if (isDragging)
        {
            // 마우스 커서의 현재 위치를 세계 좌표로 변환
            Plane plane = new Plane(Vector3.forward, objectToDrag.transform.position);
            Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
            float distance;

            // 마우스 커서와 평면 간의 교차점을 계산하여 오브젝트를 해당 위치로 이동
            if (plane.Raycast(ray, out distance))
            {
                Vector3 newPosition = ray.GetPoint(distance);
                objectToDrag.transform.position = new Vector3(newPosition.x, newPosition.y, objectToDrag.transform.position.z);
            }

            // stopDragObject 위에 마우스가 있으면 드래그 상태를 해제
            if (stopDragObject != null && IsMouseOverObject(stopDragObject))
            {
                isDragging = false;
            }
        }

        // 마우스 왼쪽 버튼을 떼었을 때 드래그 상태를 해제하고, 이전 드래그 위치로 복원
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            if (objectToDrag != null)
            {
                objectToDrag.transform.position = originalPosition;
            }
        }
    }

    // 특정 오브젝트 위에 마우스가 있는지 확인하는 함수
    bool IsMouseOverObject(GameObject gameObject)
    {
        RaycastHit hit;
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject;
    }
}