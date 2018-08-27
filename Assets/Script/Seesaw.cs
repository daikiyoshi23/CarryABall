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
        //PlayerStageのSeeSawの傾きに合わせて、ステージのSeeSawを傾ける
        Transform katamuki = playerStage.transform;

        //Z軸を軸とした傾きの情報を取得する
        float kakudo = katamuki.transform.localEulerAngles.z    ;

        //各ステージに反映させる
        transform.rotation = Quaternion.Euler(0, 0, kakudo);
		
	}

   
}
