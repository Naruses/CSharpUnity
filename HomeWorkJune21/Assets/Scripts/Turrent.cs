using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turrent : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 3;
    //[SerializeField] private static float _chekDistanse = 20f;
    [SerializeField] private float _bulletMaxTime;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _maxReloadTime = 0.5f;

    private float _time;
    private void Awake()
    {
        _time = _maxReloadTime;
    }

    void Update()
    {
        _time = Time.deltaTime;
       // TurrentIsOn(_target);
        var pos = (_target.position + Vector3.up) - transform.position;
        var rot = Vector3.RotateTowards(transform.forward, pos, _speed * Time.deltaTime, 0.0f);
       transform.rotation = Quaternion.LookRotation(rot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MyMove>().TakePlayerDamage(_damage);
        }
        Destroy(_target);

    }
    //private void TurrentIsOn(Transform target)
    //{
       // _target = target;
       // if (_chekDistanse >= Vector3.Distance(transform.position, _target.position))
       // {
        //    transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, (_target.position + Vector3.up * 2) - transform.position));
        //    if (_bulletMaxTime < 0)
         //   {
          //      var bullet = Instantiate(_bulletPref, _startPosition.position, transform.rotation);//quan
          //      _startPosition.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
           //     Destroy(bullet, _bulletMaxTime);
           //     _bulletMaxTime = _maxReloadTime;
           // }
       // }
    //}
    
}
