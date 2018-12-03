using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Vector3 RayDirection;
    public Vector3 SphereDirection;
    
    public float RaySize = 2;
    public float SphereSize = 2;
    
    
    private void Update()
    {
        FireRay();
        FireSphere();
        if(Input.GetMouseButtonDown(0))
            FireRayMouse();
    }

    private void FireRayMouse()
    {
        RaycastHit hit;
        int layerMask = 1 << 12;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            Debug.Log(hit.transform.name);
        }

        Debug.DrawRay(ray.origin, ray.direction * 25, Color.cyan, 2);
    }

    private void FireRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, RayDirection, out hit, RaySize))
        {
            Debug.Log(hit.transform.name);
        }
    }
    
    private void FireSphere()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, SphereSize, SphereDirection, out hit, SphereSize))
        {
            Debug.Log(hit.transform.name);
        }

//        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, SphereSize);
//        foreach (var col in overlappedColliders)
//        {
//            Debug.Log(col.transform.name);
//        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, RayDirection * RaySize);
        
        Gizmos.color = Color.red;
//        Gizmos.DrawSphere(transform.position, SphereSize);
        Gizmos.DrawWireSphere(transform.position + SphereDirection, SphereSize);
    }
}