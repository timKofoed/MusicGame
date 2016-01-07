using UnityEngine;
using System.Collections;

public class BackgroundObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DestroyThis()
    {
        Debug.Log("Object To Destroy: " + this.gameObject.transform.parent.gameObject.name);
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
