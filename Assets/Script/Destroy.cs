using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour {

    public GameObject ballprefab;
    Vector3 placeposition = new Vector3(4.39f, 13.27f, 10.69f);
    public GameObject text;
    bool GameStart;
	// Use this for initialization
	void Start () {
        GameStart = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && GameStart == false)
        {
            Destroy(text);
            Instantiate(ballprefab, placeposition, Quaternion.identity);
            GameStart = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        SceneManager.LoadScene("GameOver");
    }
}
