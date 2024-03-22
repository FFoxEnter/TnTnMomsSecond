using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellyPatchRoot : MonoBehaviour
{
    public Texture BellyPack;
    public Texture BellyPackNeon;
    public Texture[] BellyPatchSticker1;
    public Texture[] BellyPatchSticker2;

    public Material BellyPatchSticker1Material;
    public Material BellyPatchSticker2Material;


    public void ChangeTexture(Material mat, Texture tex)
    {
        // Material의 메인 텍스처를 새로운 텍스처(newTexture)로 변경
        mat.mainTexture = tex;
    }
}