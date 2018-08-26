using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    //ワープポイント先
    public GameObject WarpPoint;
    
    private void Start()
    {
        //ワープポイント先の場所情報を取得
        WarpPoint.GetComponent<Transform>();
    }


    private void OnTriggerEnter(Collider other)
    {   
        //ボールタグのオブジェクトが触れた場合、ワープポイント先へ飛ばす
        if(other.tag == "Ball")
        {
            Transform others = other.GetComponent<Transform>();
            others.transform.position = WarpPoint.transform.position;
        }
    }
}
