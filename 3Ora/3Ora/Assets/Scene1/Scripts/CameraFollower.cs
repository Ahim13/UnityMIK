using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform Target;
    public Vector3 PositionFromTarget;

    private void Update()
    {
        gameObject.transform.position = Target.position + PositionFromTarget;
    }
}
