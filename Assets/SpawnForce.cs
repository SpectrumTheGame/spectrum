using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnForce : MonoBehaviour {

	public GameObject wavePrefab;

	public bool triggered;
    public float amplitude;

	// Use this for initialization
	void Start () {
		
	}

	void Spawn () {
        GameObject midpoint = transform.GetChild(1).gameObject;
        Vector3 newPos = new Vector3(transform.position.x, midpoint.transform.position.y, 0.0f);
        GameObject wave = Instantiate (wavePrefab, newPos, midpoint.transform.rotation);
        wave.GetComponent<MoveWave>().amplitude = amplitude;
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			Spawn ();
			triggered = false; 
		}
	}
}
