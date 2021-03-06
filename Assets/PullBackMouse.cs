﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PullBackMouse : MonoBehaviour {

    Vector3 offset;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        GetComponentInParent<VibrateStringMouse>().stopAnimation();
    }

private void OnMouseDrag()
    {
        float originalY = transform.localPosition.y;
        Vector3 newPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPos);
        transform.localPosition = new Vector3(transform.localPosition.x, originalY, 0.0f);
        GetComponentInParent<VibrateStringMouse>().amplitude = transform.localPosition.x;
    }

    private void OnMouseUp()
    {
        GetComponentInParent<VibrateStringMouse>().startAnimation();
    }
}
