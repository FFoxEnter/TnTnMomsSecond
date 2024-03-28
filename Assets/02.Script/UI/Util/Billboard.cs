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
        transform.LookAt(transform.position + MainCamera.transform.rotation * Vector3.forward,
            MainCamera.transform.rotation * Vector3.up);
    }

    void SetMainCamera()
    {
        MainCamera = Camera.main;
    }
}