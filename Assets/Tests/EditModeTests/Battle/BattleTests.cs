using NUnit.Framework;
using System;

public class BattleTests
{
    [Test]
    public void BattleInitialize()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).WithWeatherKey(WeatherKey.SUN).Build();

        battle.Initialize();

        Assert.IsTrue(battle.IsInitialized);
    }

    [Test]
    public void BattleInitializeEnemyAbovePartyLimit()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur, 7).WithPlayerEntity(charmander).Build();

        var ex = Assert.Throws<Exception>(() => battle.Initialize());

        Assert.That(ex.Message, Is.EqualTo($"Invalid enemy party size: 7"));
    }

    [Test]
    public void BattleInitializeEnemyNull()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Battle battle = new BattleBuilder().WithPlayerEntity(charmander).Build();

        var ex = Assert.Throws<Exception>(() => battle.Initialize());

        Assert.That(ex.Message, Is.EqualTo($"Invalid enemy party size: 0"));
    }

    [Test]
    public void BattleInitializePlayerAbovePartyLimit()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander, 7).Build();

        var ex = Assert.Throws<Exception>(() => battle.Initialize());

        Assert.That(ex.Message, Is.EqualTo($"Invalid player party size: 7"));
    }

    [Test]
    public void BattleInitializePlayerNull()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Battle battle = new BattleBuilder().WithEnemyEntity(charmander).Build();

        var ex = Assert.Throws<Exception>(() => battle.Initialize());

        Assert.That(ex.Message, Is.EqualTo($"Invalid player party size: 0"));
    }

    [Test]
    public void BattleQueueAndExecuteCommand()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        charmander.Initialize();

        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();
        bulbasaur.Initialize();

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).Build();
        battle.Initialize();

        ICommand playerAttackEnemyCommand = new EntityAttackEntityCommand(charmander, bulbasaur, MoveKey.FLAMETHROWER, battle);
        battle.QueueCommand(playerAttackEnemyCommand);
        battle.ExecuteQueuedCommands();

        Assert.IsFalse(battle.ActiveEnemyEntity.IsAlive());
    }

    [TestCase("Fire", WeatherKey.SUN, ExpectedResult = 1.5f)]
    [TestCase("Water", WeatherKey.SUN, ExpectedResult = 0.5f)]
    [TestCase("Water", WeatherKey.RAIN, ExpectedResult = 1.5f)]
    [TestCase("Fire", WeatherKey.RAIN, ExpectedResult = 0.5f)]
    public float BattleWeatherMultiplier(string attributeString, WeatherKey weatherKey)
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).WithWeatherKey(weatherKey).Build();

        battle.Initialize();

        return battle.GetWeatherMultiplier(attributeString);
    }
}