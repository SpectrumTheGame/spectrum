using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnForce : MonoBehaviour {

	public GameObject wavePrefab;

	// bool set from input scripts
	public bool triggered; 

	// Use this for initialization
	void Start () {
		
	}

	void Spawn () {
		GameObject wave = Instantiate (wavePrefab, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			Spawn ();
			triggered = false; 
		}
	}
}
