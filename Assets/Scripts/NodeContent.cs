using UnityEngine;
using System.Collections;

public class NodeContent : MonoBehaviour {

	public Renderer textRenderer;	//The Renderer of the text-image which represents the number of points received

	public void SetPointImage(Texture2D newImage)
	{
		textRenderer.material.mainTexture = newImage;
	}
}
