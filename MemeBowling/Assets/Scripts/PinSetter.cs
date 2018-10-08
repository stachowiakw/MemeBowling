using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public GameObject PinSet;
    private Animator animator;
    private PinCounter pinCounter;
    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        //Invoke("raisePins", 5);
        //Invoke("lowerPins", 9);
    }
        
    public void raisePins()
    {
        foreach (Pin Pinn in GameObject.FindObjectsOfType<Pin>())
        {
            if (Pinn.isStillStanding())
            {
                Pinn.GetComponent<Rigidbody>().useGravity = false;
                Pinn.GetComponent<Rigidbody>().freezeRotation = true;
                Pinn.transform.Translate(new Vector3(0, 50, 0), Space.World);
            }
        }
    }

    public void lowerPins()
    {
        print("LOWER_STARTED!");
        foreach (Pin Pinn in GameObject.FindObjectsOfType<Pin>())
        {
            if (!Pinn.isStillStanding())
            {
                Destroy(Pinn.gameObject); 
            }
            else if (Pinn.isStillStanding())
            {
                Pinn.transform.Translate(new Vector3(0, -49, 0), Space.World);
                Pinn.GetComponent<Rigidbody>().freezeRotation = false;
                Pinn.GetComponent<Rigidbody>().useGravity = true;
                print("LOWERDED!");
            }
        }
    }

    public void performAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.resetCounter();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.resetCounter();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet");
        }
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

    public void newPinsSet()
    {
        if (pinCounter.countStandingPins() == 0)
        {
            Instantiate(PinSet).transform.Translate(new Vector3(0, 50, 0), Space.World);
        }
    }
}