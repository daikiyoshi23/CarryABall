using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //横移動の速さ
    public float speedX;

    //縦移動の速さ
    public float speedY;

    //シーソーを動かすためのキャラクターから下向きに加える力
    public float power;




    Animator anim;

   　//キャラクターが左に向くときの対象物
    public GameObject lefttarget;
    
    //キャラクターが右に向くときの対象物
    public GameObject righttarget;
    
    //左に向かせる対象物の場所
    Transform ltarget;

    //右に向かせる対象物の場所
    Transform rtarget;
    
    //シーソーを影響させるためのオブジェクト
    public GameObject SeeSaw;


   



    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        ltarget = lefttarget.GetComponent<Transform>();
        rtarget = righttarget.GetComponent<Transform>();
        
        


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //キー移動のため
        float horizontal = Input.GetAxis("Horizontal");

        //キャラクターの現在いる場所
        Transform thistransform = this.transform;

        //キャラクターがワールド空間上で最初にいる場所
        Vector3 worldPos = thistransform.position;
        worldPos.x = 0f;
        worldPos.y = 0f;
        worldPos.z = 0f;


        //矢印キー左を押したとき
        if (Input.GetKey("left"))
        {
            //シーソー上で左側に移動させるための式（そのためのSpace.World)
            transform.Translate(horizontal * speedX, 0, 0, Space.World);

            //左キーを押している間は、アニメーションをtrueにする
            anim.SetBool("RunLeft", true);

            //左キーを押している間は、左側にあるターゲットを見るようにして移動
            Vector3 ltargetposition = ltarget.position;

            //高さが変わっても対象物を見失わないようにする
            if (transform.position.y != ltarget.position.y)
            {
                ltargetposition = new Vector3(ltarget.position.x, transform.position.y, ltarget.position.z);
            }
            Quaternion ltargetRotation = Quaternion.LookRotation(ltargetposition - transform.position);

            //徐々に左に向くようにする
            transform.rotation = Quaternion.Slerp(transform.rotation, ltargetRotation, Time.deltaTime * 2f);

        }

        //矢印キー右を押している時
        else if (Input.GetKey("right"))
        {
            //シーソー上で右側に移動させるための式（そのためのSpace.World)
            transform.Translate(horizontal * speedX, 0, 0, Space.World);

            //右キーを押している間は、アニメーションをtrueにする
            anim.SetBool("RunRight", true);

            //右キーを押している間は、右側にあるターゲットを見るようにして移動
            Vector3 rtargetposition = rtarget.position;
           
            //高さが変わっても対象物を見失わないようにする
            if (transform.position.y != rtarget.position.y)
            {
                rtargetposition = new Vector3(rtarget.position.x, transform.position.y, rtarget.position.z);
            }
            Quaternion rtargetRotation = Quaternion.LookRotation(rtargetposition - transform.position);
            
            //徐々に右に向くようにする
            transform.rotation = Quaternion.Slerp(transform.rotation, rtargetRotation, Time.deltaTime * 2f);
        }
        //それ以外はアニメーションをfalseにする
        else
        {
            anim.SetBool("RunLeft", false);
            anim.SetBool("RunRight", false);
        }
    }

    //シーソーに触れている間、キャラクターのいる場所から下向きに力を加える設定
    void OnCollisionStay(Collision collision)
    {
        //キャラクターがシーソータグだった場合のみ、力を加える
        if (collision.gameObject.tag == "SeeSaw")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.down * power, transform.position, ForceMode.Force);
        }
    }
}



