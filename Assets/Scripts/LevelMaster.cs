using UnityEngine;
using System.Collections;

public class LevelMaster : MonoBehaviour {

	public int LevelScore;
	public GameObject Spawn;
    public int health;
    public Notes[] AvailableNotes;
    

    

    public bool gameOver = false;
    



    // Use this for initialization
    void Start ()
	{
        
		Spawn = GameObject.Find("SpawnPoint_Parent");
		startLevel ();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

	void startLevel()
	{
	
		Spawn.GetComponent<SpawnScript> ().GameStarted = true;
	}

    public void AddScore(int addedScore) 
    {
        LevelScore += addedScore;
        
    }

    public Notes DetermineType()
    {
        Notes returnNote;
        //assigns a random number to the object that determines the value
        int typeValue = Random.Range(0, AvailableNotes.Length);


        returnNote = AvailableNotes[typeValue];
        return returnNote;
     }

    public void DH()
    {
        health -= 1;
        Debug.Log("Health left:" + health);
        if (health <= 0)
        {
            Debug.Log("Gameover");
            gameOver = true;
            GameOver();
            
        }
    }

    private void GameOver()
        {
            Time.timeScale = 0;
            
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

    public bool bad;

    //public RuntimeAnimatorController NoteAnimation;


}
