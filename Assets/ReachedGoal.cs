using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedGoal : MonoBehaviour {

	private GameObject ball;
	public bool isTransitioning = false;
	public float scaleSpeed = 0.3F;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isTransitioning) {
			Destroy (ball);
			blowUpGoal();
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		
		if (collision.gameObject.name == "ball") {
			ball = collision.gameObject;
			Debug.Log ("ball collided!!");
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
		Debug.Log (transform.localScale);

		// reset flag when target position/size achieved
		if (transform.position == centerPos && transform.localScale.x > maxScale.x) {
			isTransitioning = false;
		}

	}

}
