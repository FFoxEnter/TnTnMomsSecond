using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapOnOff : MonoBehaviour
{
    public Button MapOnButton;
    public Button MapOffButton;

    void Start()
    {
        MapOnButton.onClick.AddListener(MapOnButtonFunction);
        MapOffButton.onClick.AddListener(MapOffButtonFunction);
    }

    public void MapOnButtonFunction()
    {

    }

    public void MapOffButtonFunction()
    {

    }

   
}