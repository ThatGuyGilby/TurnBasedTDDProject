using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BattleTests
{
    [Test]
    public void BattleIsInitialized()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).Build(SpeciesKey.CHARMANDER);
        Entity bulbasaur = new EntityBuilder().WithLevel(5).Build(SpeciesKey.BULBASAUR);

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).Build();

        battle.Initialize();

        Assert.IsTrue(battle.IsInitialized);
    }

    [Test]
    public void BattleEntityAttacksEntityInitialized()
    {
        Entity charmander = new EntityBuilder().WithLevel(100).Build(SpeciesKey.CHARMANDER);
        Entity bulbasaur = new EntityBuilder().WithLevel(50).Build(SpeciesKey.BULBASAUR);

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).Build();

        battle.Initialize();

        battle.EntityAttackEntity(charmander, bulbasaur, MoveKey.TACKLE);
        battle.EntityAttackEntity(bulbasaur, charmander, MoveKey.TACKLE);

        Assert.IsTrue(battle.IsInitialized);
    }
}
