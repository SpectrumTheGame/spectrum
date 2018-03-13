using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingAnimation : MonoBehaviour {

	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float timeElapsed = Time.time - startTime;
		float scale = 4.8f + Mathf.Sin (5 * timeElapsed)/2;
		transform.localScale = new Vector3 (scale, scale, 0);
	}
}
