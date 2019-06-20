using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
	private Vector3 startingPos;
	private float _currentPos; 
	private float _maxDown, _maxUp;
	private MovementDirection _moving;

	public enum MovementDirection
	{
		Down,Up
	}

	// Use this for initialization
	void Start ()
	{
		_moving = MovementDirection.Down;
		startingPos = transform.position;
		_maxDown = startingPos.z - 8f; 
		_maxUp = startingPos.z + 8f; 
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(transform.up);
		transform.Rotate(transform.forward);
		if (_moving == MovementDirection.Down)
		{
			_currentPos = transform.localPosition.y - 0.01f * Time.deltaTime; 
			transform.position = new Vector3(startingPos.x,startingPos.y, _currentPos);
		}

		if (_moving == MovementDirection.Up)
		{
			_currentPos = transform.localPosition.y + 0.01f * Time.deltaTime; 
			transform.position = new Vector3(startingPos.x,startingPos.y, _currentPos);
		}

		if (transform.position.z >= _maxDown)
		{
			_moving = MovementDirection.Up;
		}

		if (transform.position.z <= _maxUp)
		{
			_moving = MovementDirection.Up; 
		}
		
	}


}
