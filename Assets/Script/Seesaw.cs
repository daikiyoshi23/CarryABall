using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour {
    
    public GameObject playerStage;
	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {

        Transform katamuki = playerStage.GetComponent<Transform>();

        float kakudo = katamuki.transform.localEulerAngles.z    ;

        transform.rotation = Quaternion.Euler(0, 0, kakudo);
		
	}

   
}
