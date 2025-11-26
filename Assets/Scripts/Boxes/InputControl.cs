using UnityEngine;

public class InputControl : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _groundMask;

    Dragger _dragger;
    ExplosionCaster _explosionCaster;
    private Ray _cameraRay;

    private ParticlesHolder _particlesHolder;


    private void Awake()
    {
        _cameraRay = GetCameraRay();
        _particlesHolder = GetComponent<ParticlesHolder>();

        _dragger = new Dragger(_groundMask);
        _explosionCaster = new ExplosionCaster(_particlesHolder.ExplosionEffect);
    }

    private void Update()
    {
        _cameraRay = GetCameraRay();

        GrabProcess();
        HoldProcess();
        ReleaseProcess();

        ExplosionProcess();
    }

    private Ray GetCameraRay()
    {
        return _camera.ScreenPointToRay(Input.mousePosition);
    }

    private void GrabProcess()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragger.Grab(_cameraRay);
        }
    }

    private void HoldProcess()
    {
        if (Input.GetMouseButton(0))
        {
            _dragger.Hold(_cameraRay);
        }
    }

    private void ReleaseProcess()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _dragger.Release();
        }
    }

    private void ExplosionProcess()
    {
        bool isHolding = _dragger != null && _dragger.IsHolding;

        if (Input.GetMouseButtonDown(1) && !isHolding)
        {
            _explosionCaster.Explode(_cameraRay);
        }
    }
}
