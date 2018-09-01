using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public Text StandingPinsCounter;
    
    public GameObject PinSet;
    public float timerCheck = 3f;

    private Ball ball;
    private int numberOfStandingPins;
    private bool ballOutOfPlay = false;
    private int tempStandingPins;
    private float timer = 0;
    private int lastSettledCount = 10;
    private Animator animator;
    ActionMaster actionMaster = new ActionMaster(); // we need it here as we want only 1 instance

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>(); 
        ball = GameObject.FindObjectOfType<Ball>();
        //Invoke("raisePins", 5);
        //Invoke("lowerPins", 9);
    }

    // Update is called once per frame
    public void SetBallOutOfPlay()
    {
        ballOutOfPlay = true;
    }
        
    void Update() {
        if (ballOutOfPlay)
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

    public void raisePins()
    {
        foreach (Pin Pinn in GameObject.FindObjectsOfType<Pin>())
        {
            if (Pinn.isStillStanding())
            {
                Pinn.GetComponent<Rigidbody>().useGravity = false;
                Pinn.GetComponent<Rigidbody>().freezeRotation = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                Pinn.transform.Translate(new Vector3(0, 50, 0), Space.World);
            }
        }
    }

    public void lowerPins()
    {
        print("LOWER_STARTED!");
        foreach (Pin Pinn in GameObject.FindObjectsOfType<Pin>())
        {
            if (Pinn.isStillStanding())
            {
                Pinn.transform.Translate(new Vector3(0, -49, 0), Space.World);
                Pinn.GetComponent<Rigidbody>().useGravity = true;
                Pinn.GetComponent<Rigidbody>().freezeRotation = false;
                print("LOWERDED!");
            }
        }
    }


    private void PinsHaveSettled()
    {
        int pinFall = lastSettledCount - countStandingPins();
        lastSettledCount = countStandingPins();
        StandingPinsCounter.color = Color.green;

        ActionMaster.Action action = actionMaster.Bowl(pinFall);

        Debug.Log("Pinfall " + pinFall + " " + action);

        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.Reset) { 
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle end game yet");
        }

        ballOutOfPlay = false;
        ball.Restart();
        timer = 0;
    }
// OLD CODE
 //   private void OnTriggerEnter(Collider other)
 //   {
 //       if (other.GetComponent<Ball>())
 //       {
 //           ballOutOfPlay = true;
 //           StandingPinsCounter.color = Color.red;
 //      }
 //   }

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

    public void newPinsSet()
    {
        if (numberOfStandingPins == 0)
        {
            Instantiate(PinSet).transform.Translate(new Vector3(0, 50, 0), Space.World);
        }
    }
}