using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{

	[SerializeField] private float _speed = 1;

	private Renderer _renderer;

	// Use this for initialization
	void Start ()
	{
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		_renderer.material.mainTextureOffset = new Vector2(0, Time.time * _speed);
	}
}
