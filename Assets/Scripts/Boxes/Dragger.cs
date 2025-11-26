using UnityEngine;

public class Dragger
{
    private IDraggable _draggable;
    private Vector3 _groundInteractPoint;
    private LayerMask _groundMask;

    public IDraggable Draggable => _draggable;

    public Dragger(LayerMask groundMask)
    {
        _groundMask = groundMask;
    }

    public void Grab(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            _draggable = hitInfo.collider.GetComponent<IDraggable>();
        }
    }

    public void Hold(Ray ray)
    {
        if (_draggable == null)
            return;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _groundMask))
        {
            _groundInteractPoint = hitInfo.point;
            _draggable.Move(_groundInteractPoint);
        }
    }

    public void Release()
    {
        _draggable = null;
    }

    public bool IsHolding => _draggable != null;
}
