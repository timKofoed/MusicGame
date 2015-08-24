using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {

	LevelMaster levelMaster;
	public int score;

	// Use this for initialization
	void Start ()
	{
        levelMaster = GameObject.Find("LevelMaster").GetComponent<LevelMaster>();

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter (Collider other)
	{

        levelMaster.AddScore(other.GetComponent<Node>().endValue);


		Destroy(other.gameObject.transform.root.gameObject);

	}



}
