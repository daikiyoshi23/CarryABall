using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public GameObject WarpPoint;
    
    private void Start()
    {
        WarpPoint.GetComponent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            Transform others = other.GetComponent<Transform>();
            others.transform.position = WarpPoint.transform.position;
        }
    }
}
