using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EntityDataStatCalculationTests
{
    [Test]
    public void EntityHealthCalculatedCorrectly()
    {
        Entity entity = EntityBuilder.Build(SpeciesKey.CHARMANDER);

        entity.SetLevel(100);

        Assert.AreEqual(282, entity.Health);
    }

    [Test]
    public void EntityAttackCalculatedCorrectly()
    {
        Entity entity = EntityBuilder.Build(SpeciesKey.CHARMANDER);

        entity.SetLevel(100);

        Assert.AreEqual(203, entity.Attack);
    }

    [Test]
    public void EntityDefenceCalculatedCorrectly()
    {
        Entity entity = EntityBuilder.Build(SpeciesKey.CHARMANDER);

        entity.SetLevel(100);

        Assert.AreEqual(185, entity.Defence);
    }

    [Test]
    public void EntitySpecialAttackCalculatedCorrectly()
    {
        Entity entity = EntityBuilder.Build(SpeciesKey.CHARMANDER);

        entity.SetLevel(100);

        Assert.AreEqual(219, entity.SpecialAttack);
    }

    [Test]
    public void EntitySpecialDefenceCalculatedCorrectly()
    {
        Entity entity = EntityBuilder.Build(SpeciesKey.CHARMANDER);

        entity.SetLevel(100);

        Assert.AreEqual(199, entity.SpecialDefence);
    }

    [Test]
    public void EntitySpeedCalculatedCorrectly()
    {
        Entity entity = EntityBuilder.Build(SpeciesKey.CHARMANDER);

        entity.SetLevel(100);

        Assert.AreEqual(229, entity.Speed);
    }
}
