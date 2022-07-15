using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerDataTests
{
    [Test]
    public void PlayerBuilderBuilds()
    {
        Entity entity = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();

        Player player = new PlayerBuilder().WithEntity(entity).Build();
    }

    [Test]
    public void PlayerBuilderEmptyParty()
    {
        PlayerBuilder playerBuilder = new PlayerBuilder();

        var ex = Assert.Throws<Exception>(() => playerBuilder.Build());

        Assert.That(ex.Message, Is.EqualTo($"Player can not be created with a party size of 0"));
    }

    [TestCase("Gilby")]
    [TestCase("Showbie")]
    [TestCase("Pat")]
    [TestCase("George")]
    public void PlayerBuilderWithName(string name)
    {
        Entity entity = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();

        Player player = new PlayerBuilder().WithEntity(entity).WithName(name).Build();

        Assert.AreEqual(name, player.Name);
    }
}