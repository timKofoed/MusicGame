using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

	int score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		score = GameObject.Find ("LevelMaster").GetComponent<LevelMaster> ().LevelScore;
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width - 150, 125, Screen.width, Screen.height), "score:" + score);

	}
}
