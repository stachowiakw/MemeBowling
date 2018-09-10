using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {
    private int[] ResultOfBowl = new int[21];
    public int bowlIndex = 1;

    public enum Action {Tidy, Reset, EndTurn, EndGame};

    public static Action NextAction (List<int> pinFalls)
    {
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();

        foreach (int pinFall in pinFalls)
        {
            currentAction = am.Bowl(pinFall);
        }
        return currentAction;
    }

    private Action Bowl (int pins)
    {
        ResultOfBowl[bowlIndex - 1] = pins;

        if (bowlIndex == 21)
        {
            return Action.EndGame;
        }

        if (pins == 11)
        {
            return Action.Reset;
        }

        if (bowlIndex >= 20 && (Bowl21Awarded()) && (ResultOfBowl[19 - 1] == 10))
        {
            if (pins == 10)
            {
                bowlIndex += 1;
                return Action.Reset;

            }
            else
            {
                bowlIndex += 1;
                return Action.Tidy;
            }
        }

        if (bowlIndex>=19 && Bowl21Awarded())
        {
            bowlIndex += 1;
            return Action.Reset;
        }

        if (bowlIndex == 20)
        {
            return Action.EndGame;
        }

        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid Pins");
        }

        if (pins == 10)
        {
            if (bowlIndex % 2 != 0)
            { bowlIndex += 2; }
            else
            { bowlIndex += 1; }
            return Action.EndTurn;
        }

        if (bowlIndex % 2 != 0)
        {
            bowlIndex += 1;
            return Action.Tidy;
        }

        else if (bowlIndex % 2 == 0)
        {
            bowlIndex += 1;
            return Action.EndTurn;
        }

        // other behaviour here
        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded()
    {
        //Remember that arrays start counting at 0
        return (ResultOfBowl[19 - 1] + ResultOfBowl[20 - 1] >= 10);
    }
}
