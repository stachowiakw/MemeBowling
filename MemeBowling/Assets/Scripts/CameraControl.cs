using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    private GameObject ball;
    private Vector3 camOffset;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.Find("Ball");
        camOffset = gameObject.transform.position - ball.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (ball.transform.position.z <= 1829)
        {
            transform.position = ball.transform.position + camOffset;
        }
	}
}
