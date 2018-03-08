using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWave : MonoBehaviour {

	GameObject ball;
	Rigidbody2D rb;
    public float amplitude; 

    private bool applyingForce; 
	private Renderer waveRenderer;
	private Renderer ballRenderer;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("ball");
		if (ball != null) {
			rb = ball.GetComponent<Rigidbody2D> ();
			ballRenderer = ball.GetComponent<Renderer> ();
		}
		
        applyingForce = false;
		waveRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// ball destroyed when reaches goal/transitioning

		transform.Translate(0.1f * -amplitude, 0, 0);

		// don't iteract with the ball if ball doesn't exist
		if (ball == null)
			return; 

		// wave interaction 
		if (waveRenderer.bounds.Intersects (ballRenderer.bounds) 
			&& !applyingForce) {
            applyingForce = true;
			rb.AddForce(transform.right * 100.0f * -amplitude);
		} 

		// destroy the wave when it moves out of bounds
		if (transform.position.x > 10 || transform.position.x < -10
			|| transform.position.y > 10 || transform.position.y < -10) {
			Destroy (this.gameObject);
		}
	}
}
