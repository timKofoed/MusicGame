using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour 
{

	public float destroyTime;

	void Awake ()
	{
		Destroy(gameObject, destroyTime);
	}
}
