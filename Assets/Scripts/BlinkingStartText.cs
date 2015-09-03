using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkingStartText : MonoBehaviour {

	public Image[] pressToStartImages;
	private int pressIndex = 0;
	public bool shouldBlink = true;

	// Use this for initialization
	void Start () {
		//Begin by disabling ALL images
		Blink ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Blink()
	{
		for (int i = 0; i < pressToStartImages.Length; i++) 
		{
			pressToStartImages[i].enabled = false;
		}
		StartCoroutine (BeginBlinking (0.1f));
	}

	private IEnumerator BeginBlinking(float blinkingDelay)
	{
		//Debug.Log ("Blink "+pressIndex+" delay: "+blinkingDelay);
		int prevIndex = ((pressIndex - 1) >= 0)? (pressIndex - 1) : pressToStartImages.Length-1;

		pressToStartImages [prevIndex].enabled = false;
		pressToStartImages [pressIndex++].enabled = true;	//enable the current index, then increment the index counter
		yield return new WaitForSeconds (blinkingDelay);

		//if we're out of the index, then reset to 0
		if (pressIndex > (pressToStartImages.Length-1)) 
			pressIndex = 0;

		if (this.isActiveAndEnabled)
			StartCoroutine (BeginBlinking (blinkingDelay));	//redo this function
	}
}
