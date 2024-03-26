using UnityEngine;
// 메인 카메라에서 RayCast를 사용하여 충돌을 감지하고 BearPack의 BellyPackOn 메서드를 호출하는 스크립트
public class CameraRaycast : MonoBehaviour
{
    void Update()
    {
        // 마우스 왼쪽 버튼이 눌린 경우
        if (Input.GetMouseButtonDown(0))
        {
            // 메인 카메라에서 Ray를 쏩니다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray가 어떤 물체와 충돌했는지 확인합니다.
            if (Physics.Raycast(ray, out hit))
            {
                // 충돌한 물체가 BearPack인 경우
                if (hit.collider.CompareTag("BearPack"))
                {
                    // BearPack 스크립트의 BellyPackOn 메서드를 호출하여 상태를 변경합니다.
                    hit.collider.GetComponent<BearPack>().BellyPackOn();
                }
            }
        }
    }
}