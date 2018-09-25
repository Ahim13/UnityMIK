using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode _up = KeyCode.W;
    [SerializeField] private KeyCode _down = KeyCode.S;
    [SerializeField] private float _speed = 5;
    
    [Header("Acceleration")]
    [SerializeField] private float _acceleration = 1;
    [SerializeField] private float _maxSpeed = 10;

    private Rigidbody2D _rigidbody2D;
    private float _topBorder;
    private float _bottomBorder;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 1)).y - gameObject.GetComponent<SpriteRenderer>().size.y / 2;
        _bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1)).y + gameObject.GetComponent<SpriteRenderer>().size.y / 2;
    }

    private void FixedUpdate()
    {
        var vel = _rigidbody2D.velocity;
       BasicControll(ref vel);

        _rigidbody2D.velocity = vel;
    }

    private void Update()
    {
        ClampToViewport();
    }


    private void BasicControll(ref Vector2 vel)
    {
        if (Input.GetKey(_up))
        {
            vel.y = _speed;
        }
        else if (Input.GetKey(_down))
        {
            vel.y = -_speed;
        }
        else
        {
            vel.y = 0;
        }

    }

    private void ClampToViewport()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _bottomBorder, _topBorder), transform.position.z);
    }
}