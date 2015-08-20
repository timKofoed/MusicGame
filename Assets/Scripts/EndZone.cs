using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {

	GameObject LevelMaster;
	public int score;

	// Use this for initialization
	void Start ()
	{
		LevelMaster = GameObject.Find("LevelMaster");

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter (Collider other)
	{
		score = LevelMaster.GetComponent<LevelMaster>().LevelScore;

        /*
		if (other.GetComponent<Node> ().type == "Bad")
		{

			LevelMaster.GetComponent<LevelMaster>().LevelScore += other.GetComponent<Node>().endValue;
		}

		if (other.GetComponent<Node> ().type == "Normal")
		{
			LevelMaster.GetComponent<LevelMaster>().LevelScore += other.GetComponent<Node>().endValue;
		}

		if (other.GetComponent<Node> ().type == "Bonus")
		{
			score += other.GetComponent<Node>().endValue;

		}*/


		Destroy(other.gameObject.transform.root.gameObject);
		Debug.Log ("And... Despawn!");
	/* 	if Tag= "God Node", Destroy other GameObject (+parent?) og giv point;
	 * 	if Tag= "Bad Node", Destroy other GameObject (+parent?), fratag liv og fratag point;
	 * 	if Tag= "Bonus Node", Destroy other GameObject (+parent?);
	 */
	}



}
