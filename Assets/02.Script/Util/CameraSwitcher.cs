using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class CameraSwitcher : MonoBehaviour
{
    public Transform cameraA; // Camera A의 위치
    public Transform cameraB; // Camera B의 위치
    public float transitionDuration = 1.0f; // 전환 지속 시간

    private bool isCameraAToB = false; // Camera A에서 B로 전환하는 여부

    void Start()
    {
        // 버튼 클릭 이벤트 추가
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (!isCameraAToB)
        {
            // Camera A에서 B로 전환
            StartCoroutine(TransitionCamera(cameraA.position, cameraB.position));
        }
        else
        {
            // Camera B에서 A로 전환
            StartCoroutine(TransitionCamera(cameraB.position, cameraA.position));
        }

        // 전환 여부 토글
        isCameraAToB = !isCameraAToB;
    }

    IEnumerator TransitionCamera(Vector3 startPos, Vector3 endPos)
    {
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration)
        {
            // 카메라 이동
            Camera.main.transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / transitionDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 목적지에 도달하도록 보정
        Camera.main.transform.position = endPos;
    }
}
