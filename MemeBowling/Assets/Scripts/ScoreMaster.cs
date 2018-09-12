using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {
    // roll = it is a score achieved in a single bowl.
    // rolls = roll many times.

    //return a list of cumulative scores, like a normal score card.
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
        List<int> frames= new List<int>();

        for (int i = 1; i < rolls.Count; i += 2)
        {
            if(frames.Count == 10 ) { break; }                      // prevent goint to the 11th frame which does not exist
                
            if (rolls[i - 1] +rolls[i] < 10)                        // normal "open" frame
            { frames.Add(rolls[i - 1] + rolls[i]); }

            if (rolls.Count - 1 <= 1) { break; }                    // Insufficient look-ahead

            if (rolls[i - 1] == 10)                                 // STRIKE
            { i--; frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
    }       else if (rolls[i - 1] + rolls[i] == 10)                 // calculate SPARE bonus
            { frames.Add(10 + rolls[i + 1]); }
        }
        return frames;
    }
}
