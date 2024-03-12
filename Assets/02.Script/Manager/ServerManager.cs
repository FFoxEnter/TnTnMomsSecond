using UnityEngine;
using System.Collections.Generic;

public class ServerManager : MonoBehaviour
{
    private static ServerManager instance;
    public static ServerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ServerManager>();

                if (instance == null)
                {
                    GameObject go = new GameObject("ServerManager");
                    go.AddComponent<ServerManager>();
                }

            }
            return instance;
        }
    }
    /// EXAMPLE
    ///public List<DataModel.Schedule.ScheduleData> OOData;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}