using System.Collections;
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
        float originalY = transform.localPosition.y;
        Vector3 newPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPos) + offset;
        transform.localPosition = new Vector3(transform.localPosition.x, originalY, 0.0f);
        GetComponentInParent<VibrateStringMouse>().amplitude = transform.localPosition.x;
    }

    private void OnMouseUp()
    {
        GetComponentInParent<VibrateStringMouse>().startAnimation();
    }
}
