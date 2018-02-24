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
        GameObject midpoint = transform.GetChild(1).gameObject;
        Vector3 newPos = new Vector3(transform.position.x, midpoint.transform.position.y, 0.0f);
        GameObject wave = Instantiate (wavePrefab, newPos, midpoint.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			Spawn ();
			triggered = false; 
		}
	}
}
