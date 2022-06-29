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
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).Build();

        battle.Initialize();

        Assert.IsTrue(battle.IsInitialized);
    }

    [Test]
    public void BattleEntityAttacksEntityInitialized()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).Build();

        battle.Initialize();

        ICommand playerAttackEnemyCommand = new EntityAttackEntityCommand(charmander, bulbasaur, MoveKey.TACKLE);
        battle.QueueCommand(playerAttackEnemyCommand);

        ICommand enemyAttackPlayerCommand = new EntityAttackEntityCommand(bulbasaur, charmander, MoveKey.TACKLE);
        battle.QueueCommand(enemyAttackPlayerCommand);

        battle.ExecuteQueuedCommands();

        Assert.IsTrue(battle.IsInitialized);
    }
}
