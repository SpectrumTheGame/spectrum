using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullString : MonoBehaviour {

	public VibrateString vibrate_script;
	private bool touching = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if a touch is detected (currently only works when a singular touch is happening, doesn't work for multiple touches)
		if (Input.touchCount == 1) {
			Debug.Log ("daeun touching is " + touching);
			foreach (Touch touch in Input.touches) {
				if ((touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) && touching == false) {
					Debug.Log ("daeun HEREEEEE");
					Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10.0f));
//					offset = transform.position - touchPosWorld;
					Vector2 touchPosWorld2D = new Vector2 (touchPosWorld.x, touchPosWorld.y);
					RaycastHit2D hitInformation = Physics2D.Raycast (touchPosWorld2D, Vector2.zero);
					if (hitInformation.collider != null) {
						Debug.Log ("daeun hitting something");
						// We should have hit something with a 2D Physics collider!
						GameObject touchedObject = hitInformation.transform.gameObject;
						//delete later
						Camera.main.backgroundColor = Color.red;
						touching = true;
						vibrate_script.StartAnimation();

						// uncomment later
//						if (touchedObject.name == "Line") {
//							Camera.main.backgroundColor = Color.red;
//							touching = true;
//							vibrate_script.StartAnimation ();
////						} else {
////							touching = false;
//						}
					} else {
						Debug.Log ("daeun not hitting anything");
						Camera.main.backgroundColor = Color.yellow;
					}
				} else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended) {
//					touching = false;
					Camera.main.backgroundColor = Color.gray;
				}
//				if (touch.phase == TouchPhase.Moved && touching == true) {
////					Vector3 newPos = new Vector3 (touch.position.x, touch.position.y, 10.0f);
////					transform.position = Camera.main.ScreenToWorldPoint (newPos) + offset;
////					lines [0].SetPosition (1, transform.position);
////					lines [1].SetPosition (0, transform.position);
//				} else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended) {
//					touching = false;
//					Camera.main.backgroundColor = Color.gray;
//				}
			}
		}
	}

	public void TurnOffTouching() {
		touching = false;
	}
}
