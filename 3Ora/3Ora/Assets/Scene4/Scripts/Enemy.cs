using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private GameObject _particles;
    
    [Header("Score")]
    [SerializeField] private int _scoreWorth = 2;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        _rigidbody2D.velocity = new Vector2(0, -_speed);
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            var particle = Instantiate(_particles, transform.position, Quaternion.identity);
            GameManager4.Instance.Score(_scoreWorth);
            Destroy(particle, 1.2f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager4.Instance.Died();
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("Destroyer"))
        {
            GameManager4.Instance.Score(-_scoreWorth);
            Destroy(gameObject);
        }
    }
}