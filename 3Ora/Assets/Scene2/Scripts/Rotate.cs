using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateVector;
    [SerializeField] private Space _space;

    void Update()
    {
        transform.Rotate(_rotateVector, _space);
    }
}