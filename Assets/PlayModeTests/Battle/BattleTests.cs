using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BattleTests
{
    [Test]
    public void BattleIsInitializedCorrectly()
    {
        Battle battleManager = new Battle();

        battleManager.InitializeBattle();

        Assert.IsTrue(battleManager.IsInitialized);
    }
}
