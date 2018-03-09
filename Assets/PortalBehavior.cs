using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour {

    public GameObject ball;
    public GameObject otherPortal;
    public Vector3 inwards;

    private Vector2 vel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        vel = ball.GetComponent<Rigidbody2D>().velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ball)
        {
            
            ball.transform.position = otherPortal.transform.position + (0.9f * inwards);
            ball.GetComponent<Rigidbody2D>().velocity = vel.magnitude * inwards;
        }
    }
}
