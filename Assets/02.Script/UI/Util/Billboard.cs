using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera targetCamera;

    void Update()
    {
        transform.LookAt(transform.position + targetCamera.transform.rotation * Vector3.forward,
            targetCamera.transform.rotation * Vector3.up);
    }
}
