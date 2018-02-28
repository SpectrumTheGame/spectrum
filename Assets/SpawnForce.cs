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
		Vector3 newPos = midpoint.transform.position;
		GameObject wave = Instantiate (wavePrefab, newPos, midpoint.transform.rotation);
		wave.transform.localPosition = new Vector3(wave.transform.localPosition.x, wave.transform.localPosition.y, 0.0f);
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
