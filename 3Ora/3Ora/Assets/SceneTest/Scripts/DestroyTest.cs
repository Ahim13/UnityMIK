using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour
{

	public float Time = 1;

	
	void Start () {
		Destroy(this.gameObject, Time);
	}
}
