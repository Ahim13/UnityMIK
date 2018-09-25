using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector2 _startForce = new Vector2(10, 10);
    [SerializeField] private TrailRenderer _trailRenderer;

    private Rigidbody2D _rigidbody2D;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void FireBall()
    {
        var r = Random.Range(0, 2);
        if (r == 0) _rigidbody2D.AddForce(_startForce);
        else _rigidbody2D.AddForce(-_startForce);
    }

    public void ResetBall()
    {
        _trailRenderer.Clear();
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = _rigidbody2D.velocity.x;
            vel.y = _rigidbody2D.velocity.y;
            vel.y = _rigidbody2D.velocity.y + other.collider.attachedRigidbody.velocity.y / 4;
            _rigidbody2D.velocity = vel;
        }
    }
}