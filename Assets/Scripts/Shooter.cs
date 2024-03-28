using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenShoots;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isRunning = enabled;

        while (isRunning)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            var Bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            Bullet.GetComponent<Rigidbody>().transform.up = direction;
            Bullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return new WaitForSeconds(_timeBetweenShoots);
        }
    }
}