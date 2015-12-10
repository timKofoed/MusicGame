using UnityEngine;
using System.IO;
using System.Collections;

public class Node : MonoBehaviour 
{
    public enum PowerUpType
    {
        None = 0,
        SpeedUp = 1,
        SlowDown = 2,
        ExtraLife = 3
    }
    public Material material;

	public int hitValue;
	public int endValue;

    private LevelMaster levelMaster;

    public bool bad;

    //private RuntimeAnimatorController anim;

    private Notes noteType;

	public GameObject scoreSystem;

	public Texture2D[] pointImages;

	// Use this for initialization
	void Start () 
	{

        //anim = noteType.NoteAnimation;
        //gameObject.GetComponent<Animator>().runtimeAnimatorController = anim;

        Renderer render = gameObject.GetComponent<Renderer>();
        levelMaster = GameObject.Find("LevelMaster").GetComponent<LevelMaster>();
        noteType = levelMaster.DetermineType();
        endValue = noteType.endValue;
        hitValue = noteType.hitValue;
        material = noteType.material;
        bad = noteType.bad;
        scoreSystem = noteType.scoreSystem; 
        render.material = material;
        render.material.color = noteType.colour;

        levelMaster.RegisterNode(this);
    }
	
	// Update is called once per frame
	void Update () 
	{

        

	}

	public void EndAnimation()
	{
        
	}

    public void SetAnimationSpeed(float newSpeed)
    {
        this.gameObject.GetComponent<Animator>().speed = newSpeed;
    }

    //gives point and destroyes gameobject when clicked by mouse
	public void OnMouseDown ()
	{
        //Debug.Log ("Click, Nu skal der INSTANTIATES ET PARTICLE SYSTEM, og DENNE DESTROYED");

        //paticlesystem instantiates her

        if(noteType.powerUpType != Node.PowerUpType.None)
        {
            // This is a powerup
            if (noteType.powerUpType == Node.PowerUpType.ExtraLife)
                levelMaster.AddLife();
            else if (noteType.powerUpType == Node.PowerUpType.SpeedUp)
                levelMaster.SetLevelSpeed(1.2f, 5.0f);
            else if (noteType.powerUpType == Node.PowerUpType.SlowDown)
                levelMaster.SetLevelSpeed(0.8f, 5.0f);
        }
        else
        {
            // This is a normal node

            if (bad == false)
            {
                levelMaster.LoseLife();
            }
        }

        

		hitValue = Mathf.RoundToInt((float)hitValue / 5.0f) * 5;	//snap til 5, 10, 15, 20, etc.
        levelMaster.AddScore(hitValue);	//tilføj points


		// 
		//vælg en af de point-billeder der er lavet ved at dividere points med 5, og sørge for at vi ikke får et negativt tal (Abs)
		GameObject newScoreObject = Instantiate (scoreSystem, gameObject.transform.position, Quaternion.identity) as GameObject;	//og gem en reference til det nye objekt

		//Debug.Log ("name: ("+newScoreObject.GetComponentInChildren<Renderer> ().name+")");
		Debug.Log ("newScoreObject.GetComponent<NodeContent>().name: " + newScoreObject.GetComponent<NodeContent>().name);
		int index = Mathf.Abs (hitValue / 5) - 1;
		Debug.Log ("index: " + index);
        //newScoreObject.GetComponent<NodeContent>().SetPointImage( pointImages [index] );
        //newScoreObject.GetComponentInChildren<Renderer> ().material.mainTexture = pointImages [Mathf.Abs (hitValue / 5) - 1];	//i det nye objekt, ændrer vi billedet afhængigt af hvor mange point der gives
        levelMaster.RemoveNode(this);
		Destroy (this.gameObject.transform.root.gameObject);

	}


	

    



    /*Not in use made for touch (don't bother)
    void OnTouchDown()
    {


        Destroy(this.gameObject.transform.root.gameObject);
    }*/
}
