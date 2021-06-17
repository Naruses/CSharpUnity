using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 3;
    

    void Update()
    {
        var pos = _target.position = transform.position;
        var rot = Vector3.RotateTowards(transform.forward, pos, _speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(rot);
    }
}
