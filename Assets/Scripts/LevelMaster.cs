using UnityEngine;
using System.Collections;

public class LevelMaster : MonoBehaviour {

	public int LevelScore;
	public GameObject Spawn;
    public Notes[] AvailableNotes;




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

    public Notes DetermineType()
    {
        Notes returnNote;
        //assigns a random number to the object that determines the value
        int typeValue = Random.Range(0, AvailableNotes.Length - 1);


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


}
