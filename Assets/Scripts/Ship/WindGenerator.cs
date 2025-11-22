using UnityEngine;

public class WindGenerator : MonoBehaviour
{
    [SerializeField] private float _windStrength = 1f;
    [SerializeField] private float _changeInterval = 5f;
    [SerializeField] private float _smoothSpeed = 0.5f;

    private Vector3 _currentWindDirection;
    private Vector3 _targetWindDirection;
    private float _timer;

    public Vector3 WindDirection => _currentWindDirection;
    public float WindStrength => _windStrength;


    private void Awake()
    {
        _targetWindDirection = GenerateRandomDirection();
        _currentWindDirection = _targetWindDirection;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _changeInterval)
        {
            _targetWindDirection = GenerateRandomDirection();
            _timer = 0f;
        }

        _currentWindDirection = Vector3.Slerp(_currentWindDirection, _targetWindDirection, Time.deltaTime * _smoothSpeed);
    }

    private Vector3 GenerateRandomDirection()
    {
        float angle = UnityEngine.Random.Range(0f, 360f);

        return new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0f, Mathf.Sin(angle * Mathf.Deg2Rad));
    }
}
