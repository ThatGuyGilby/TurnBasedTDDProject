using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MVPTests
{
    [Test]
    public void MVPSimpleBattleTest()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Player player = new PlayerBuilder().WithEntity(charmander).Build();
        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayer(player).WithWeatherKey(WeatherKey.SUN).Build();

        int hpBefore = bulbasaur.CurrentHealth;

        battle.SendPlayerInput(0);
        battle.SendPlayerInput(0);
        battle.SendPlayerInput(0);
        battle.SendPlayerInput(0);
        battle.SendPlayerInput(0);

        int hpAfter = bulbasaur.CurrentHealth;

        Assert.AreNotSame(hpBefore, hpAfter);
    }
}