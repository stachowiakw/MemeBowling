using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    private Ball ball;
    public Text StandingPinsCounter;
    private int numberOfStandingPins;
    private bool ballEnteredBox;
    public GameObject PinSet;

    public float timerCheck = 3f;
    private int tempStandingPins;
    private float timer = 0;

    private int lastSettledCount = 10;

    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>(); 
        ball = GameObject.FindObjectOfType<Ball>();
        //Invoke("raisePins", 5);
        //Invoke("lowerPins", 9);
    }

    // Update is called once per frame
    void Update() {
        if (ballEnteredBox)
        {
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

        if (action == ActionMaster.Action.Tidy) { animator.SetTrigger("tidyTrigger"); }
        else if (action == ActionMaster.Action.EndTurn) { animator.SetTrigger("resetTrigger"); }
        else if (action == ActionMaster.Action.Reset) { animator.SetTrigger("resetTrigger"); }
        else if (action == ActionMaster.Action.EndGame) { throw new UnityException("Don't know how to handle end game yet"); }


        ballEnteredBox = false;
        ball.Restart();
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            StandingPinsCounter.color = Color.red;
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

    public void newPinsSet()
    {
        if (numberOfStandingPins == 0)
        {
            Instantiate(PinSet);
        }
    }
}