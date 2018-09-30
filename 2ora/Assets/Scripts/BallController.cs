using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector2 _startForce = new Vector2(10, 10);
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private float _maxBallVelocity = 50;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private LayerMask _layerMask;

    public Vector2 PredictionPoint;

    public event Action<Vector3, Vector2, int, LayerMask> OnBallHit;


    public void FireBall()
    {
        var r = Random.Range(0, 2);
        if (r == 0) _rigidbody2D.AddForce(_startForce);
        else _rigidbody2D.AddForce(-_startForce);
        
        OnBallHit?.Invoke(transform.position, _rigidbody2D.velocity, 20, _layerMask);
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
            if (vel.y > _maxBallVelocity)
                vel.y = _maxBallVelocity;

            if (vel.y < -_maxBallVelocity)
                vel.y = -_maxBallVelocity;

            _rigidbody2D.velocity = vel;
        }

        OnBallHit?.Invoke(transform.position, _rigidbody2D.velocity, 20, _layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, _rigidbody2D.velocity.normalized * 20);
    }
}