using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour {

	public GameObject string1; 
	public GameObject string2; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			SpawnForce string1Spawn = string1.GetComponent<SpawnForce> ();
			string1Spawn.triggered = true;
		}	

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			SpawnForce string2Spawn = string2.GetComponent<SpawnForce> ();
			string2Spawn.triggered = true;
		}	
	}
}
