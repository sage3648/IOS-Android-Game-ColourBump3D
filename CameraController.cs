using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private bool _started;
	private float _timer;
	

	// Use this for initialization
	void Start ()
	{
		
		_timer += 8; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		_timer += 0.1f * Time.deltaTime; 
		_started = Camera.main.GetComponentInChildren<GameController>().GameStarted; 
		if (_started)
		{
			transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + _timer * Time.deltaTime);
		}
	}
	
}
 