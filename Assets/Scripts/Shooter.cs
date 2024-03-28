using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _timeBetweenShoots = 2f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var pause = new WaitForSeconds(_timeBetweenShoots);
        bool isRunning = true;

        while (isRunning)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            
            Bullet bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.SetDirection(direction);
            bullet.Move();

            yield return pause;
        }
    }
}