using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public bool GameStarted;
	public bool GameOver; 
	public float GameScore;
	public float DistanceTravelled;
	public Button StartBtn;
	public Text ScoreTxt;
	public Text HighScoreTxt;
	public int ColourChoice;
	public float HighScore;
	private bool _ending;
	private float _timer;
	
	


	void Start ()
	{
		HighScore = PlayerPrefs.GetFloat("HighScore");
		if (HighScore > 0)
		{
			HighScoreTxt.text = "HighScore: " + (int)HighScore; 
		}
		else
		{
			HighScoreTxt.text = "HighScore: 0"; 
		}
		ColourChoice = 1; 
		DistanceTravelled = Camera.main.transform.position.z;
		StartBtn.onClick.AddListener(StartGame);
		GameStarted = false; 
	}
	
	public void StartGame()
	{
		GameStarted = true;
		StartBtn.image = null;
		StartBtn.GetComponentInChildren<Text>().text = null; 
		Destroy(HighScoreTxt);
		Destroy(StartBtn);
	}
	
	void Update()
	{
		if (_ending)
		{
			_timer += Time.deltaTime;
			if (_timer >= 1.5)
			{
				SceneManager.LoadScene("SampleScene");
			}
		}
		if (GameScore >= 90 && GameScore < 190 || GameScore >= 400 && GameScore< 500)
		{
			ColourChoice = 2;
			Camera.main.backgroundColor =
				(Color.Lerp(Camera.main.backgroundColor, new Color(.3f,0.7f,1f), Mathf.PingPong(Time.time, 0.01f)));
		}
		if (GameScore >= 190 && GameScore < 290 || GameScore >= 500 && GameScore< 600)
		{
			ColourChoice = 3;
			Camera.main.backgroundColor =
				(Color.Lerp(Camera.main.backgroundColor, new Color(.0f,0.6f,.1f,0.5f), Mathf.PingPong(Time.time, 0.01f)));
		}
		if (GameScore >= 290 && GameScore < 390 || GameScore >= 700 && GameScore< 800)
		{
			ColourChoice = 4;
			Camera.main.backgroundColor =
				(Color.Lerp(Camera.main.backgroundColor, new Color(1f, 0.92f, 0.016f, 0.8f), Mathf.PingPong(Time.time, 0.01f)));
		}
		
		if (Camera.main.transform.position.z > DistanceTravelled)
		{
			DistanceTravelled = Camera.main.transform.position.z;
		}

		GameScore = DistanceTravelled + 25; 

		ScoreTxt.text = "" + (int) GameScore + "m";
	}

	public void GameEnding()
	{
		_ending = true;
	}
	

}
	
