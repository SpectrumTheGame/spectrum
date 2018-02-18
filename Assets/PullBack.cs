using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBack : MonoBehaviour {

    public GameObject anchor1;
    public GameObject anchor2;
    public LineRenderer[] lines;

    private float[] lineLengths;
    public float moveSpeed = 5f;
    private Vector3 offset;

    
    // Use this for initialization
    void Start () {
        lines = new LineRenderer[2];

        LineRenderer lineRenderer1 = anchor1.AddComponent<LineRenderer>();
        lineRenderer1.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer1.widthMultiplier = 0.1f;
        lineRenderer1.startColor = Color.white;
        lineRenderer1.endColor = Color.white;
        lineRenderer1.SetPosition(0, anchor1.transform.position);
        lineRenderer1.SetPosition(1, transform.position);
        lines[0] = lineRenderer1;

        LineRenderer lineRenderer2 = gameObject.AddComponent<LineRenderer>();
        lineRenderer2.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer2.widthMultiplier = 0.1f;
        lineRenderer2.startColor = Color.white;
        lineRenderer2.endColor = Color.white;
        lineRenderer2.SetPosition(0, transform.position);
        lineRenderer2.SetPosition(1, anchor2.transform.position);
        lines[1] = lineRenderer2;
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPos) + offset;

        lines[0].SetPosition(1, transform.position);
        lines[1].SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update () {

    }
}
