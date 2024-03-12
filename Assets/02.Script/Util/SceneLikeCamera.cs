using UnityEngine;

public class SceneLikeCamera : MonoBehaviour
{
    private bool doFocus = false;
    [SerializeField] private float focusLimit = 100f;
    [SerializeField] private float minFocusDistance = 5.0f;

    private float doubleClickTime = .15f;
    [SerializeField] private KeyCode firstUndoKey = KeyCode.LeftControl;
    [SerializeField] private KeyCode secondUndoKey = KeyCode.Z;

    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private float zoomSpeed = 2.0f;

    Quaternion prevRot = new Quaternion();
    Vector3 prevPos = new Vector3();

    private string mouseY = "Mouse Y";
    private string mouseX = "Mouse X";
    private string zoomAxis = "Mouse ScrollWheel";

    [SerializeField] private KeyCode forwardKey = KeyCode.W;
    [SerializeField] private KeyCode backKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode flatMoveKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode anchoredMoveKey = KeyCode.Mouse2;
    [SerializeField] private KeyCode anchoredRotateKey = KeyCode.Mouse1;

    private void Start()
    {
        SavePosAndRot();
    }

    void Update()
    {
        if (!doFocus)
            return;

        if (Input.GetKey(firstUndoKey))
        {
            if (Input.GetKeyDown(secondUndoKey))
                GoBackToLastPosition();
        }
    }

    private void LateUpdate()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(forwardKey))
            move += Vector3.forward * moveSpeed;
        if (Input.GetKey(backKey))
            move += Vector3.back * moveSpeed;
        if (Input.GetKey(leftKey))
            move += Vector3.left * moveSpeed;
        if (Input.GetKey(rightKey))
            move += Vector3.right * moveSpeed;
        if (Input.GetKey(KeyCode.E))
            move += Vector3.up * moveSpeed;
        if (Input.GetKey(KeyCode.Q))
            move += Vector3.down * moveSpeed;

        if (Input.GetKey(flatMoveKey))
        {
            float origY = transform.position.y;

            transform.Translate(move);
            transform.position = new Vector3(transform.position.x, origY, transform.position.z);

            return;
        }

        float mouseMoveY = Input.GetAxis(mouseY);
        float mouseMoveX = Input.GetAxis(mouseX);

        if (Input.GetKey(anchoredMoveKey))
        {
            move += Vector3.up * mouseMoveY * -moveSpeed;
            move += Vector3.right * mouseMoveX * -moveSpeed;
        }

        if (Input.GetKey(anchoredRotateKey))
        {
            transform.RotateAround(transform.position, transform.right, mouseMoveY * -rotationSpeed);
            transform.RotateAround(transform.position, Vector3.up, mouseMoveX * rotationSpeed);
        }

        transform.Translate(move);

        float mouseScroll = Input.GetAxis(zoomAxis);
        transform.Translate(Vector3.forward * mouseScroll * zoomSpeed);
    }

    private void SavePosAndRot()
    {
        prevRot = transform.rotation;
        prevPos = transform.position;
    }

    private void GoBackToLastPosition()
    {
        transform.position = prevPos;
        transform.rotation = prevRot;
    }
}