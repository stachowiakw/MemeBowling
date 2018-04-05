using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 50f;
    Animator animator;
    Vector3 angels;
    Rigidbody rigidbody;


    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        angels = gameObject.transform.rotation.eulerAngles;
        print(angels);
        //Invoke("printAngels", 5);
    }

    void printAngels()
    {
        print(gameObject.transform.rotation.eulerAngles);
        print(isStillStanding());
    }

    public bool isStillStanding()
    {
        angels = gameObject.transform.rotation.eulerAngles;
        float tiltX = Mathf.Abs(angels.x);
        float tiltZ = Mathf.Abs(angels.z);
        if (((tiltX <= standingThreshold) || (tiltX > 360-standingThreshold)) && ((tiltZ <= standingThreshold) || (tiltZ > 360-standingThreshold))) { return true; }
        else { return false; }
    }

    public void goUp()
    {
        rigidbody.useGravity = false;
        animator.SetTrigger("pinGoUpTrigger");
    }
}
