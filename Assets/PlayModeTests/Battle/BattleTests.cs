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
        Entity charmander = new EntityBuilder().WithLevel(100).Build(SpeciesKey.CHARMANDER);
        Entity bulbasaur = new EntityBuilder().WithLevel(100).Build(SpeciesKey.BULBASAUR);

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).Build();

        battle.Initialize();

        Assert.IsTrue(battle.IsInitialized);
    }
}
