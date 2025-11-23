using UnityEngine;

public class Grabber : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _groundMask;

    private IMovable _movable;
    private Vector3 _groundInteractPoint;
    private Ray _cameraRay;


    private void Update()
    {
        _cameraRay = GetCameraRay();

        GrabProcess();
        HoldProcess();
        ReleaseProcess();
    }

    private Ray GetCameraRay()
    {
        return _camera.ScreenPointToRay(Input.mousePosition);
    }

    private void GrabProcess()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_cameraRay, out RaycastHit hitInfo))
            {
                _movable = hitInfo.collider.GetComponent<IMovable>();
            }
        }
    }

    private void HoldProcess()
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

    private void ReleaseProcess()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _movable = null;
        }
    }

    public bool IsHolding => _movable != null;
}
