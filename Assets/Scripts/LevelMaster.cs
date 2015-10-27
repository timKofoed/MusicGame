using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class LevelMaster : MonoBehaviour {

	public int levelScore;
	public GameObject Spawn;
    public int health;
    public Notes[] AvailableNotes;
    
	private GameController gameController;
	private AudioSource backgroundMusic;
	private int maxHealth;

    public bool gameOver = false;
    public float pitchOnSqueal;
    public float pitchSquealSeconds;
    public AudioMixer audioMixer;
    
    // Use this for initialization
    void Start ()
	{
		maxHealth = health;	//remember how much health we have in the beginning, so we can reset to that amount later   
		Spawn = GameObject.Find("SpawnPoint_Parent");
		backgroundMusic = this.gameObject.GetComponent<AudioSource> ();
		backgroundMusic.Stop ();	//make sure the music doesn't start on its own
		//startLevel ();
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
	}

	public void StopLevel()
	{
		Debug.Log ("Stopping level");
		Spawn.GetComponent<SpawnScript> ().GameStarted = false;
		backgroundMusic.Stop ();
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
		gameController.SubmitScore (levelScore, "Player1");
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

    //public RuntimeAnimatorController NoteAnimation;


}
