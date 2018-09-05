using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest
{
    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endgame = ActionMaster.Action.EndGame;

    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);

        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        int[] rolls = {8};

        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    //[Test]
    //public void T03EloEloMakrelo()
    //{
    //    Assert.AreEqual(reset, actionMaster.Bowl(11));
    //}


    [Test]
    public void T04Bowl28SpareReturnsEndTurn()
    {
        int[] rolls = { 8, 2 };

        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
    //[Test]
    //public void T04Bowl28SpareReturnsEndTurn()
    //{
    //    actionMaster.Bowl(8);
    //    Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    //}

    [Test]
    public void T05CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    //[Test]
    //public void T05CheckResetAtStrikeInLastFrame()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(reset, actionMaster.Bowl(10));
    //}

    [Test]
    public void T06CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    //[Test]
    //public void T06CheckResetAtStrikeInLastFrame()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    actionMaster.Bowl(1);
    //    Assert.AreEqual(reset, actionMaster.Bowl(9));
    //}

    //[Test]
    //public void T07YoutubeRollsEndInEndGames()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 1 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(endgame, actionMaster.Bowl(9));
    //}

    //[Test]
    //public void T08NoBall21Awarded()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(endgame, actionMaster.Bowl(8));
    //}

    //[Test]
    //public void T09Bowl20tidyadterStrike()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(tidy, actionMaster.Bowl(8));
    //}

    //[Test]
    //public void T10KD10PinsOnASecondBowlInAFrame()
    //{
    //    int[] rolls = { 0, 10, 1 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(endTurn, actionMaster.Bowl(5));
    //}

    //[Test]
    //public void T12Dondi10thFrameTurkey()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(reset, actionMaster.Bowl(10));
    //    Assert.AreEqual(reset, actionMaster.Bowl(10));
    //    //Assert.AreEqual(endgame, actionMaster.Bowl(10));
    //}

    //[Test]
    //public void T13ZeroOneGivesEndTurn()
    //{
    //    actionMaster.Bowl(0);
    //    Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    //}
}