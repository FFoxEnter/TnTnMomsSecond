using UnityEngine;
using System.Collections;

public class RotateObjectToTargetAngle : MonoBehaviour
{
    // GameObject의 회전 속도
    public float rotationSpeed = 10f;

    // 회전 상태를 나타내는 변수
    private bool isRotating = false;

    // 회전 대상 각도
    public float targetPositiveAngle = 10f; // 양수로 변경

    // 회전 각도 비교 정확도
    public float rotationAccuracy = 0.1f;

    // 회전 대기 시간
    public float rotationWaitTime = 0.1f;

    // 회전하는 각도
    private Quaternion targetRotation;

    private void Update()
    {
        // 회전 상태가 true이면 지속적으로 회전을 수행
        if (isRotating)
        {
            RotateTowardsTargetAngle();
        }
    }

    // 타겟 각도까지 회전하는 함수
    private void RotateTowardsTargetAngle()
    {
        // 현재 각도에서 타겟 각도까지 부드럽게 회전
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // 만약 현재 각도와 타겟 각도 사이의 각도가 일정 정확도 이내이면 회전을 멈춤
        if (Quaternion.Angle(transform.rotation, targetRotation) < rotationAccuracy)
        {
            isRotating = false;
        }
    }

    // 시계 방향으로 회전하는 코루틴
    public void RotatePositiveDegreesCoroutine()
    {
        StartCoroutine(RotateCoroutine(Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + targetPositiveAngle, transform.rotation.eulerAngles.z))); // 회전 각도를 현재 각도에 더합니다.
    }

    private IEnumerator RotateCoroutine(Quaternion targetRotation)
    {
        // 대기 시간만큼 대기
        yield return new WaitForSeconds(rotationWaitTime);

        // 회전할 타겟 각도 설정
        this.targetRotation = targetRotation;
        // 회전 상태를 true로 변경하여 연속 회전 시작
        isRotating = true;
    }
}
