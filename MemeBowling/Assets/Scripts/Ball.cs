using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody rigidbody;
    private AudioSource audioSource;
    private GameObject floor;
    public bool ballLaunched;
    public float throwForceMax;
    public float throwForceMin;
    public float throwForceTweakValue;
    private GameObject startingPositionButtons;
    private bool adjustingInitialPosition;

    // Use this for initialization
    void Start ()
    {
        startingPositionButtons = GameObject.Find("StartingPositionButtons");
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        floor = GameObject.Find("Floor");

        ballLaunched = false;
        rigidbody.useGravity = false;

    }

    public void Launch(Vector3 velocityVector, float throwForce)
    {
        if (!ballLaunched)
        {
            ballLaunched = true;
            rigidbody.useGravity = true;
            rigidbody.velocity = new Vector3(velocityVector.x, -200, Mathf.Clamp((throwForce / 10) * throwForceTweakValue, throwForceMin, throwForceMax));
            startingPositionButtons.SetActive(false);
        }
    }

    public void Restart()
    {
        rigidbody.useGravity = false;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        transform.position = new Vector3(0, 30, 30);
        transform.rotation = Quaternion.identity;
        ballLaunched = false;
        startingPositionButtons.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject == floor)
        { audioSource.Play(); }
    }

    public void moveBallStartingPosition(float offset)
    {
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x + offset, -50, 50), gameObject.transform.position.y, gameObject.transform.position.z);
    }

}
