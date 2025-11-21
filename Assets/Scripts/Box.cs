using UnityEngine;

public class Box : MonoBehaviour, IMovable, IDamageable
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 targetPoint)
    {
        _rigidbody.transform.position = new Vector3(targetPoint.x, _rigidbody.transform.position.y, targetPoint.z);
    }

    public void TakeForce(Vector3 forceDirection, float forceAmount)
    {
        _rigidbody.AddForce(forceDirection * forceAmount, ForceMode.Impulse);
    }
}
