using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;

    void Start()
    {
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        //TODO: Move the ball with the given input (use rigidbody - AddForce())
        
        
        //TODO: On Space down the ball should jump
    }

    //TODO: Destroy the object it collided with
}