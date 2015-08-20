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

        LevelMaster.GetComponent<LevelMaster>().LevelScore += other.GetComponent<Node>().endValue;


		Destroy(other.gameObject.transform.root.gameObject);

	}



}
