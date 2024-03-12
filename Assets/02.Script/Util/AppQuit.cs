using UnityEngine;

public class AppQuit : Singleton<AppQuit>
{
    int ClickCount = 0;

    public void ApplicationDoubleTouchQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }
    }

    void DoubleClick()
    {
        ClickCount = 0;
    }
}