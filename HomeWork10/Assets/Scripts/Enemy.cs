using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHP;

    private int _hp;
    private void Awake()
    {
        _hp = _maxHP;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Auch!");
        _hp -= damage;
        if (_hp <= 0)
        {
            Death();
        }

    }
    private void Death()
    {
        Destroy(gameObject);
    }
}