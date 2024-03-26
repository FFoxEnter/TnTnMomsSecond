using UnityEngine;

public class BearPack : MonoBehaviour
{
    // BoxCollider가 트리거로 작동할지 여부를 결정합니다.
    public bool isTriggerCollider = true;

    void Start()
    {
        // BoxCollider 컴포넌트 추가 및 설정
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = isTriggerCollider;
    }

    // Raycast로 충돌이 발생했을 때 호출되는 메서드
    public void BellyPackOn()
    {
        // 특정 작업을 수행하는 코드를 작성합니다.
        Debug.Log("BearPack을 클릭했습니다!");
        BellyPatchRoot.instance.ChangeState(BellyPatchRoot.GameState.State3);
    }
}