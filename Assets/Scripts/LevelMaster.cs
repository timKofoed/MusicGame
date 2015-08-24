using UnityEngine;
using System.Collections;

public class LevelMaster : MonoBehaviour {

	public int LevelScore;
	public GameObject Spawn;
    public Notes[] AvailableNotes;

    public bool gameOver = false;
    



    // Use this for initialization
    void Start ()
	{
        
		Spawn = GameObject.Find("SpawnPoint_Parent");
		startLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void startLevel()
	{
	
		Spawn.GetComponent<SpawnScript> ().GameStarted = true;
	}

    public void AddScore(int addedScore) //den tilføjede health kan både være positiv samt negativ
    {
        LevelScore += addedScore;
        //Debug.Log("NEW HEALTH: " + score);
    }

    public Notes DetermineType()
    {
        Notes returnNote;
        //assigns a random number to the object that determines the value
        int typeValue = Random.Range(0, 3);


        returnNote = AvailableNotes[typeValue];

        return returnNote;
    }

}


[System.Serializable]
public struct Notes
{
    public string type;

    public Material material;

    public Color colour;

    public int hitValue;
    public int endValue;

    //public RuntimeAnimatorController NoteAnimation;


}
