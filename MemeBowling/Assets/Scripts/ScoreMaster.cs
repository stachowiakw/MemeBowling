using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {
    
    //return  a list of cumulative scores, like a normal score card.
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativesScores = new List<int>();
        int runningTotal = 0;
        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativesScores.Add(runningTotal);
        }

        return cumulativesScores;
    }

    // return a list of individual frame scores, not cummulative
    public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frameList = new List<int>();

        // your code

        return frameList;
    }
}
