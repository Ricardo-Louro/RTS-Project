using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float panLimitX;
    [SerializeField] private float panLimitY;

    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float panBorderThickness = 10f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Update is called once per frame
    private void Update()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        Vector3 pos = ReceiveInputs();
        pos = HandleCameraLimits(pos);
        UpdateCameraPosition(pos);
    }

    private Vector3 ReceiveInputs()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("up") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("down") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("left") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("right") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        return pos;
    }

    private Vector3 HandleCameraLimits(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, -panLimitX, panLimitX);
        pos.y = Mathf.Clamp(pos.y, -panLimitY, panLimitY);

        return pos;
    }

    private void UpdateCameraPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}
