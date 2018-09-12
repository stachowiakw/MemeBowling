using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ScoreTest
{

    [Test]
    public void PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T02Bowl12()
    {
        int[] rolls = { 1, 2 };
        int[] frames = { 3 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames (rolls.ToList()));
    }

    [Test]
    public void T02Bowl1234567890()
    {
        int[] rolls = { 1, 2, 3, 4, 5, 4, 7, 1, };
        int[] frames = { 3, 7, 9, 8 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T03StrikeFirstBowl()
    {
        int[] rolls = { 10, 2, 3 };
        int[] frames = { 15, 5 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T04SpareFirstBowl()
    {
        int[] rolls = { 1, 9, 2, 3 };
        int[] frames = { 12, 5 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }
}