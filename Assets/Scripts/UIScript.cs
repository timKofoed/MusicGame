using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    //UI Font and Font size
    public Font newFont;
    public int newFontSize;
    public Color newColor;

    //refernce to the Score Text 
    public Text textToUpdate;

    //Refernce to the LevelMaster Script
    LevelMaster levelMaster;

    void Start()
    {

        levelMaster = GameObject.Find("LevelMaster").GetComponent<LevelMaster>();
        textToUpdate.color = newColor;
        textToUpdate.font = newFont;
        textToUpdate.fontSize = newFontSize;
    }
	
	void Update ()
	{
        //Updates the score on the canvas 
        textToUpdate.text = levelMaster.LevelScore.ToString();
	}

	void OnGUI()
	{

        
	}
}
