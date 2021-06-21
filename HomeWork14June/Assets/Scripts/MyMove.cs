using UnityEngine;

public class MyMove : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _enemy;
    [SerializeField] private GameObject _MinePref;
    [SerializeField] private Transform _MineStartPosition;
    [SerializeField] private int sensitivity;
    [SerializeField] public int _ammoCount;
    [SerializeField] public int _MaxHP = 100;
    private int _HP;

    private float mouseLook;
    private Vector3 _dir;
    private void Awake()
    {
        _HP = _MaxHP;
        _ammoCount = 40;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        PlayerLook();
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_ammoCount > 0)
            {
                Fire();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropMine();
        }
    }


    private void FixedUpdate()
    {
        var speed = _dir * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
        _dir = Vector3.zero;
    }

    private void PlayerLook()
    {
        mouseLook = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseLook * sensitivity * Time.deltaTime, 0);
    }
    private void Fire()
    {
        var bullet = Instantiate(_bulletPref, _bulletStartPosition.position, transform.rotation);
        var b = bullet.GetComponent<Bullet>();
        b.Init(_enemy);
    }

    private void DropMine()
    {
        var Mine = Instantiate(_MinePref, _MineStartPosition.position, Quaternion.identity);
    }
    public void TakePlayerDamage(int damage)
    {
        Debug.Log("Auch!");
        _HP -= damage;
        if (_HP <= 0)
        {
            Death();
        }

    }
    private void Death()
    {
        Destroy(gameObject);
    }
}

