using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public float speedX;
    public float speedY;
    public float power;




    Animator anim;

    public GameObject lefttarget;
    public GameObject righttarget;
    
    Transform ltarget;
    Transform rtarget;
    

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



        float horizontal = Input.GetAxis("Horizontal");
        Transform thistransform = this.transform;

        Vector3 worldPos = thistransform.position;
        worldPos.x = 0f;
        worldPos.y = 0f;
        worldPos.z = 0f;



        if (Input.GetKey("a"))
        {
            transform.Translate(horizontal * speedX, 0, 0, Space.World);
            anim.SetBool("RunLeft", true);
            Vector3 ltargetposition = ltarget.position;

            if (transform.position.y != ltarget.position.y)
            {
                ltargetposition = new Vector3(ltarget.position.x, transform.position.y, ltarget.position.z);
            }
            Quaternion ltargetRotation = Quaternion.LookRotation(ltargetposition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, ltargetRotation, Time.deltaTime * 2f);

        }
        else if (Input.GetKey("d"))
        {
            transform.Translate(horizontal * speedX, 0, 0, Space.World);

            anim.SetBool("RunRight", true);

            Vector3 rtargetposition = rtarget.position;

            if (transform.position.y != rtarget.position.y)
            {
                rtargetposition = new Vector3(rtarget.position.x, transform.position.y, rtarget.position.z);
            }
            Quaternion rtargetRotation = Quaternion.LookRotation(rtargetposition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rtargetRotation, Time.deltaTime * 2f);
        }
        else
        {
            anim.SetBool("RunLeft", false);
            anim.SetBool("RunRight", false);
        }
    }


    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "SeeSaw")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.down * power, transform.position, ForceMode.Force);
        }
    }
}



