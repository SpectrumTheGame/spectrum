using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateString : MonoBehaviour {

    public float amplitude;
    public float frequency;
	public PullString pull_script;

    private float startTime;
	private bool animating = false;

	// Use this for initialization
	void Start () {
        int numPoints = transform.childCount;
        for (int i = 0; i < numPoints; i++)
        {
            GameObject c = transform.GetChild(i).gameObject;
            c.transform.position = new Vector3(0, i, 0);
        }

//        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - startTime;
		if (animating == true && t < 5.0f) {
			Debug.Log("daeun ANIMATING AT " + t + " sec");
			int numPoints = transform.childCount;
			for (int i = 0; i < numPoints; i++) {
				float x = amplitude * Mathf.Sin (frequency * i) * Mathf.Sin (Mathf.PI * t);
				float x_d = x * Mathf.Exp (-t / 2.0f);
				Debug.Log (t + " " + x);
				//            *Mathf.Sin(Mathf.PI * t) *

				GameObject c = transform.GetChild (i).gameObject;
				c.transform.position = new Vector3 (x_d, i, 0);
			}
		} else if (animating == true && t >= 5.0f) {
			Debug.Log("daeun TURNING OFF ANIMATION AT " + t + " sec");
			animating = false;
			pull_script.TurnOffTouching ();
		}


    }

	public void StartAnimation() {
		Debug.Log ("daeun STARTING TO ANIMATE around " + startTime);
		startTime = Time.time;
		animating = true;
//		Animate();
	}

//	private void Animate() {
//		float t = Time.time - startTime;
//		while (t < 5.0f) { // only lets the animation last 5 sec (this is a temp solution for while there is no damping)
//			Debug.Log("daeun ANIMATING startTime is " + startTime + " sec");
//			Debug.Log("daeun ANIMATING Time.time is " + Time.time + " sec");
//			Debug.Log("daeun ANIMATING AT " + t + " sec");
//			int numPoints = transform.childCount;
//			for (int i = 0; i < numPoints; i++) {
//				float x = amplitude * Mathf.Sin (frequency * i) * Mathf.Sin (Mathf.PI * t);
//				float x_d = x * Mathf.Exp (-t / 2.0f);
//				Debug.Log (t + " " + x);
//				//            *Mathf.Sin(Mathf.PI * t) *
//
//				GameObject c = transform.GetChild (i).gameObject;
//				c.transform.position = new Vector3 (x_d, i, 0);
//			}
//			t = Time.time - startTime;
//		}
//		pull_script.TurnOffTouching ();
//
//	}
}
