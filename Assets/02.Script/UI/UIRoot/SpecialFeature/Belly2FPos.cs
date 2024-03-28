using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Belly2FPos : MonoBehaviour
{
    public enum EBelly2FPos
    {
        Video2,
        Exhibition,
        Main,
        BlueBerry,
        Video1
    }
    public EBelly2FPos eBelly2FPos = EBelly2FPos.Video2;

    [SerializeField] Transform parentTransform;
    public SerializedDictionary<int, Transform> belly2fPosDic = new SerializedDictionary<int, Transform>();
    Camera mainCam;

    private void Awake()
    {        
        parentTransform = GetComponent<Transform>();
        if (parentTransform.childCount > 0)
        {
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                int idx = i;
                if (parentTransform.GetChild(idx).name.Equals(eBelly2FPos.ToString()))
                {
                    belly2fPosDic.Add((int)eBelly2FPos, parentTransform.GetChild(idx));
                    eBelly2FPos++;
                }
                
            }
        }

        mainCam = Camera.main;
    }

    void SetMainCamPos(Transform transform)
    {
        mainCam.transform.localPosition = transform.localPosition;
    }


}
