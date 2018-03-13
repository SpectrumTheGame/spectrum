using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	private GameObject flashScreen;

	// Use this for initialization
	void Start () {        
		flashScreen = GameObject.Find ("flash screen");
		flashScreen.SetActive (false);
	}

	IEnumerator Pause()
	{
		yield return new WaitForSeconds(1.0f);
		StartCoroutine (flash ());

		Camera.main.GetComponent<changeScene>().resetScene();
	}

	IEnumerator flash() {
		flashScreen.SetActive (true);
		yield return new WaitForSeconds (1.0F);
		flashScreen.SetActive (false);
	} 

    // Update is called once per frame
    void Update () {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

		// Got rid of Math.abs because doesn't seem needed?
		if (pos.x > Screen.width || pos.x < 0.0f)
		{
			StartCoroutine(Pause());
		}

		if (pos.y > Screen.height || pos.y < 0.0f)
		{
			StartCoroutine(Pause());
		}
    }
}
