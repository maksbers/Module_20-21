using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private float _smoothness = 2f;

    [SerializeField] private float _maxRotationAngle = 90f;
    [SerializeField] private bool _useLimits = false;

    private float _currentSpeed;
    private float _targetDirection;
    private float _currentAngle;

    public void SetInputDirection(float direction)
    {
        _targetDirection = direction;
    }

    private void Update()
    {
        float targetSpeed = _targetDirection * _rotationSpeed;

        _currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, Time.deltaTime * _smoothness);

        if (Mathf.Abs(_currentSpeed) > 0.01f)
        {
            float delta = _currentSpeed * Time.deltaTime;

            if (_useLimits)
            {
                _currentAngle += delta;
                _currentAngle = Mathf.Clamp(_currentAngle, -_maxRotationAngle, _maxRotationAngle);
                transform.localRotation = Quaternion.Euler(0, _currentAngle, 0);
            }
            else
            {
                transform.Rotate(Vector3.up, delta);
            }
        }

        _targetDirection = 0f;
    }
}
