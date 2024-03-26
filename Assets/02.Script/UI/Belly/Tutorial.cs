using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리 추가

public class Tutorial : MonoBehaviour
{
    // UI Button을 참조할 변수
    public Button myButton;

    void Start()
    {
        // UI Button이 없는 경우, 로그를 출력하고 함수를 종료합니다.
        if (myButton == null)
        {
            Debug.LogError("UI Button을 찾을 수 없습니다!");
            return;
        }

        // UI Button의 onClick 이벤트에 특정 메서드를 추가합니다.
        myButton.onClick.AddListener(OnMyButtonClick);
    }

    // UI Button을 클릭했을 때 실행될 메서드
    void OnMyButtonClick()
    {
        Debug.Log("UI Button을 클릭했습니다!");
        // 여기에 특정 작업을 수행하는 코드를 추가합니다.
        BellyPatchRoot.instance.ChangeState(BellyPatchRoot.GameState.State4);

    }
}
