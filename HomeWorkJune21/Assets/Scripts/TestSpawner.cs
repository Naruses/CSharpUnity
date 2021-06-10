using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _maxCount = 3;
    [SerializeField] private float _maxTime = 3;
    [SerializeField] private Transform _target;
    private float _time;
    private float _count;
    private bool isOff = false;

    private void Awake()
    {
        _time = _maxTime;
    }
    void Update()
    {
        if (isOff) return;

        _time -= Time.deltaTime;
        if (_time <= 0)
            Spawn();
    }
    private void Spawn()
    {
        var enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity).GetComponent<Enemy>();
        //enemy.Init(_target);
        _time = _maxTime;
        _count++;
        if (_count >= _maxCount)
            isOff = true;
    }
}
