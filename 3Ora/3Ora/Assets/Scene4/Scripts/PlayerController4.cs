using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    //TODO:
    //variables needed:
    //speed, gameobject for laserPrefab, laserspeed, Sprite arrays
    //speed, gameobject for laserPrefab, laserspeed, Sprite arrays
    

    private bool _damaged = false;

    private static int _SPACESHIP_STATE = 0;

    private void Awake()
    {
        _SPACESHIP_STATE = 0;
        _damaged = false;
    }


    //TODO: On space down shoot laser
    private void Update()
    {
        Controll();
        if (false)
        {
            Shoot();
        }
    }
    

    //TODO: instantiate Bullet, add speed to it, destroy it after 3 sec
    private void Shoot()
    {
        
    }

    //TODO: controll spaceship with WASD, 
    private void Controll()
    {
        var horizontal = Input.GetAxisRaw("Horizontal"); // Possible values: 1,0,-1
        var vertical = Input.GetAxisRaw("Vertical"); // Possible values: 1,0,-1


        if (_damaged)
            return;

        //TODO: change sprite
        if (Math.Abs(horizontal - 1) < 0.1f)
        {
        }
        else if (Math.Abs(horizontal - (-1)) < 0.1f)
        {
        }
        else
        {
        }
    }

    
    //TODO: change sprite to damaged sprite when life is 1
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (false)
            {
                _damaged = true;
                _SPACESHIP_STATE = 1;
            }
        }
    }
}