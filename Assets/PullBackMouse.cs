﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public triggered



public class PullBackMouse : MonoBehaviour {

    private Vector3 offset;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = new Vector3(Input.mousePosition.x, 0, 10.0f);
        newPos = Camera.main.ScreenToWorldPoint(newPos) + offset;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
