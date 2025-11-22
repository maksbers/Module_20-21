using UnityEngine;

public class WindProcessor : MonoBehaviour
{
    [SerializeField] private WindGenerator _windGenerator;

    [SerializeField] private Transform _mastTransform;
    [SerializeField] private Transform _windArrow;

    private float _sailEfficiency;
    private float _shipEfficiency;
    private float _currentSpeed;

    private void Update()
    {
        if (_windGenerator == null || _mastTransform == null || _windArrow == null)
            return;

        FlugerProcess();
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        Vector3 windDirectionNorm = _windGenerator.WindDirection.normalized;

        float dotProductSailWind = Vector3.Dot(windDirectionNorm, _mastTransform.forward);
        _sailEfficiency = Mathf.Max(0f, dotProductSailWind);

        float dotProductShipMast = Vector3.Dot(_mastTransform.forward, transform.forward);
        _shipEfficiency = _sailEfficiency * Mathf.Max(0f, dotProductShipMast);

        _currentSpeed = _shipEfficiency * _windGenerator.WindStrength;

        transform.position += transform.forward * _currentSpeed * Time.deltaTime;
    }

    private void FlugerProcess()
    {
        _windArrow.rotation = Quaternion.LookRotation(_windGenerator.WindDirection);
    }
}


