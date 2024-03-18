using System.Collections;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotationSpeed = 180f; // 회전 속도
    private float waitTime = 6f; // 대기 시간

    void Start()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            float elapsedTime = 0f;
            Quaternion startingRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, -180, 0));

            while (elapsedTime < 1f)
            {
                transform.rotation = Quaternion.Lerp(startingRotation, targetRotation, elapsedTime / 1f);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        StartCoroutine(Rotate());
    }


}
