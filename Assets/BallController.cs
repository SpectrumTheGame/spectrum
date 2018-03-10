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
        yield return new WaitForSeconds(2.0f);

        Camera.main.GetComponent<changeScene>().resetScene();
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

        if (Math.Abs(pos.x) > Screen.width)
        {
            StartCoroutine(Pause());
        }

        if (Math.Abs(pos.y) > Screen.height)
        {
            StartCoroutine(Pause());
        }
    }
}
