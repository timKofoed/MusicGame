﻿using UnityEngine;
using System.Collections;

// This controller should handle (re)starting the level, selecting level, displaying the highscore, etc.
public class GameController : MonoBehaviour {

	//Canvas objects to hide/show
	public GameObject gameUI;
	public GameObject mainScreen;

	public LevelMaster levelMaster;	//the current level master available (this could be mulitple levelMasters if we have more levels)
	private HighSoreScript highScoreScript;
	public BlinkingStartText blinkingStartText;

	private bool isWaitingForKeypress = true;

	private float delay = 2.0f;
	private bool isBlocked = false;	//prevent the level from starting

	// Use this for initialization
	void Start () 
	{
		ResetLevel (false);
		highScoreScript = this.gameObject.GetComponent<HighSoreScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isBlocked && isWaitingForKeypress && Input.anyKeyDown) 
		{
			isWaitingForKeypress = false;
			gameUI.SetActive (true);		//Show the gameUI (score)
			mainScreen.SetActive (false);	//Hide the main screen (PressKeyToStart / Highscore?)
			levelMaster.startLevel(this);		
		}
	}

	//Reset the level and optionally delay the ability to start the level. If you don't pass a parameter, then it will be "true".
	public void ResetLevel(bool shouldDelay = true)
	{
		Debug.Log ("ResetLevel");
		isWaitingForKeypress = true;
		gameUI.SetActive (false);		//Hide the gameUI (score)
		mainScreen.SetActive (true);	//Show the main screen (PressKeyToStart / Highscore?)
		blinkingStartText.Blink ();

		if(shouldDelay)
			StartCoroutine (PreventLevelStart());
	}

	public IEnumerator PreventLevelStart()
	{
		isBlocked = true;
		yield return new WaitForSeconds(delay);
		isBlocked = false;
	}

	public void SubmitScore(int newScore, string userName)
	{
		highScoreScript.UpdateScoreOnDisk (newScore, userName);
	}
}
