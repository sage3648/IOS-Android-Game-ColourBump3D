using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Boo.Lang.Environments;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering;

public class ObstacleGenerator : MonoBehaviour
{
	private float _timer;
	private float _gap;
	private float _difficultyModifier;
	private int _colourChoice; 
	private ObstaclePattern _og;
	public GameObject Cyclinders,Blocks,Cones, Pyramid, Ico,MediumCylinder,MediumBlock,LargeCyclinder,Sphere;
	public GameObject PushBarrier,PushBlock; 


	// Use this for initialization
	void Start ()
	{
		_colourChoice = 1; 
		_gap = 0f; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		float gameScore = Camera.main.GetComponentInChildren<GameController>().GameScore;
		
		if (gameScore >= _gap)
		{
			int patternChoice = Random.Range(1, 6);
			
			switch (patternChoice)
			{
				case 1:int obstacle = Random.Range(1, 4);
					switch (obstacle)
					{
						case 1:
							CreateTinyRow(Cyclinders, Random.Range(-4.8f, -2f), Random.Range(2f,4.8f), Random.Range(3,8));
							break;
						case 2:
							CreateTinyRow(Blocks, Random.Range(-4.8f, -2f), Random.Range(2f,4.8f), Random.Range(3,8));
							break;
						case 3:
							CreateTinyRow(Cyclinders , Random.Range(-4.8f, -2f), Random.Range(2f,4.8f), Random.Range(3,8));
							break; 
					
					}
					break;
				case 2:
					CreatePushObstacle(Pyramid);
					break; 
				case 3: 
					CreateWhitePath(MediumCylinder);
					break; 
				case 4:
					int obstacleChoice = Random.Range(1, 4);
					switch (obstacleChoice)
					{
						case 1:
							CreateBigBlockPush(MediumCylinder, Random.Range(-4.8f, -2f), Random.Range(2f,4.8f), Random.Range(3,8));
							break;
						case 2:
							CreateBigBlockPush(MediumBlock, Random.Range(-4.8f, -2f), Random.Range(2f,4.8f), Random.Range(3,8));
							break;
						case 3:
							CreateBigBlockPush(MediumCylinder , Random.Range(-4.8f, -2f), Random.Range(2f,4.8f), Random.Range(3,8));
							break; 
					
					}
					break;
				case 5:
					CreateTowerBalls();
					break; 
					
			}
			
			//Instantiate(Obstacle)

			_difficultyModifier -= 3f * Time.deltaTime; 
			Debug.Log(_difficultyModifier);
			_gap += Random.Range(10f, 15f);
			_gap -= _difficultyModifier;
		}
		
	}

	void CreateTinyRow(GameObject obstacle, float distLeft,float distRight, int rows)
	{
		double redRows = Random.Range(rows + 1, rows - 2f); 
		for (float cursor = distLeft; cursor < distRight; cursor += 0.4f)
		{
			//Instantiate(obstacle, new Vector3(cursor, 0.8f, Camera.main.transform.position.z + 40f), Quaternion.Euler(0f,0f,0f));
			//Instantiate(obstacle, new Vector3(cursor, 0.8f, Camera.main.transform.position.z + 40f ), Quaternion.Euler(0f,0f,0f));
		
			for (double i = 1; i < rows; i += 0.3)
			{
				if (i > redRows && i < rows)
				{
					var newObject = Instantiate(obstacle, new Vector3(cursor, 0.8f, Camera.main.transform.position.z + 40f + (float)i ), Quaternion.Euler(0f,0f,0f));
					newObject.GetComponentInChildren<HostileModifier>().Hostile = true;
				}
				else
				{
					Instantiate(obstacle, new Vector3(cursor, 0.8f, Camera.main.transform.position.z + 40f + (float)i ), Quaternion.Euler(0f,0f,0f));
				}
			}
		}
	}

	void CreatePushObstacle(GameObject obstacle)
	{
		Instantiate(PushBarrier, new Vector3(Random.Range(-2f,2f), 0.8f, Camera.main.transform.position.z + 40f), Quaternion.Euler(0f,0f,0f));
		for (int i = -4; i <= 4; i++)
		{
			
			var red  = Instantiate(obstacle, new Vector3((float) i , 0.8f, Camera.main.transform.position.z + 43f), Quaternion.Euler(0f,0f,0f));
			red.GetComponentInChildren<HostileModifier>().Hostile = true; 
		}
	}

