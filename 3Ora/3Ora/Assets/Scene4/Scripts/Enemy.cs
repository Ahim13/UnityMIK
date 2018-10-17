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
    }


    void Update()
    {
        _rigidbody2D.velocity = new Vector2(0, -_speed);
    }

    //TODO: on Bullet Instantiate particels, add score basde won enemys worth, destroy particle after 1.2f and other destroys also needed (figure out which objects need to be destroyed)
    //TODO: on Player destroy Enemy and call Died method
    //TODO: on Destroyer Score negative and destroy enemy (multiple ways to do it, dont need to use this OnTrigger if you dont want to)
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Bullet"))
        {
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager4.Instance.Died();
        }
        
        if (other.gameObject.CompareTag("Destroyer"))
        {
        }
    }
}