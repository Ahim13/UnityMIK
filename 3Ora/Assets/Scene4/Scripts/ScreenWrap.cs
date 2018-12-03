using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Renderer _render;
    private Camera _cam;


    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        _cam = Camera.main;
    }

    void Update()
    {
        var relativepos = _cam.WorldToViewportPoint(transform.position);
        if (relativepos.x < 0.0f)
        {
            relativepos.x = 1;
        }
        else if (relativepos.x > 1.0f)
        {
            relativepos.x = 0;
        }
        
        if (relativepos.y < 0.05f)
        {
            relativepos.y = 0.05f;
        }
        else if (relativepos.y > 0.2f)
        {
            relativepos.y = 0.2f;
        }
        transform.position = _cam.ViewportToWorldPoint(relativepos);
    }
}