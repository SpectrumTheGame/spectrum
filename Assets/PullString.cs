using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullString : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                {
                    Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10.0f));
                    Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                    RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Vector2.zero);
                    if (hitInformation.collider != null && GameObject.ReferenceEquals(hitInformation.transform.gameObject, gameObject))
                    {
                        Camera.main.backgroundColor = Color.yellow;
                    }
                }
            }
        }
	}
}
