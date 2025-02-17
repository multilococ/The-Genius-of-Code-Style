using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidbody() =>
        _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        { 
            Destroy(gameObject);
        }
    }
}
