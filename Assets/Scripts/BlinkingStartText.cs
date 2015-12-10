using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkingStartText : MonoBehaviour {

	public Image[] pressToStartImages;
	private int pressIndex = 0;
	public bool shouldBlink = true;
    private bool isBlinking = false;


    public void VerifyBlinking()
    {
        if (!isBlinking)
            Blink(5f, 5f);
    }

	// Use this for initialization
	void Start () {
		//Begin by disabling ALL images
		//Blink ();
	}
	
	// Update is called once per frame
	void Update () {
        VerifyBlinking();
	}

    // When this script is disabled for any reason (its GameObject is disabled, or the script is specifically disabled)
    void OnDisable()
    {
        isBlinking = false;
    }

    public void Blink(float initialInvisibleSec = 0.1f, float fadeInSec = 0.1f)
	{
        isBlinking = true;
        StartCoroutine( FadeIn(initialInvisibleSec, fadeInSec) );

		for (int i = 0; i < pressToStartImages.Length; i++) 
		{
			pressToStartImages[i].enabled = false;
		}
		StartCoroutine (BeginBlinking (0.1f));
	}

    private IEnumerator FadeIn(float waiting, float fadein)
    {
        // set all invisible
        for (int i = 0; i < pressToStartImages.Length; i++)
        {
            pressToStartImages[i].color = new Color(pressToStartImages[i].color.r, pressToStartImages[i].color.g, pressToStartImages[i].color.b, 0.0f);
        }

        yield return new WaitForSeconds(waiting);

        float startTime = Time.realtimeSinceStartup;
        float endTime = Time.realtimeSinceStartup + fadein;

        while (Time.realtimeSinceStartup < endTime)
        {
            // set all slightly more visible
            float percentage = 1.0f - ((endTime - Time.realtimeSinceStartup) / fadein);
            
            for (int i = 0; i < pressToStartImages.Length; i++)
            {
                pressToStartImages[i].color = new Color(pressToStartImages[i].color.r, pressToStartImages[i].color.g, pressToStartImages[i].color.b, percentage);
            }
            yield return new WaitForEndOfFrame();
        }

        // Finally, make sure it's completely visible
        for (int i = 0; i < pressToStartImages.Length; i++)
        {
            pressToStartImages[i].color = new Color(pressToStartImages[i].color.r, pressToStartImages[i].color.g, pressToStartImages[i].color.b, 1.0f);
        }

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
            StartCoroutine(BeginBlinking(blinkingDelay));	//redo this function
	}
}
