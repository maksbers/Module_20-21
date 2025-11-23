using UnityEngine;

public class ExplosionCaster : MonoBehaviour
{
    [SerializeField] private float _explodeRadius = 7f;
    [SerializeField] private float _explodeForce = 40f;

    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private Camera _camera;

    [SerializeField] private Grabber _grabber;

    private IShooter _exploder;
    private Ray _cameraRay;


    private void Awake()
    {
        _exploder = new Exploder(_explodeRadius, _explodeForce, _explosionEffect);
    }

    private void Update()
    {
        _cameraRay = _camera.ScreenPointToRay(Input.mousePosition);

        ExplosionProcess();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_cameraRay.origin, _cameraRay.direction * 100f);
    }

    private void ExplosionProcess()
    {
        bool isHolding = _grabber != null && _grabber.IsHolding;

        if (Input.GetMouseButtonDown(1) && !isHolding)
        {
            _exploder.Shoot(_cameraRay.origin, _cameraRay.direction);
        }
    }
}
