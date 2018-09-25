using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Side
{
    Right,
    Left
}

public class Wall : MonoBehaviour
{
    [SerializeField] private Side _side;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            GameManager.Instance.Score(_side);
        }
    }
}