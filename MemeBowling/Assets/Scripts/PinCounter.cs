using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    
    private int numberOfStandingPins;
    private int tempStandingPins;
    private int lastSettledCount = 10;
    private float timer = 0;
    private PinSetter pinSetter;
    private GameManager gameManager;
    private Ball ball;
    public float timerCheck = 3f;
    public Text StandingPinsCounter;
    public bool ballOutOfPlay = false;

    // Use this for initialization
    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballOutOfPlay == true && ball.ballLaunched == true)
        {
            StandingPinsCounter.color = Color.red;
            timer = timer + (1 * Time.deltaTime);
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

    public int countStandingPins()
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

    private void PinsHaveSettled()
    {
        int pinFall = lastSettledCount - countStandingPins();
        lastSettledCount = countStandingPins();
        StandingPinsCounter.color = Color.green;
        gameManager.Bowl(pinFall);
        timer = 0;
    }

    public void resetCounter()
    {
        lastSettledCount = 10;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
            print("WYSZŁO SZYDŁO");
        }
    }
}
