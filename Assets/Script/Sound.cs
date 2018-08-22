using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    AudioClip ballsound;
    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        ballsound = Resources.Load<AudioClip>("Audio/DM-CGS-45");
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            audioSource.PlayOneShot(ballsound);
            Destroy(gameObject, 1f);
        }   
    }
}
