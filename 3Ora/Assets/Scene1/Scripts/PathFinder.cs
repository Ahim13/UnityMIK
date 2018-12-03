using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public Transform[] TargetPoints;
    public float[] WaitTimes;
    public float[] Speed;
    public bool[] FaceToTarget;

    private Transform currentTarget;
    private int currenttargetindex;
    private float assignedWaitTime;

    void Start()
    {
        assignedWaitTime = WaitTimes[0];
        currentTarget = TargetPoints[0];
        currenttargetindex = 0;
    }

    void FixedUpdate()
    {
        if (FaceToTarget[currenttargetindex])
        {
            if (currentTarget.transform.position != gameObject.transform.position)
            {
                gameObject.transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, Speed[currenttargetindex] * Time.deltaTime);
            }
            else
            {
                assignedWaitTime -= Time.deltaTime;
                if (assignedWaitTime <= 0.0f)
                {
                    if (TargetPoints[TargetPoints.Length - 1] == currentTarget)
                    {
                        transform.rotation = GetSide(TargetPoints[0].position);
                        currentTarget = TargetPoints[0];
                        assignedWaitTime = WaitTimes[0];
                        currenttargetindex = 0;
                    }
                    else
                    {
                        transform.rotation = GetSide(TargetPoints[currenttargetindex + 1].position);
                        currentTarget = TargetPoints[currenttargetindex + 1];
                        assignedWaitTime = WaitTimes[currenttargetindex + 1];
                        currenttargetindex = currenttargetindex + 1;
                    }
                }
            }
        }
        else
        {
            if (currentTarget.transform.position != this.gameObject.transform.position)
            {
                this.gameObject.transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, Speed[currenttargetindex] * Time.deltaTime);
            }
            else
            {
                assignedWaitTime -= Time.deltaTime;
                if (assignedWaitTime <= 0.0f)
                {
                    if (TargetPoints[TargetPoints.Length - 1] == currentTarget)
                    {
                        currentTarget = TargetPoints[0];
                        assignedWaitTime = WaitTimes[0];
                        currenttargetindex = 0;
                    }
                    else
                    {
                        currentTarget = TargetPoints[currenttargetindex + 1];
                        assignedWaitTime = WaitTimes[currenttargetindex + 1];
                        currenttargetindex = currenttargetindex + 1;
                    }
                }
            }
        }
    }

    private Quaternion GetSide(Vector2 targetPos)
    {
        Vector3 diff = (Vector3)targetPos - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        if (rot_z < -90 || rot_z > 90) GetComponent<SpriteRenderer>().flipY = true;
        else GetComponent<SpriteRenderer>().flipY = false;
        return Quaternion.Euler(0f, 0f, rot_z);
    }
}