using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// This controller should handle (re)starting the level, selecting level, displaying the highscore, etc.
public class GameController : MonoBehaviour {

	//Canvas objects to hide/show
	public GameObject gameUI;
	public GameObject mainScreen;
    [SerializeField]
    private MainScreenController mainScreenController;

	public LevelMaster levelMaster;	//the current level master available (this could be mulitple levelMasters if we have more levels)
	private HighSoreScript highScoreScript;
	public BlinkingStartText blinkingStartText;

	private bool isWaitingForKeypress = true;

	private float delay = 2.0f;
	private bool isBlocked = false;	//prevent the level from starting
    public InputField nameInputField;

	// Use this for initialization
	void Start () 
	{
		ResetLevel (false);
		highScoreScript = this.gameObject.GetComponent<HighSoreScript> ();
        
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (!isBlocked && isWaitingForKeypress && Input.anyKeyDown && !highScoreScript.isNameTypingInProgress()) 
		{
			isWaitingForKeypress = false;
			gameUI.SetActive (true);		//Show the gameUI (score)
			mainScreen.SetActive (false);	//Hide the main screen (PressKeyToStart / Highscore?)
			levelMaster.startLevel(this);		
		}
	}

    public void SetMainScreenUI(MainScreenController.UIState newUIState)
    {
        mainScreenController.SetUIState(newUIState);
    }
    
	//Reset the level and optionally delay the ability to start the level. If you don't pass a parameter, then it will be "true".
	public void ResetLevel(bool shouldDelay = true)
	{
		Debug.Log ("ResetLevel");
		isWaitingForKeypress = true;
		gameUI.SetActive (false);		//Hide the gameUI (score)
		mainScreen.SetActive (true);    //Show the main screen (PressKeyToStart / Highscore?)
        mainScreenController.SetUIState(MainScreenController.UIState.PressToStart);

        //blinkingStartText.Blink (5.0f, 5.0f);


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
