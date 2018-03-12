using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkAnimation : MonoBehaviour {

    public GameObject starPrefab;

    private Rigidbody2D rb;
    private bool repeating = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void startAnimation(Vector3 position, Material material)
    {
        for (int i = 0; i < Random.Range(7.0f, 9.0f); i++)
        {
            Spawn(position, material);
        }
    }

    void Spawn(Vector3 position, Material material)
    {
        GameObject star = Instantiate(starPrefab, position, Quaternion.identity);
        //star.GetComponent<SpriteRenderer>().color = material.color;

        float scale = Random.Range(0.2f, 0.8f);
        star.transform.localScale = new Vector3(scale, scale, scale);

        star.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), 0);
        star.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
