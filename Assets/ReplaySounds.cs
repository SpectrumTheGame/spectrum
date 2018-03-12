using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySounds : MonoBehaviour {

    public List<Vector3> positions;
    public List<Material> materials;

    //private AudioSource curr;
    private float t;

	// Use this for initialization
	void Start () {
        positions = new List<Vector3>();
        materials = new List<Material>();
}

    IEnumerator Play(AudioSource curr, int i)
    {
        yield return new WaitForSeconds(0.5f * i);
        Camera.main.GetComponent<FireworkAnimation>().startAnimation(positions[i], materials[i]);
        curr.Play();
    }

    public void PlayAllSounds()
    {
        int i = 0;
        foreach (var audio in Camera.main.gameObject.GetComponents<AudioSource>())
        {
            StartCoroutine(Play(audio, i));
            i++;
        }

    }

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
        {
            PlayAllSounds();
        }
	}
}
