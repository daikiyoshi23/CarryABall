using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //ボールのすり抜け防止のためのbool
    private bool ballreaction;

    //ボールが次のステージに落ちた時に出すエフェクト
    GameObject effectObj;

    
	// Use this for initialization
	void Start () {
        ballreaction = true;

        //エフェクトをあらかじめ呼び出す
        effectObj = Resources.Load<GameObject>("Effect/Hit_02");

    }

    // Update is called once per frame

    //ボールを極力すり抜けさせないためboolを切り替え続ける（あまり改善されない場合は削除する）
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

            //音も出すので、1秒後にエフェクトを破棄する
            Destroy(effect, 1f);
        }
        
    }

}
