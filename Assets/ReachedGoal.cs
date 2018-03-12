using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedGoal : MonoBehaviour {

	public bool isTransitioning = false;
	public float scaleSpeed = 0.3F;
    public bool replayed = false;

	private GameObject ball;

	private Vector3 centerPos;
	private Vector3 maxScale; 
	private Vector3 scaleIncrease = new Vector3 (1.6F, 0.9F, 0); // set to aspect ratio of iphone7

	private GameObject[] transitionButtons; 

	// Use this for initialization
	void Start () {

		// init scale params
		centerPos = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 10.0F));
		maxScale = scaleIncrease * 15.0F;

		// init transition buttons
		transitionButtons = GameObject.FindGameObjectsWithTag ("transitionButton");
		foreach (GameObject t in transitionButtons) {
			t.SetActive(false); 
		}
	}

	// Update is called once per frame
	void Update () {
		if (isTransitioning) {

			// remove ball so it doesn't interact with goal as it transitions
			Destroy(ball);

			// hide objects
			GameObject[] objectsToHide = GameObject.FindGameObjectsWithTag ("hideAfterWinning"); 
			foreach (GameObject o in objectsToHide) {
				o.SetActive(false);
			}

            if (!replayed)
            {
                replayed = true;
                Camera.main.GetComponent<ReplaySounds>().PlayAllSounds();
            }

			blowUpGoal();

			// show buttons
			StartCoroutine(showTransitionButtons());

		}

	}

	IEnumerator showTransitionButtons() {
		yield return new WaitForSeconds (0.5F);
		foreach (GameObject t in transitionButtons) {
			t.SetActive(true); 
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
		Destroy(rb);

		// reset flags when target scale achieved
		isTransitioning = transform.localScale.x < maxScale.x;

		// blow up the goal 
		if (isTransitioning) {
			transform.localScale += scaleIncrease * scaleSpeed;
		}

	}

}
