using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedGoal : MonoBehaviour {

	public bool isTransitioning = false;
	public float scaleSpeed = 0.3F;

	private GameObject ball;
	private GameObject[] lines;

	// Use this for initialization
	void Start () {

		// get lines so we can destroy them with the animation
		lines = GameObject.FindGameObjectsWithTag ("line"); 
	}
	
	// Update is called once per frame
	void Update () {
		if (isTransitioning) {

			// remove ball so it doesn't interact with goal as it transitions
			Destroy (ball);

			// remove lines so they don't show behind goal
			foreach (GameObject line in lines) {
				Destroy (line);
			}

			blowUpGoal();
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		
		if (collision.gameObject.name == "ball") {
			ball = collision.gameObject;
			isTransitioning = true; 
		}
	}

	void blowUpGoal() {
		// disable rigidbody behavior on goal (sliding reaction to forces)
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		Destroy (rb);

		// center the goal 
		float distanceFromCamera = 10.0f;
		Vector3 goalPosition = transform.position;
		Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distanceFromCamera));
		transform.position += (centerPos - goalPosition) / 40.0F;

		// blow up the goal 
		Vector3 scaleIncrease = new Vector3(1.6F, 0.9F, 0); // set to aspect ratio of iphone7
		Vector3 maxScale = scaleIncrease * 5.0F;
		transform.localScale += scaleIncrease * scaleSpeed;

		// reset flag when target position/size achieved
		if (transform.position == centerPos && transform.localScale.x > maxScale.x) {
			isTransitioning = false;
		}

	}

}
