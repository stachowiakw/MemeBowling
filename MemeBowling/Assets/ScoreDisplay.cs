using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Accessibility;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollTexts, frameTexts;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i <= 20; i++)
        {
            rollTexts[i].text = " ";
        }
        for (int j = 0; j <= 9; j++)
        {
            frameTexts[j].text = " ";
        }
    }

    public void FillRolls(List<int> rolls)
    {
        print("fillingRolls");
        string[] rollStrings = formatRolls(rolls);
        
        for (int i = 0; i < rolls.Count; i++)
        {
        rollTexts[i].text = rollStrings[i];
        }
    }

    public void FillFrames(List<int> frames)
    {
        print("fillingFrames");
        for (int i=0; i < frames.Count;i++)
        { frameTexts[i].text = frames[i].ToString(); }
    }

    public static string[] formatRolls(List<int> rolls)
    {
        string[] rollStringsTemp = new string [rolls.Count];

        for (int i = 0; i < rolls.Count; i++)
        {
            if ((rolls[i] == 0) && rolls[i + 1] == 10)
            { rollStringsTemp[i] = ""; }
            else if (rolls[i] == 0)
            { rollStringsTemp[i] = "-"; }
            else if (rolls[i] == 10)
            { rollStringsTemp[i] = "X"; }
            else if (((i + 1) % 2 == 0) && (rolls[i] + rolls[i - 1] == 10))
            { rollStringsTemp[i] = "/"; }
            else { rollStringsTemp[i] = rolls[i].ToString(); }           
        }
        return rollStringsTemp;
    }
}
