using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float MouseSensitivity = 3;
    private Vector3 _inputVec;
    private Vector2 _mouseVec;
    private CharacterController _cc;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        _inputVec = (transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical")).normalized * MoveSpeed;
        _cc.SimpleMove(_inputVec);

        _mouseVec.x = Input.GetAxisRaw("Mouse X") * MouseSensitivity;
        transform.Rotate(0, _mouseVec.x, 0);

        _mouseVec.y -= Input.GetAxisRaw("Mouse Y") * MouseSensitivity;
        _mouseVec.y = Mathf.Clamp(_mouseVec.y, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(_mouseVec.y, 0, 0);
    }
}
