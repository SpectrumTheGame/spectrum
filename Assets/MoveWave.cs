using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWave : MonoBehaviour {

	GameObject ball;
	Rigidbody2D rb;
	bool isLeft;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("Ball");
		Debug.Log (ball.transform.position);
		rb = ball.GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.1f, 0, 0);

		Vector3 diff = transform.position - ball.transform.position;
		if (diff.magnitude < 1) {
			rb.AddForce(transform.right * 5.0f);
		}

		if (transform.position.x > 7) {
			Destroy (this.gameObject);
		}
	}
}
