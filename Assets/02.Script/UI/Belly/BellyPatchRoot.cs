using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellyPatchRoot : Singleton<BellyPatchRoot>
{
    public GameObject BellyPackObject;
    public GameObject BellyPackOfStatue;

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
        State4,
        State5
    }
    private GameState currentState;

    private void Start()
    {
        // 초기 상태 설정
        currentState = GameState.State1;
        OnState1Enter();
    }

    void OnState1Enter()
    {
        // State1 진입 시 실행될 코드.
        StickerCollider(0, false);
    }

    void OnState2Enter()
    {
        // State2 진입 시 실행될 코드.
        BellyPackObject.SetActive(true);
        Statue.RotateNegative10Degrees();
    }

    void OnState3Enter()
    {
        // State3 진입 시 실행될 코드.
        Tutorial.SetActive(true);
        StickerCollider(0, true);
    }

    void OnState4Enter()
    {
        // State4 진입 시 실행될 코드.
        BellyPackOfStatue.SetActive(true);
    }

    void OnState5Enter()
    {
        // State5 진입 시 실행될 코드
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
            case GameState.State3:
                for (int i = 0; i < BellyPatchStickerCollider.Length; i++)
                {
                    BellyPatchStickerCollider[i].enabled = flag;
                }
                break;
            case GameState.State2:
                BellyPatchStickerCollider[index].enabled = flag;
                break;

        }
    }

}