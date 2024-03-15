using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLineManager : Singleton<MovingLineManager>
{
    public GameObject TimelineRoot;
    public GameObject[] MovingLine;

    public void InnerAwake()
    {
        TimelineRoot = GameObject.FindWithTag("TimeLine");

        // TimelineRoot의 자식 GameObject들을 검색하여 MovingLine 배열에 할당.
        int childCount = TimelineRoot.transform.childCount;
        MovingLine = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            MovingLine[i] = TimelineRoot.transform.GetChild(i).gameObject;
        }
    }

    // MovingLine 배열의 특정 인덱스에 해당하는 요소만 활성화하는 함수.
    public void SetActiveMovingLine(int index)
    {
        for (int i = 0; i < MovingLine.Length; i++)
        {
            MovingLine[i].SetActive(i == index);
        }
    }
}