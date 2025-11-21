using UnityEngine;

public class Exploder : IShooter
{
    private float _radius;
    private float _force;

    public Exploder(float radius, float force)
    {
        _radius = radius;
        _force = force;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 interactPoint = hitInfo.point;

            ExecuteExplosion(interactPoint);
        }
    }

    private void ExecuteExplosion(Vector3 origin)
    {
        Collider[] targets = Physics.OverlapSphere(origin, _radius);

        foreach (Collider target in targets)
        {
            if (target.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                Vector3 directionFromExplosion = (target.transform.position - origin).normalized;
                damageable.TakeForce(directionFromExplosion, _force);
            }
        }
    }
}
