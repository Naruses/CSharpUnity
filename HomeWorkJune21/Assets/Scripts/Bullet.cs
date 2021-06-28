using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxLifeTime = 3;
    [SerializeField] private int _damage = 5;
    private Transform _target;

    public void Init(Transform target)
    {
        _target = target;
        Debug.Log("Create bullet");
        Destroy(gameObject, _maxLifeTime);
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
