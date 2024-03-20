using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewAll : MonoBehaviour
{
    public Button ViewAllOnButton;
    public Button ViewAllOffButton;

    void Start()
    {
        ViewAllOnButton.onClick.AddListener(ViewAllOnButtonFunction);
        ViewAllOffButton.onClick.AddListener(ViewAllOffButtonFunction);
    }

    public void ViewAllOnButtonFunction()
    {

    }

    public void ViewAllOffButtonFunction()
    {

    }

}