using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text PointText;

    private int _points;

    public int Points
    {
        get
        {
            return _points;
        }
        set
        {
            _points = value;
            PointText.text = _points.ToString();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireRay();
        }
    }

    private void FireRay()
    {
        RaycastHit hit;
        int layerMask = 1 << 12;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            var target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                if (target.Type == TargetType.Purple)
                {
                    ++Points;
                }
                else
                {
                    --Points;
                }
            }

            Destroy(hit.transform.gameObject);
        }

        Debug.DrawRay(ray.origin, ray.direction * 25, Color.cyan, 2);
    }
}