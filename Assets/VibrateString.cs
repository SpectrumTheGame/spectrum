using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateString : MonoBehaviour {

    public float amplitude;
    public float frequency;

    private float startTime;

	// Use this for initialization
	void Start () {
        int numPoints = transform.childCount;
        for (int i = 0; i < numPoints; i++)
        {
            GameObject c = transform.GetChild(i).gameObject;
            c.transform.position = new Vector3(0, i, 0);
        }

        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;
        int numPoints = transform.childCount;
        for (int i = 0; i < numPoints; i++)
        {
            float x = amplitude * Mathf.Sin(frequency * i) * Mathf.Sin(Mathf.PI * t);
            float x_d = x * Mathf.Exp(-t / 2.0f);
            Debug.Log(t + " " + x);
//            *Mathf.Sin(Mathf.PI * t) *

            GameObject c = transform.GetChild(i).gameObject;
            c.transform.position = new Vector3(x_d, i, 0);
        }


    }
}
