using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 2;


    private bool _faceRight = true;
    private bool _isColliding;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(new Vector2(0, 50));
        }
    }

    void FixedUpdate()
    {
        if (!_isColliding)
        {
            var move = Input.GetAxis("Horizontal");

            _rigidbody2D.velocity = new Vector2(move * _speed, _rigidbody2D.velocity.y);

            if (move > 0 && !_faceRight)
                Flip();
            else if (move < 0 && _faceRight)
                Flip();
        }
    }

    void Flip()
    {
        _faceRight = !_faceRight;
        var newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) _isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) _isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("CoinPicked");
        if (other.CompareTag("Coin"))
        {
            PointsManager.Instance.AddScore(1);
            GetComponent<AudioSource>()?.Play();
            Destroy(other.gameObject);
        }
    }
}