using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BattleCalculationTests
{
    [Test]
    public void BattleIsInitializedCorrectly()
    {
        BattleManager battleManager = new BattleManager();

        battleManager.InitializeBattle();

        Assert.IsTrue(battleManager.IsInitialized);
    }
}
