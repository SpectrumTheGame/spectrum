using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWave : MonoBehaviour {

	GameObject ball;
	Rigidbody2D rb;
    public float amplitude; 

    private bool applyingForce; 
	private Renderer rend;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("ball");
		rb = ball.GetComponent<Rigidbody2D> ();
        applyingForce = false;
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.1f * -amplitude, 0, 0);

		if (rend.bounds.Contains (ball.transform.position) 
			&& !applyingForce) {
            applyingForce = true;
            Debug.Log("force!!!");
			rb.AddForce(transform.right * 100.0f * -amplitude);
		} 

		if (transform.position.x > 10 || transform.position.x < -10
			|| transform.position.y > 10 || transform.position.y < -10) {
			Destroy (this.gameObject);
		}
	}
}
