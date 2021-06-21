using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private Transform _target;
    private int _hp;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _hp = _maxHP;
        _agent = GetComponent<NavMeshAgent>();
    }
   // public void Init(Transform target)
    //{
    //    _target = target;
   // }
    private void Update()
    {
        _agent.SetDestination(_target.position);
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