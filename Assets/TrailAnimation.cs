using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailAnimation : MonoBehaviour {

	public GameObject starPrefab;

	private Rigidbody2D rb;
	private bool repeating = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Spawn() {
		GameObject star = Instantiate (starPrefab, transform.position, Quaternion.identity);

		float scale = Random.Range (0.2f, 0.8f);
		star.transform.localScale = new Vector3 (scale, scale, scale);

		star.transform.position += new Vector3 (Random.Range (-0.5f, 0.5f), Random.Range (-0.5f, 0.5f), 0);

//		Vector2 backDirection = -rb.velocity.normalized;
//		Debug.Log (backDirection);
//
//		Vector2 ballPos = new Vector2(transform.position.x, transform.position.y);
//		Vector2 backPos = ballPos + backDirection;
//
//		Vector2 perpendicular = new Vector2 (backDirection.y, -backDirection.x);
//		Debug.Log (perpendicular);

	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (rb.velocity);
		if (rb.velocity.magnitude > 0.7) {
			if (!repeating) {
				InvokeRepeating ("Spawn", 0, 0.3f);
				repeating = true;
			}
		} else {
			CancelInvoke ();
			repeating = false;
		}

	}
}
