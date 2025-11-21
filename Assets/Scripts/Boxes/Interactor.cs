using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _explodeRadius = 7f;
    [SerializeField] private float _explodeForce = 40f;

    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _groundMask;
    private IShooter _exploder;

    private IMovable _movable;
    private Vector3 _groundInteractPoint; 
    private Ray _cameraRay;


    private void Awake()
    {
        _exploder = new Exploder(_explodeRadius, _explodeForce);
    }

    private void Update()
    {
        _cameraRay = GetCameraRay();

        Grab();
        Hold();
        Release();

        ExplodeProcess();
    }

    private Ray GetCameraRay()
    {
        _cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
        return _cameraRay;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_cameraRay.origin, _cameraRay.direction * 100f);
    }

    private void ExplodeProcess()
    {
        if (Input.GetMouseButtonDown(1) && _movable == null)
        {
            _exploder.Shoot(_cameraRay.origin, _cameraRay.direction);
        }
    }

    private void Grab()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_cameraRay, out RaycastHit hitInfo))
            {
                _movable = hitInfo.collider.GetComponent<IMovable>();
            }
        }
    }

    private void Hold()
    {
        if (Input.GetMouseButton(0) && _movable != null)
        {
            if (Physics.Raycast(_cameraRay, out RaycastHit hitInfo, Mathf.Infinity, _groundMask))
            {
                _groundInteractPoint = hitInfo.point;
                _movable.Move(_groundInteractPoint);
            }
        }
    }

    private void Release()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _movable = null;
        }
    }
}
