using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    [SerializeField] private AIProperties _aiProperties;
    [SerializeField] private AiBrain _aiBrain;
    
    private Transform _ball;

    private void Awake()
    {
        _ball = GameObject.FindWithTag("Ball").transform;
        
        _aiBrain.Init(gameObject, _aiProperties, _ball);
    }
    
    private void FixedUpdate()
    {
        _aiBrain.Control(transform);
    }
}
