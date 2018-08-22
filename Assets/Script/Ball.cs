using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private bool ballreaction;
    GameObject effectObj;

    
	// Use this for initialization
	void Start () {
        ballreaction = true;
        effectObj = Resources.Load<GameObject>("Effect/Hit_02");

    }

    // Update is called once per frame
    void Update () {
		if(ballreaction == true)
        {
            ballreaction = false;
        }
        else
        {
            ballreaction = true;
        }
	}

    //ボールがステージに落ちた際にエフェクトを出す
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Stage")
        {
            GameObject effect = Instantiate(effectObj, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(effect, 1f);
        }
        
    }

}
