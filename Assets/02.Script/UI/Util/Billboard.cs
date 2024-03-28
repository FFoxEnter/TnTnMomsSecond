using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera MainCamera;

    private void Awake()
    {
        SetMainCamera();
    }

    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    }

    void SetMainCamera()
    {
        MainCamera = Camera.main;
    }
}