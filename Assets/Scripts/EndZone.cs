using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {

	LevelMaster levelMaster;
	public int score;
    GameObject levelMasterObj;
    public GameObject goodScorePartcle;
    public GameObject badScorePartcle;

    // Use this for initialization
    void Start ()
	{
        levelMaster = GameObject.Find("LevelMaster").GetComponent<LevelMaster>();
        levelMasterObj = GameObject.Find("LevelMaster"); 

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter (Collider other)
	{

        levelMaster.AddScore(other.GetComponent<Node>().endValue);
        if (other.GetComponent<Node>().bad == true)
        {
            //levelMaster.health -= 1;
            levelMaster.DH();
            Instantiate(badScorePartcle, other.gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(goodScorePartcle, other.gameObject.transform.position, Quaternion.identity);
        }


        Destroy(other.gameObject.transform.root.gameObject);

	}



}
