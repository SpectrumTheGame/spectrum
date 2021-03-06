﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnForce : MonoBehaviour {

	public GameObject wavePrefab;

	public bool triggered;
    public float amplitude;
	public float waveLen; 

	// Use this for initialization
	void Start () {
		
	}

	void Spawn () {
		GameObject midpoint = transform.GetChild(1).gameObject;
		Vector3 newPos = midpoint.transform.position;
		GameObject wave = Instantiate (wavePrefab, newPos, midpoint.transform.rotation);
		wave.transform.localPosition = new Vector3(wave.transform.localPosition.x, wave.transform.localPosition.y, 0.0f);
        wave.GetComponent<MoveWave>().amplitude = amplitude;
//		wave.transform.localScale = new Vector3(0.1f*waveLen, waveLen, 1); 
		wave.transform.localScale = new Vector3(0.5f*waveLen, waveLen * 0.3f, 1);
		if (amplitude > 0) {
			wave.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			Spawn();
			triggered = false; 
		}
	}
}
