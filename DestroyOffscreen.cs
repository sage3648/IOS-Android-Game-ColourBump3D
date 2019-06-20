using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DestroyOffscreen : MonoBehaviour
{
	private float _timer; 

	private void OnBecameInvisible()
	{
		
		Destroy(gameObject);
	}

	void Update()
	{
		_timer += Time.deltaTime;
		if (_timer >= 5)
		{
			//Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		
		if (other.name == "GarbageCollector")
		{
			Destroy(gameObject);
		}
	}

	public void OnCollisionEnter(Collision other)
	{

		if (other.collider.name == "GarbageCollector")
		{
			Destroy(gameObject);
		}
	}
}
