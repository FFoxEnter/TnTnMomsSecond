using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TntnSceneLoader : MonoBehaviour
{
    private static TntnSceneLoader instance;
    public static TntnSceneLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TntnSceneLoader>();

                if (instance == null)
                {
                    GameObject go = new GameObject("SceneLoader");
                    go.AddComponent<TntnSceneLoader>();
                }

            }
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    private void Start()
    {
        SceneManager.LoadSceneAsync("TnTnMain", LoadSceneMode.Single);
    }
}