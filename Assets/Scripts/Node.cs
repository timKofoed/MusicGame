using UnityEngine;
using System.IO;
using System.Collections;

public class Node : MonoBehaviour 
{

    public Material material;

	public int hitValue;
	public int endValue;

    private LevelMaster levelMaster;

    //private RuntimeAnimatorController anim;

    private Notes noteType;

	public GameObject scoreSystem;

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
        render.material = material;
        render.material.color = noteType.colour;
        

    }
	
	// Update is called once per frame
	void Update () 
	{

        

	}

	public void EndAnimation()
	{
        
	}


    //gives point and destroyes gameobject when clicked by mouse
	public void OnMouseDown ()
	{
        //Debug.Log ("Click, Nu skal der INSTANTIATES ET PARTICLE SYSTEM, og DENNE DESTROYED");
        //If dette Gameobject.tag = Bonus, Tilføjes bonuspoint eller Liv eller power-up;
        //paticlesystem instantiates her

        levelMaster.AddScore(hitValue);
		Instantiate (scoreSystem, gameObject.transform.position, Quaternion.identity);
		Destroy (this.gameObject.transform.root.gameObject);

	}


	

    



    /*Not in use made for touch (don't bother)
    void OnTouchDown()
    {


        Destroy(this.gameObject.transform.root.gameObject);
    }*/
}
