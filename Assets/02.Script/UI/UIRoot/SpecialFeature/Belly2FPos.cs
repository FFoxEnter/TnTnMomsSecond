using System;
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
    public List<Transform> belly2fPosList = new List<Transform>();
    public Transform[] belly2fPosArray;
    Camera mainCam;

    public int curCamIndex = 2;

    private void Awake()
    {        
        parentTransform = GetComponent<Transform>();

        //if (parentTransform.childCount > 0)
        //{
        //    for (int i = 0; i < parentTransform.childCount; i++)
        //    {
        //        foreach (EBelly2FPos enumValue in Enum.GetValues(typeof(EBelly2FPos)))
        //        {
        //            if (parentTransform.GetChild(i).gameObject.name.Equals(enumValue.ToString()))
        //            {
        //                belly2fPosDic.Add((int)enumValue, parentTransform.GetChild(i).transform);
        //                break;
        //            }                    
        //        }
        //    }            
        //}

        //if (parentTransform.childCount > 0)
        //{
        //    for (int i = 0; i < parentTransform.childCount; i++)
        //    {
        //        foreach (EBelly2FPos enumValue in Enum.GetValues(typeof(EBelly2FPos)))
        //        {
        //            if (parentTransform.GetChild(i).gameObject.name.Equals(enumValue.ToString()))
        //            {
        //                belly2fPosList.Add(parentTransform.GetChild(i).transform);
        //                break;
        //            }
        //        }
        //    }
        //}

        belly2fPosArray = new Transform[Enum.GetNames(typeof(EBelly2FPos)).Length];

        if (parentTransform.childCount > 0)
        {
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                int idx = i;
                belly2fPosArray[idx] = parentTransform.GetChild(idx).transform;
            }
        }

        mainCam = Camera.main;
    }

    void SetMainCamPosRot()
    {
        mainCam.nearClipPlane = 0.1f;
        mainCam.fieldOfView = 36.73f;
        mainCam.transform.localPosition = belly2fPosArray[curCamIndex].localPosition;
        mainCam.transform.localRotation = belly2fPosArray[curCamIndex].localRotation;
    }

    public bool isKeyDown = false;
    private void Update()
    {
        if (!isKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetMainCamPosRot();
                curCamIndex++;
                isKeyDown = true;
            }
        }
        
    }


}
