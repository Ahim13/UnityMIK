using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour {
    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
