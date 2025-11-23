using UnityEngine;

public class Box : MonoBehaviour, IMovable, IDamageable
{
    [SerializeField] ParticleSystem _damageEffect;

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
        PlayDamageEffect();
    }

    private void PlayDamageEffect()
    {
        if (_damageEffect != null)
        {
            ParticleSystem instantiatedEffect = GameObject.Instantiate(_damageEffect, transform.position, Quaternion.identity);
            instantiatedEffect.Play();
        }
    }
}
