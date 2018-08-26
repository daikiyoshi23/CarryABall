using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    //起動時に配置するためのボール
    public GameObject ballprefab;

    //起動時にボールを配置する場所
    Vector3 placeposition = new Vector3(4.39f, 13.27f, 10.69f);

    //最初に出す説明画面
    public GameObject text;

    //ゲームスタートをしたかどうか
    bool gameStart;
	// Use this for initialization
	void Start () {

        //いきなりスタートせず、falseにし、説明画面を表示させるためのbool
        gameStart = false;
    }
	
	// Update is called once per frame
	void Update () {

        //ゲームがスタートしていない状態でスペースキーをクリックしたら、テキストを消し、ゲームスタートさせる
        if (Input.GetKeyDown("space") && gameStart == false)
        {
            Destroy(text);
            Instantiate(ballprefab, placeposition, Quaternion.identity);
            gameStart = false;
        }
    }

   
}
