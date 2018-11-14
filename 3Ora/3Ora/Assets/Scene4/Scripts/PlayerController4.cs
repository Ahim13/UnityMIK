using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _laser;
    [SerializeField] private float _laserSpeed = 5;
    [SerializeField] private Sprite[] _spaceShipStates;
    [SerializeField] private Sprite[] _spaceShipSprites;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private bool _damaged = false;

    private static int _SPACESHIP_STATE = 0;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _SPACESHIP_STATE = 0;
        _damaged = false;
        _spriteRenderer.sprite = _spaceShipStates[_SPACESHIP_STATE];
    }


    private void Update()
    {
        Controll();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(_laser, transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _laserSpeed);
        Destroy(bullet, 3);
    }

    private void Controll()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _rigidbody2D.velocity = new Vector2(horizontal * _speed, vertical * _speed);

        if (_damaged)
            return;

        if (Math.Abs(horizontal - 1) < 0.1f)
        {
            _spriteRenderer.sprite = _spaceShipSprites[1];
        }
        else if (Math.Abs(horizontal - (-1)) < 0.1f)
        {
            _spriteRenderer.sprite = _spaceShipSprites[2];
        }
        else
        {
            _spriteRenderer.sprite = _spaceShipSprites[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (GameManager4.Instance.LivesCounter == 1)
            {
                _damaged = true;
                _SPACESHIP_STATE = 1;
                _spriteRenderer.sprite = _spaceShipStates[_SPACESHIP_STATE];
            }
        }
    }
}