using UnityEngine;

public class ExplosionCaster
{
    private float _explodeRadius = 7f;
    private float _explodeForce = 40f;

    private IShooter _exploder;


    public ExplosionCaster(ParticleSystem explosionEffect)
    {
        _exploder = new Exploder(_explodeRadius, _explodeForce, explosionEffect);
    }

    public void Explode(Ray ray)
    {
        _exploder.Shoot(ray.origin, ray.direction);
    }
}
