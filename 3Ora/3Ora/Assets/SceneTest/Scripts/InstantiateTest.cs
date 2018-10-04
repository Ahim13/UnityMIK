using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTest : MonoBehaviour
{

	public GameObject Prefab;

	private void Start()
	{
		Instantiate(Prefab, transform.position, Quaternion.identity);
	}
}
