using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _parent;

    private string _horizontalMouse = "Mouse X";
    private string _verticalMouse = "Mouse Y";

    [SerializeField] private float _mouseSensitivity = 2f;
    [SerializeField] private float _minPitch = -30f;
    [SerializeField] private float _maxPitch = 30f;

    private float _pitch;
    private float _yaw;


    private void Update()
    {
        FollowToPlayer();
        MouseRotate();
    }

    private void MouseRotate()
    {
        _yaw += Input.GetAxis(_horizontalMouse) * _mouseSensitivity;
        _pitch -= Input.GetAxis(_verticalMouse) * _mouseSensitivity;
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

        transform.rotation = Quaternion.Euler(_pitch, _yaw, 0f);
    }

    private void FollowToPlayer()
    {
        transform.position = _parent.position;
    }
}
