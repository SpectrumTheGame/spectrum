using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	// Use this for initialization
	void Start () {		
	}

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1.0f);

        Camera.main.GetComponent<changeScene>().resetScene();
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
