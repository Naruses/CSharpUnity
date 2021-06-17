using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVector : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    private void Update()
    {
        //var pos = _target.position = transform.position;
        //var rot = Quaternion.LookRotation(pos);
        //transform.rotation = rot;
        
        //var t = new Quaternion(0.1f, 0.1f, 0.1f, 1);
        //transform.rotation = Quaternion.Euler(0, 70, 0);
        
        //transform.rotation = Quaternion.LookRotation(_target.position = transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, _target.rotation, _speed * Time.deltaTime);
        
        //var pos = _target.position = transform.position;
        //var rot = Vector3.RotateTowards(transform.forward, pos, _speed * Time.deltaTime, 0.0f);
        //transform.rotation = Quaternion.LookRotation(rot);
        
        //transform.LookAt(_target);
    }
}

