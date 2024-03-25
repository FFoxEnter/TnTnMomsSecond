using UnityEngine;

public class RotateObjectToTargetAngle : MonoBehaviour
{
    // GameObject의 회전 속도
    public float rotationSpeed = 10f;

    // 회전 상태를 나타내는 변수
    private bool isRotating = false;

    // 회전 각도
    private float targetAngle = 0f;

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
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // 만약 현재 각도가 타겟 각도와 같다면 회전을 멈춤
        if (transform.rotation.eulerAngles.y == targetAngle)
        {
            isRotating = false;
        }
    }

    // -10도로 Y축 기준으로 회전하는 함수
    public void RotateNegative10Degrees()
    {
        // 회전할 타겟 각도 설정
        targetAngle -= 10f;
        // 회전 상태를 true로 변경하여 연속 회전 시작
        isRotating = true;
    }

    // 0도로 Y축 기준으로 회전하는 함수
    public void RotateToZeroDegrees()
    {
        // 회전할 타겟 각도 설정
        targetAngle = 0f;
        // 회전 상태를 true로 변경하여 연속 회전 시작
        isRotating = true;
    }
}
