using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster : MonoBehaviour {
    //private int[] bowls = new int[21];
    private int bowl = 1;

    public enum Action {Tidy, Reset, EndTurn, EndGame};
    

    public Action Bowl (int pins)
    {
        if (pins == 11)
        {
            return Action.Reset;
        }

        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid Pins");
        }

        if (pins == 10)
        {
            bowl += 2;
            return Action.EndTurn;
        }

        if (bowl % 2 != 0)
        {
            bowl += 1;
            return Action.Tidy;
        }
        else if (bowl % 2 == 0)
        {
            bowl += 1;
            return Action.EndTurn;
        }

        // other behaviour here
        throw new UnityException("Not sure what action to return!");
    }
}
