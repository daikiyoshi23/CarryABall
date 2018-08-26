using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    //ゴールのスピード
    public float speed = 2.0f;

    //ゴールを一定の時間で動かすため
    float time;   

    //方向を変えるスイッチ
    public bool change = false;

    //ゴールした時のエフェクト

    GameObject goaleffect;
    
    //ゴールした時、もう一度パーティクルを呼び出さないためのスイッチ
    public bool goal;


    // Use this for initialization
    void Start () {
        time = 0f;
        goal = false;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        //ゴールを一定時間左側に動かす
        if (change == false )
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);

            //一定時間経過したら、反対方向に切り返す
            if (time >= 2.0f)
            {
                change = true;
                time = 0f;
            }
        }
        
        //ゴールを一定時間右側に動かす
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);

            //一定時間経過したら、反対方向に切り返す
            if (time >= 2.0f)
            {
                change = false;
                time = 0f;
            }
        }
	}

    //ボールがゴールに入った場合
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball" && goal == false)
        {
            //エフェクトをゴールの場所に呼び出す
            goaleffect = Resources.Load<GameObject>("Effect/magic_ring_02");
            Instantiate(goaleffect, gameObject.transform.position, new Quaternion(45, transform.rotation.y, transform.rotation.z, transform.rotation.w));
            
            //エフェクトを2度呼び出さないようtrueにする
            goal = true;
            
            //数秒後にクリア画面を呼ぶ
            Invoke("LoadScene", 2f);
        }    
    }

    //クリア画面を呼ぶ関数
    void LoadScene()
    {
        SceneManager.LoadScene("Clear");

    }
}
