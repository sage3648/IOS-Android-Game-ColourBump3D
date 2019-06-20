using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private bool _dragging,started = false;
	private Vector3 _mouseStartPos, _playerStartPos;
	public GameObject Explosion;

	// Update is called once per frame
	void Update ()
	{
		
		Vector3 pMove;
		pMove = Camera.main.transform.position;
		pMove.x = transform.position.x;
		pMove.y = transform.position.y;
		//transform.GetComponentInChildren<Rigidbody>().velocity = (-pMove);
		
		if (Input.GetMouseButtonDown(0))
		{
			if (!started)
			{
				Camera.main.GetComponentInChildren<GameController>().StartGame();
				Camera.main.GetComponentInChildren<AudioSource>().Play();
				started = true;
			}
			_dragging = true;
			
			Plane plane = new Plane(Vector3.up, 0);

			float dist;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (plane.Raycast(ray, out dist))
			{
				_mouseStartPos = ray.GetPoint(dist);
				_playerStartPos = gameObject.transform.position;
			}
			
		}
		else if (Input.GetMouseButtonUp(0))
		{
			_dragging = false;
		}

		if (_dragging)
		{
			Plane plane = new Plane(Vector3.up, 0);
			Vector3 move = new Vector3(); 

			float dist;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (plane.Raycast(ray, out dist))
			{
				
				Vector3 mousePos = ray.GetPoint(dist);
				move = mousePos - _mouseStartPos;
		
				move.y = 0f;
				_playerStartPos.y = 0f; 
				transform.GetComponentInChildren<Rigidbody>().velocity = (move + _playerStartPos - transform.position) * 20f; 
	
				Debug.Log(mousePos);				
				Vector3 testTarget = new Vector3(5f,0.5f,2f);
			}
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.transform.CompareTag("obstacle"))
		{
			if (other.transform.GetComponentInChildren<HostileModifier>().Hostile)
			{
				GameEnding();
			}
		}
	}

	private void GameEnding()
	{
		Instantiate(Explosion, transform.position, transform.rotation);
		var newObject = Instantiate(Explosion, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z), gameObject.transform.rotation);
		Destroy(gameObject);
		Camera.main.GetComponentInChildren<AudioSource>().Stop();
		Camera.main.GetComponentInChildren<GameController>().GameStarted = false;
		if (Camera.main.GetComponentInChildren<GameController>().GameScore >
		    Camera.main.GetComponentInChildren<GameController>().HighScore)
		{
			PlayerPrefs.SetFloat("HighScore",Camera.main.GetComponentInChildren<GameController>().GameScore);
		}
		Camera.main.GetComponentInChildren<GameController>().GameEnding();
	}

	private void OnBecameInvisible()
	{
		GameEnding();
	}
}
