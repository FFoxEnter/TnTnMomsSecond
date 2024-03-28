using UnityEngine;

public class BellyPatchRoot : Singleton<BellyPatchRoot>
{
    public GameObject BellyPackObject;
    public GameObject BellyPackOfStatue;
    public GameObject Sticker1OfStatue;
    public GameObject Sticker2OfStatue;
    public GameObject Bubble;

    public GameObject Tutorial;

    public BearPack BearPack;
    public Texture BellyPack;
    public Texture BellyPackNeon;
    public Texture[] BellyPatchSticker1;
    public Texture[] BellyPatchSticker2;

    public BoxCollider[] BellyPatchStickerCollider;

    public Material BellyPatchSticker1Material;
    public Material BellyPatchSticker2Material;

    public RotateObjectToTargetAngle Statue;

    public enum GameState
    {
        State1,// Scene 시작 시.
        State2,// 카메라 진입 시.
        State3,// 팩 클릭 시.
        State4,// 스티커 가능.
        State5 // 초기화.
    }
    public GameState currentState;

    private void Start()
    {
        // 초기 상태 설정
        currentState = GameState.State1;
        OnState1Enter();
    }

    void OnState1Enter()
    {
        // State1 진입 시 실행될 코드.

        // 스티커 비활성화
        StickerCollider(0, false);
    }

    void OnState2Enter()
    {
        // State2 진입 시 실행될 코드.

        BellyPackObject.SetActive(true);
        Statue.RotatePositiveDegreesCoroutine();
    }

    void OnState3Enter()
    {
        // State3 진입 시 실행될 코드.

        // 팩 비활성화.
        BellyPackObject.SetActive(false);
        // 말풍선 비활성화.
        Bubble.SetActive(false);
        // 튜토리얼 활성화.
        Tutorial.SetActive(true);
        // 석상의 팩 활성화.
        BellyPackOfStatue.SetActive(true);
    }

    void OnState4Enter()
    {
        // State4 진입 시 실행될 코드.

        // 튜토리얼 비활성화.
        Tutorial.SetActive(false);

        // 스티커 클릭 가능 Collider 활성화.
        StickerCollider(0, true);
    }

    void OnState5Enter()
    {
        // State5 진입 시 실행될 코드
        Tutorial.SetActive(false);

    }

    private void StateUpdate()
    {
        // 게임 상태 업데이트.
        switch (currentState)
        {
            case GameState.State1:
                OnState1Enter();
                break;
            case GameState.State2:
                OnState2Enter();
                break;
            case GameState.State3:
                OnState3Enter();
                break;
            case GameState.State4:
                OnState4Enter();
                break;
            case GameState.State5:
                OnState5Enter();
                break;
            default:
                break;
        }
    }

    // 상태 변경 메서드.
    public void ChangeState(GameState newState)
    {
        currentState = newState;
        StateUpdate();
    }


    public void ChangeTexture(Material mat, Texture tex)
    {
        // Material의 메인 텍스처를 새로운 텍스처(newTexture)로 변경.
        mat.mainTexture = tex;
    }

    private void StickerCollider(int index, bool flag)
    {
        switch (currentState)
        {
            case GameState.State1:
            case GameState.State4:
                for (int i = 0; i < BellyPatchStickerCollider.Length; i++)
                {
                    BellyPatchStickerCollider[i].enabled = flag;
                }
                break;
        }
    }

    // Sticker1OfStatue를 활성화/비활성화하는 메서드.
    public void SetStickerActive(bool active)
    {
        if (active)
        {
            Sticker1OfStatue.SetActive(true);
            Sticker2OfStatue.SetActive(false);
        }
        else
        {
            Sticker1OfStatue.SetActive(false);
            Sticker2OfStatue.SetActive(true);
        }
    }
}

