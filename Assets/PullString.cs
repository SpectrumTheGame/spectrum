using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullString : MonoBehaviour {

    private bool moving;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
                {
                    Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10.0f));
                    Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                    RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Vector2.zero);

                    if (hitInformation.collider != null && GameObject.ReferenceEquals(hitInformation.transform.gameObject, gameObject))
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            GetComponentInParent<VibrateStringMouse>().stopAnimation();
                        }
                        if (touch.phase == TouchPhase.Moved)
                        {
                            float originalY = transform.localPosition.y;
                            transform.position = new Vector3(hitInformation.point.x, hitInformation.point.y, 10.0f);
                            transform.localPosition = new Vector3(transform.localPosition.x, originalY, 0.0f);
                            GetComponentInParent<VibrateStringMouse>().amplitude = transform.localPosition.x;
                        }
                        moving = true;
                    }
                }
                if (touch.phase == TouchPhase.Ended && moving)
                {
                    GetComponentInParent<VibrateStringMouse>().startAnimation();
                    moving = false;
                }

            }
        }
	}
}
