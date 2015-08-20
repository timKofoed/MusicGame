using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class touchInput : MonoBehaviour {

	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchOld;

	private RaycastHit hit;

	void Update () {


		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {
			
			touchOld = new GameObject[touchList.Count];		
			touchList.CopyTo(touchOld);
			touchList.Clear();
				
				Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
				
				if (Physics.Raycast(ray, out hit,touchInputMask)){
					
					GameObject recipient = hit.transform.gameObject;
					touchList.Add(recipient);
					
				//uses sendmessage to start a function called OnTouchDown
				if (Input.GetMouseButtonDown(0)){
						recipient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
					}
                
                //uses sendmessage to start a function called OnTouchUp
                if (Input.GetMouseButtonUp(0)){
						recipient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);
					}

                //uses sendmessage to start a function called OnTouchStay
                if (Input.GetMouseButton(0)){
						recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);
					}
					}
					foreach (GameObject g in touchOld){
						if(!touchList.Contains(g)){
							g.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
						}
					}
				}


/*
		if (Input.touchCount > 0) {

			touchOld = new GameObject[touchList.Count];		
			touchList.CopyTo(touchOld);
			touchList.Clear();

			foreach (Touch touch in Input.touches){

				Ray ray = camera.ScreenPointToRay(touch.position);

				if (Physics.Raycast(ray, out hit,touchInputMask)){

					GameObject recipient = hit.transform.gameObject;
					touchList.Add(recipient);


					if (touch.phase == TouchPhase.Began){
						recipient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Ended){
						recipient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Stationary){
						recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Canceled){
						recipient.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			foreach (GameObject g in touchOld){
				if(!touchList.Contains(g)){
							g.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
				}
			}
		}*/
	}
}
