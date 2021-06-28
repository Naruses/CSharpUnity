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
    [SerializeField] private float jumpPower = 50f;
    [SerializeField] private Animator _animator;

    private readonly Vector3 jumpDirection = Vector3.up;

    private Rigidbody rb;
    public bool isGrounded { get; private set; }
    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();

    }
    private int _HP;

    private float mouseLook;
    private Vector3 _dir;
    private void Awake()
    {
        _HP = _MaxHP;
        _ammoCount = 40;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerLook();
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.jump();
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_ammoCount > 0)
            {
                _animator.SetBool("Fire", true);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropMine();
        }
    }
    private void jump()
    {
        if (this.isGrounded)
            this.rb.AddForce(this.jumpDirection * this.jumpPower, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other)
    {
        var ground = other.gameObject.GetComponentInParent<Ground>();
        if (ground)
            this.isGrounded = true;
    }
    private void OnCollisionExit(Collision other)
    {
        var ground = other.gameObject.GetComponentInParent<Ground>();
        if (ground)
            this.isGrounded = false;
    }


    private void FixedUpdate()
    {
        if (_dir == Vector3.zero)
            _animator.SetBool("Run", true);
        else
            _animator.SetBool("Run", false);
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

