using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateString : MonoBehaviour {

    public float amplitude;
    public float frequency;

    private float startTime;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        
        int numPoints = transform.childCount;
        for (int i = 0; i < numPoints; i++)
        {
            GameObject c = transform.GetChild(i).gameObject;
            c.transform.localPosition = new Vector3(0, i, 0);
            Debug.Log("Local "+i+": " + c.transform.localPosition);
            Debug.Log("Absolute "+i+": " + c.transform.position);
        }

        

        startTime = Time.time;
	}

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPos) + offset;

        GameObject c = transform.GetChild(1).gameObject;
        c.transform.position = new Vector3(0, 1, 0);

        //lines[0].SetPosition(1, transform.position);
        //[1].SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update () {
        float t = Time.time - startTime;
        int numPoints = transform.childCount;
        for (int i = 0; i < numPoints; i++)
        {
            float x = amplitude * Mathf.Sin(frequency * i) * Mathf.Sin(Mathf.PI * t);
            float x_d = x * Mathf.Exp(-t / 2.0f);
            //Debug.Log(t + " " + x);

            GameObject c = transform.GetChild(i).gameObject;
            c.transform.localPosition = new Vector3(x_d, i, 0);
        }


    }
}
