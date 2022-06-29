using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EntityStatCalculationTests
{
    [Test]
    public void EntityHealthCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build(SpeciesKey.CHARMANDER);

        Assert.AreEqual(282, entity.Health);
    }

    [Test]
    public void EntityAttackCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build(SpeciesKey.CHARMANDER);

        Assert.AreEqual(203, entity.Attack);
    }

    [Test]
    public void EntityDefenceCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build(SpeciesKey.CHARMANDER);

        Assert.AreEqual(185, entity.Defence);
    }

    [Test]
    public void EntitySpecialAttackCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build(SpeciesKey.CHARMANDER);

        Assert.AreEqual(219, entity.SpecialAttack);
    }

    [Test]
    public void EntitySpecialDefenceCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build(SpeciesKey.CHARMANDER);

        Assert.AreEqual(199, entity.SpecialDefence);
    }

    [Test]
    public void EntitySpeedCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build(SpeciesKey.CHARMANDER);

        Assert.AreEqual(229, entity.Speed);
    }
}