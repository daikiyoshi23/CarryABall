using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    //ボールが落ちた時の音
    AudioClip ballsound;

    //音を出すためのオーディオソース
    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        //ProjectのResourcesフォルダに入れた音を取得する
        ballsound = Resources.Load<AudioClip>("Audio/DM-CGS-45");
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //ボールタグのものが触れた時、音を出し、1秒後にその音を破棄する
        if(other.tag == "Ball")
        {
            audioSource.PlayOneShot(ballsound);
            Destroy(gameObject, 1f);
        }   
    }
}
