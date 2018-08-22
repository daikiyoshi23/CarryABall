using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public float speed = 2.0f;
    float time;   
    //方向を変えるスイッチ
    public bool change = false;
    Vector3 TransPos;
    GameObject goaleffect;
    //ゴールした時、パーティクルを呼び出さないためのスイッチ
    public bool goal;


    // Use this for initialization
    void Start () {
        TransPos = transform.position;
        time = 0f;
        goal = false;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (change == false )
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            if (time >= 2.0f)
            {
                change = true;
                time = 0f;
            }
        }
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            if (time >= 2.0f)
            {
                change = false;
                time = 0f;
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball" && goal == false)
        {
            goaleffect = Resources.Load<GameObject>("Effect/magic_ring_02");
            Instantiate(goaleffect, gameObject.transform.position, new Quaternion(45, transform.rotation.y, transform.rotation.z, transform.rotation.w));
            goal = true;
            Invoke("LoadScene", 3f);
        }    
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Clear");

    }
}
