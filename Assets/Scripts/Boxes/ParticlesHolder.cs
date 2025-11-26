using UnityEngine;

public class ParticlesHolder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private ParticleSystem _dustEffect;

    public ParticleSystem ExplosionEffect => _explosionEffect;
    public ParticleSystem DustEffect => _dustEffect;
}
