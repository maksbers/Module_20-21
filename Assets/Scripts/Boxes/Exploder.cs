using UnityEngine;

public class Exploder : IShooter
{
    private float _radius;
    private float _force;
    ParticleSystem _explosionEffect;

    public Exploder(float radius, float force, ParticleSystem explosionEffect)
    {
        _radius = radius;
        _force = force;
        _explosionEffect = explosionEffect;
    }



    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 interactPoint = hitInfo.point;

            PlayEffect(interactPoint, _explosionEffect);

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

    private void PlayEffect(Vector3 position, ParticleSystem effect)
    {
        if (effect != null)
        {
            ParticleSystem instantiatedEffect = GameObject.Instantiate(effect, position, Quaternion.identity);
            instantiatedEffect.Play();
        }
    }
}
