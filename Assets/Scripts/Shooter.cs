using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private float _timeBetweenShoots = 2f;

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
            Bullet.GetComponent<Rigidbody>().velocity = direction * _bulletSpeed;

            yield return new WaitForSeconds(_timeBetweenShoots);
        }
    }
}