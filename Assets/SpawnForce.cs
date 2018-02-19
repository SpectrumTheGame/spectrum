using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnForce : MonoBehaviour {

	public GameObject wavePrefab;

	// Use this for initialization
	void Start () {
		
	}

	void Spawn () {
		GameObject wave = Instantiate (wavePrefab, transform.position, transform.rotation);
//		wave.AddComponent
//		wave.transform.Translate (20f, 0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Spawn ();
		}
	}
}
