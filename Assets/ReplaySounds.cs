using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySounds : MonoBehaviour {


    //private AudioSource curr;
    private float t;

    
	// Use this for initialization
	void Start () {
	}

    IEnumerator Play(AudioSource curr, int i)
    {
        yield return new WaitForSeconds(0.3f * i);
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
