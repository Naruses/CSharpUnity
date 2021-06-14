using UnityEngine;

public class MyMove : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private float _speed;

    private Vector3 _dir;

    private void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        var speed = _dir * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
        _dir = Vector3.zero;
    }

    private void Fire()
    {
        var bullet = Instantiate(_bulletPref, _bulletStartPosition.position, Quaternion.identity);
        var b = bullet.GetComponent<Bullet>();
       // b.Init();
    }
}

