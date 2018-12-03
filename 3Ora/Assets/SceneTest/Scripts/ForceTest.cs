using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTest : MonoBehaviour
{

	public Vector3 Force;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GetComponent<Rigidbody>().AddForce(Force);
		}
	}
}
