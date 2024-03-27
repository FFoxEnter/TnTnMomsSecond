using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float maxOffset = 0.02f; // 최대 이동 범위
    public float minSpeed = 0.0001f; // 최소 속도
    public float maxSpeed = 0.0004f; // 최대 속도
    public float minChangeInterval = 0.01f; // 최소 변경 간격
    public float maxChangeInterval = 0.03f; // 최대 변경 간격
    public float damping = 2.0f; // 감쇠 계수

    private float targetHeight;
    private float originalY;
    private float moveSpeed;
    private Vector3 velocity;

    void Start()
    {
        originalY = transform.position.y;
        SetNewTargetHeight();
        SetNewMoveSpeed();
    }

    void Update()
    {
        // 목표 높이까지 부드럽게 이동
        float newY = Mathf.SmoothDamp(transform.position.y, targetHeight, ref velocity.y, damping);

        // 이동된 새로운 위치 설정
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // 목표 높이에 도달하면 새로운 목표 높이와 속도 설정
        if (Mathf.Abs(newY - targetHeight) < 0.01f)
        {
            SetNewTargetHeight();
            SetNewMoveSpeed();
        }
    }

    void SetNewTargetHeight()
    {
        float offset = Random.Range(-maxOffset, maxOffset); // 랜덤한 이동 범위 설정
        targetHeight = originalY + offset;
    }

    void SetNewMoveSpeed()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed); // 랜덤한 속도 설정
    }
}
