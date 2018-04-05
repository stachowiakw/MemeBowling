using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchPanelScript : MonoBehaviour {
    private Vector3 SlidePointStart;
    private Vector3 SlidePointEnd;
    private Vector3 ThrowVector;
    private Ball ball;
    private float clickTime;
    private bool clicked;

    // Use this for initialization
    void Start () {
        clicked = false;
        ball = GameObject.Find("Ball").GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (clicked)
        {
            clickTime = clickTime + 1 * Time.deltaTime;
        }
	}

    public void TestInputClick()
    {
        if (!ball.ballLaunched)
        {
            clicked = true;
            SlidePointStart = Input.mousePosition;
            print(SlidePointStart);
        }
    }

    public void TestInputUp()
    {
        clicked = false;
        if (!ball.ballLaunched)
        {
            SlidePointEnd = Input.mousePosition;
            ThrowVector = SlidePointEnd - SlidePointStart;
            float throwForce = ThrowVector.y * (1 / clickTime);
            ball.Launch(ThrowVector, throwForce);
            
            print("THROW FORCE: " + throwForce);
        }
    }
}
