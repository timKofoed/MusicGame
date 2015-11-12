using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class LevelMaster : MonoBehaviour {

	public int levelScore;
	public GameObject Spawn;
    public int health;
    public Notes[] AvailableNotes;
    public GameObject lifeIcon;
    public GameObject[] lifeArray;
    
	private GameController gameController;
	private AudioSource backgroundMusic;
	private int maxHealth;

    public bool gameOver = false;
    public float pitchOnSqueal;
    public float pitchSquealSeconds;
    public AudioMixer audioMixer;

    public GameObject prefabScoreSystemGood;    //adding a default score system, so I don't have to manually enter one
    public GameObject prefabScoreSystemBad;    //adding a default score system, so I don't have to manually enter one

    [SerializeField]    //reveal this private field in the editor
    private List<Node> nodesOnScreen;

    // Use this for initialization
    void Start ()
	{
		maxHealth = health;	//remember how much health we have in the beginning, so we can reset to that amount later   
        nodesOnScreen = new List<Node>(); //Make a 'new' List, so we're ready to put items into it

		Spawn = GameObject.Find("SpawnPoint_Parent");
		backgroundMusic = this.gameObject.GetComponent<AudioSource> ();
		backgroundMusic.Stop ();	//make sure the music doesn't start on its own
		//startLevel ();

        for (int i = 0; i < AvailableNotes.Length; i++)
        {
            if (AvailableNotes[i].scoreSystem == null)
            {
                if(AvailableNotes[i].hitValue > 0)
                    AvailableNotes[i].scoreSystem = prefabScoreSystemGood;
                else
                    AvailableNotes[i].scoreSystem = prefabScoreSystemBad;
            }
        }

	}

    /// <summary>
    /// When a new Node is made, it should tell the level master that it exists
    /// </summary>
    /// <param name="nodeToAdd"></param>
    public void RegisterNode(Node nodeToAdd)
    {
        nodesOnScreen.Add(nodeToAdd);
    }

    /// <summary>
    /// When a node is being destroyed for any reason, it should tell the Level master that it's gone
    /// </summary>
    /// <param name="nodeToRemove"></param>
    public void RemoveNode(Node nodeToRemove)
    {
        nodesOnScreen.Remove(nodeToRemove);
    }

	// Update is called once per frame
	void Update ()
    {
	    
	}

	// Start the level and pass a reference to the gameController, so we have a reference to it
	public void startLevel( GameController newGameController )
	{
		Debug.Log ("Starting level");
		gameOver = false;
		gameController = newGameController;
		Spawn.GetComponent<SpawnScript> ().BeginSpawning ();
		backgroundMusic.Play ();
		health = maxHealth;	//reset the amount of health we have
		levelScore = 0;

        lifeArray = new GameObject[health];

        for (int i = 0; i > health; i++)
        {
            lifeArray[i] = Instantiate(lifeIcon, new Vector3(24.0f - (i * 2), 13.0f, -6), Quaternion.identity) as GameObject;
        }
    }

	public void StopLevel()
	{
		Debug.Log ("Stopping level");
		Spawn.GetComponent<SpawnScript> ().GameStarted = false;
		backgroundMusic.Stop ();

        //Remove all active nodes on screen
        while (nodesOnScreen.Count > 0)
        {
            Destroy(nodesOnScreen[0].transform.root.gameObject);  //Destroy the entire hierarchy of the node being referenced in the array's first spot
            nodesOnScreen.RemoveAt(0);  //Remove the (now empty) first spot reference
            //keep doing this until the array is empty.
        }
	}

    public void AddScore(int addedScore) 
    {
        levelScore += addedScore;
        
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
		//If the game has already ended, then don't apply the lost health
		if (gameOver)
			return;

        MusicSqueak();

        health -= 1;
        Debug.Log("Health left:" + health);
        if (health <= 0)
        {
            Debug.Log("Gameover");
            gameOver = true;
            GameOver();

        }
    }

    public void MusicSqueak()
    {
        StartCoroutine("Squeak");
    }

    private IEnumerator Squeak()
    {
        audioMixer.SetFloat("pitch", pitchOnSqueal);
        yield return new WaitForSeconds(pitchSquealSeconds);
        audioMixer.SetFloat("pitch", 1.0f);
    }

    private void GameOver()
    {
		health = maxHealth;
		StopLevel ();
		gameController.ResetLevel ();
		gameController.SubmitScore (levelScore, "");    //first, we need to check to see if made the highscore
		levelScore = 0;
    }


}


[System.Serializable]
public struct Notes
{
    public string type;

    public Material material;

    public Color colour;
    
    public int health;
    public int hitValue;
    public int endValue;

    public bool bad;

    public GameObject scoreSystem;

    //public RuntimeAnimatorController NoteAnimation;


}
