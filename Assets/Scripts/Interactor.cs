using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _groundMask;

    private IMovable _movable;
    public Vector3 _groundInteractPoint; 
    private Ray _cameraRay;


    private void Update()
    {
        _cameraRay = _camera.ScreenPointToRay(Input.mousePosition);

        Grab();
        Hold();
        Release();

        Explode();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_groundInteractPoint, 0.2f);
        Gizmos.DrawRay(_cameraRay.origin, _cameraRay.direction * 100f);

    }

    private void Explode()
    {
        if (Input.GetMouseButtonDown(1) && _movable == null)
        {
            if (Physics.Raycast(_cameraRay, out RaycastHit hitInfo, Mathf.Infinity, _groundMask))
            {
                _groundInteractPoint = hitInfo.point;

                Collider[] colliders = Physics.OverlapSphere(_groundInteractPoint, 7f);

                foreach(Collider collider in colliders)
                {
                    if (collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                    {
                        Vector3 direction = (collider.transform.position - _groundInteractPoint).normalized;
                        damageable.TakeForce(direction, 40f);
                    }
                }
            }
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