	void CreateWhitePath(GameObject obstacle)
	{
		float gapLeft = Random.Range(-4.6f, 2.8f);
		float gapRight;
		gapRight =  gapLeft + Random.Range(2f, 2.5f);
		for (float cursor = -4.6f; cursor < 4.8; cursor += 0.8f)
		{
			//Instantiate(obstacle, new Vector3(cursor, 0.8f, Camera.main.transform.position.z + 40f), Quaternion.Euler(0f,0f,0f));
			//Instantiate(obstacle, new Vector3(cursor, 0.8f, Camera.main.transform.position.z + 40f ), Quaternion.Euler(0f,0f,0f));
			for (double i = 1; i < 5; i += 0.8)
			{
				if (cursor >= gapLeft && cursor <= gapRight)
				{
					var newObject = Instantiate(MediumBlock, new Vector3(cursor, 0.8f, Camera.main.transform.position.z + 40f + (float)i ), Quaternion.Euler(0f,0f,0f));
					newObject.GetComponentInChildren<HostileModifier>().Hostile = false; 
				}
				else
				{
					var newObject = Instantiate(obstacle, new Vector3(cursor, 0.8f, Camera.main.transform.position.z + 40f + (float)i ), Quaternion.Euler(0f,0f,0f));
					newObject.GetComponentInChildren<HostileModifier>().Hostile = true; 
				}
			}
		}
	}

	void CreateWreckBalls()
	{
		
	}

	void CreateBigBlockPush(GameObject obstacle, float distLeft,float distRight, int rows)
	{
		Instantiate(PushBlock, new Vector3(0, 0.8f, Camera.main.transform.position.z + 37f), Quaternion.Euler(0f,0f,0f));
		for (float cursor = distLeft; cursor < distRight; cursor += 1.5f)
		{
			for (double i = 1; i < rows; i += 1.5)
			{
				var newObject = Instantiate(obstacle, new Vector3(cursor, 0.8f, Camera.main.transform.position.z + 40f + (float)i ), Quaternion.Euler(0f,0f,0f));
				newObject.GetComponentInChildren<HostileModifier>().Hostile = true; 
			}
		}
	}


	private void CreateTowerBalls()
	{
		float distLeft = -3f;
		float distRight = 3f;
		double rows = 2;
		for (float cursor = distLeft; cursor < distRight; cursor += (Random.Range(1.5f, 5f))) 
		{
			for (double i = 1; i < rows; i += Random.Range(1f,2f))
			{
				Instantiate(LargeCyclinder, new Vector3(cursor, 1.5f, Camera.main.transform.position.z + 40f + (float)i ), Quaternion.Euler(0f,0f,0f));
				var newObject = Instantiate(Sphere, new Vector3(cursor, 3.5f, Camera.main.transform.position.z + 40f + (float)i ), Quaternion.Euler(0f,0f,0f));
				newObject.GetComponentInChildren<HostileModifier>().Hostile = true; 
			}
		}
		double rows2 = 2;
		for (float cursor = distLeft; cursor < distRight; cursor += (Random.Range(1.5f, 5f))) 
		{
			for (double i = 1; i < rows2; i += Random.Range(1f,2f))
			{
				Instantiate(LargeCyclinder, new Vector3(cursor, 1.5f, Camera.main.transform.position.z + 43f + (float)i ), Quaternion.Euler(0f,0f,0f));
				var newObject = Instantiate(Sphere, new Vector3(cursor, 3.5f, Camera.main.transform.position.z + 43f + (float)i ), Quaternion.Euler(0f,0f,0f));
				newObject.GetComponentInChildren<HostileModifier>().Hostile = true; 
			}
		}
		double rows3 = 2;
		for (float cursor = distLeft; cursor < distRight; cursor += (Random.Range(1.5f, 5f))) 
		{
			for (double i = 1; i < rows3; i += Random.Range(1f,2f))
			{
				Instantiate(LargeCyclinder, new Vector3(cursor, 1.5f, Camera.main.transform.position.z + 46f + (float)i ), Quaternion.Euler(0f,0f,0f));
				var newObject = Instantiate(Sphere, new Vector3(cursor, 3.5f, Camera.main.transform.position.z + 46f + (float)i ), Quaternion.Euler(0f,0f,0f));
				newObject.GetComponentInChildren<HostileModifier>().Hostile = true; 
			}
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	void CreateWall()
	{
		
	}

	void CreateCircle()
	{
		
	}
}
