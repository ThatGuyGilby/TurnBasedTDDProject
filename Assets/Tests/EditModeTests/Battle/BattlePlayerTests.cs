using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BattlePlayerTests
{
    [Test]
    public void BattleInitializeWithPlayer()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Player player = new PlayerBuilder().WithEntity(charmander).Build();
        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayer(player).WithWeatherKey(WeatherKey.SUN).Build();

        Assert.IsTrue(battle.IsInitialized);
    }

    [Test]
    public void BattleSendPlayerMove()
    {
        Entity charmander = new EntityBuilder().WithLevel(7).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Player player = new PlayerBuilder().WithEntity(charmander).Build();
        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayer(player).WithWeatherKey(WeatherKey.SUN).Build();

        battle.SendPlayerMove(0);

        battle.ExecuteQueuedCommands();

        Assert.IsFalse(battle.ActiveEnemyEntity.IsAlive());
    }

    [Test]
    public void BattleSendPlayerMoveAboveKnownMoves()
    {
        Entity charmander = new EntityBuilder().WithLevel(7).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Player player = new PlayerBuilder().WithEntity(charmander).Build();
        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayer(player).WithWeatherKey(WeatherKey.SUN).Build();

        var ex = Assert.Throws<Exception>(() => battle.SendPlayerMove(3));

        Assert.That(ex.Message, Is.EqualTo("moveIndex was above the number of known moves"));
    }

    [Test]
    public void BattleSendPlayerMoveAboveMoveLimit()
    {
        Entity charmander = new EntityBuilder().WithLevel(7).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Player player = new PlayerBuilder().WithEntity(charmander).Build();
        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayer(player).WithWeatherKey(WeatherKey.SUN).Build();

        var ex = Assert.Throws<Exception>(() => battle.SendPlayerMove(Constants.NUMBER_OF_LEARNABLE_MOVES));

        Assert.That(ex.Message, Is.EqualTo("moveIndex was above the learnable move limit."));
    }
}