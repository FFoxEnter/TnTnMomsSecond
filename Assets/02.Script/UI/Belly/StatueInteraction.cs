using UnityEngine;

public class StatueInteraction : MonoBehaviour
{
    // 활성화할 스티커 오브젝트
    public GameObject stickerActive001;
    public GameObject stickerActive002;
     
    // 드래그된 오브젝트가 베어 패치인지 확인하기 위한 태그
    private const string BearPatchTag = "Draggable";

    // 드래그된 오브젝트와 상호 작용할 때 호출되는 이벤트
    void OnTriggerEnter(Collider other)
    {
        // 드래그된 오브젝트의 태그가 BearPatch인지 확인
        if (other.CompareTag(BearPatchTag))
        {
            // 드래그된 오브젝트의 이름에 따라 스티커 활성화
            if (other.gameObject.name == "BearPatch_01 def")
            {
                ActivateSticker(stickerActive001);
            }
            else if (other.gameObject.name == "BearPatch_02 def")
            {
                ActivateSticker(stickerActive002);
            }
        }
    }

    // 스티커를 활성화하는 함수
    void ActivateSticker(GameObject sticker)
    {
        if (sticker != null)
        {
            sticker.SetActive(true);
        }
    }
}
