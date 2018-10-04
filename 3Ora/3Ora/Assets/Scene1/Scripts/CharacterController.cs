using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //TODO: Create physics material for the Wall so the character wont stuck then use it
    
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 2;


    private bool _faceRight = true;
    private bool _isColliding;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TODO: reset velocity on Y axis and dont change the X value
            //TODO AddForece on Y axis (for example 50)
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
        //TODO: When triggered by Coin tagged GameObject add 1 to Score adn destroy it after the audio.Play() (swap your condition with the true in if(true))
        Debug.Log("CoinPicked");
        if (true)
        {
            GetComponent<AudioSource>()?.Play();
        }
    }
}