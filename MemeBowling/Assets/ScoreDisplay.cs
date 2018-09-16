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
        string scoresString = FormatRolls(rolls);
        for (int i = 0; i < rolls.Count; i++)
        { rollTexts[i].text = scoresString[i].ToString(); }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i=0; i < frames.Count;i++)
        { frameTexts[i].text = frames[i].ToString(); }
    }

    public static string FormatRolls(List<int> rools)
    {
        string output = "";
        return (output);
    }
}
