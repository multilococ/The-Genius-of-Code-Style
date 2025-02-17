using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;

    [SerializeField] private float _shootingDelay;
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private int _bulletCount = 30;

    private Transform _target;

    void Start()
    {
        if (_target != null)
            StartCoroutine(Shoot(_shootingDelay));
    }

    public void SetTarget(Transform target) =>
        _target = target;

    private IEnumerator Shoot(float delay)
    {
        WaitForSeconds shootingDelay = new WaitForSeconds(delay);

        for (int i = 0; i < _bulletCount; i++)
        {
            Vector3 shootingDerection = (_target.position - transform.position).normalized;

            Bullet bullet = Instantiate(_prefab, transform.position + shootingDerection, Quaternion.identity);

            bullet.GetRigidbody().transform.up = shootingDerection;
            bullet.GetRigidbody().velocity = shootingDerection * _bulletSpeed;

            yield return shootingDelay;
        }
    }
}