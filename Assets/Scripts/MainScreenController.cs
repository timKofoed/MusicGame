using UnityEngine;
using System.Collections;

public class MainScreenController : MonoBehaviour {

    public enum UIState
    {
        Highscore,
        InputName,
        GameOver,
        PressToStart,
        Playing
    }

    [SerializeField]
    private GameObject highscoreObject;

    [SerializeField]
    private GameObject inputFieldObject;

    [SerializeField]
    private GameObject gameOverObject;

    [SerializeField]
    private GameObject pressStartObject;

    private UIState currentState = UIState.Playing;

    // Use this for initialization
    void Start () {
        this.gameOverObject.SetActive(false);
        this.highscoreObject.SetActive(false);
        this.inputFieldObject.SetActive(false);
        this.pressStartObject.SetActive(false);
    }
	
	// Update is called once per frame (as fast or slow as the computer can do it)
	void Update ()
    {
        switch (currentState)
        {
            case UIState.Highscore:
                //if (this.highscoreObject.activeSelf == false)
                {
                    this.highscoreObject.SetActive(true);
                    this.inputFieldObject.SetActive(false);
                    this.gameOverObject.SetActive(false);
                    this.pressStartObject.SetActive(false);
                }
                   
                break;
            case UIState.InputName:
               // if (this.inputFieldObject.activeSelf == false)
                {
                    this.inputFieldObject.SetActive(true);
                    this.highscoreObject.SetActive(true);
                    this.gameOverObject.SetActive(false);
                    this.pressStartObject.SetActive(false);
                }
                    
                break;
            case UIState.GameOver:
                //if(this.gameOverObject.activeSelf == false)
                {
                    this.gameOverObject.SetActive(true);
                    this.highscoreObject.SetActive(false);
                    this.inputFieldObject.SetActive(false);
                    this.pressStartObject.SetActive(false);
                }
               
                break;
            case UIState.PressToStart:
                if (this.pressStartObject.activeSelf == false)  //only do the following, if it's not already set.
                {
                    this.pressStartObject.SetActive(true);
                    this.highscoreObject.SetActive(true);
                    this.inputFieldObject.SetActive(false);
                    this.gameOverObject.SetActive(false);
                    this.pressStartObject.GetComponent<BlinkingStartText>().Blink(5f, 5f);
                }
                else
                    this.pressStartObject.GetComponent<BlinkingStartText>().VerifyBlinking();

                break;
            case UIState.Playing:
                this.gameOverObject.SetActive(false);
                this.highscoreObject.SetActive(false);
                this.inputFieldObject.SetActive(false);
                this.pressStartObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void SetUIState(UIState newState)
    {
        this.currentState = newState;
    }
}
