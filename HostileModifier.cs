using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class HostileModifier : MonoBehaviour
{

	public bool Hostile;
	public Material Red,Blue,Green,Yellow;
	public int _colourChoice; 

	// Use this for initialization
	void Start ()
	{
		_colourChoice = Camera.main.GetComponentInChildren<GameController>().ColourChoice; 
		if (Hostile)
		{
			//int choice = Random.Range(1, 4);
			switch (_colourChoice)
			{
					case 1: 
						gameObject.GetComponentInChildren<MeshRenderer>().material = Red;
						break;
					case 2:
						gameObject.GetComponentInChildren<MeshRenderer>().material = Blue;
						break;
					case 3:
						gameObject.GetComponentInChildren<MeshRenderer>().material = Green;
						break; 
					case 4:
						gameObject.GetComponentInChildren<MeshRenderer>().material = Yellow;
						break; 
			}

		}
	
	}

}
