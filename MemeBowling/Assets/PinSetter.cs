using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    private Ball ball;
    public Text StandingPinsCounter;
    private int numberOfStandingPins;
    private bool ballEnteredBox;

    public float timerCheck = 3f;
    private int tempStandingPins;
    private float timer = 0;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        if (ballEnteredBox)
        {
            timer=timer+(1 * Time.deltaTime);
            if (timer <= timerCheck)
            {
                if (!(tempStandingPins == countStandingPins()))
                {
                    timer = 0f;
                    tempStandingPins = countStandingPins();
                }
            }
            else
            {
                PinsHaveSettled();
            }
        }
        //timer debug was used this// StandingPinsCounter.text = timer.ToString();
        // print("PINS SATTLED: " + pinsSattled);
    }
    private void PinsHaveSettled()
    {
        StandingPinsCounter.color = Color.green;
        ballEnteredBox = false;
        ball.Restart();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            StandingPinsCounter.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Pin>())
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }

    int countStandingPins()
    {
        numberOfStandingPins = 0;
        foreach (Pin Pinn in GameObject.FindObjectsOfType<Pin>())
        {
            if (Pinn.isStillStanding())
            { numberOfStandingPins++; }
        }
        StandingPinsCounter.text = numberOfStandingPins.ToString();
        return numberOfStandingPins;
    }
}