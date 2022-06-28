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
        EntityData entityData = MasterFactory.EntityDataFromSpeciesKey(SpeciesKey.CHARMANDER);

        entityData.level = 100;
        entityData.Update();

        Assert.AreEqual(282, entityData.Health);
    }

    [Test]
    public void EntityAttackCalculatedCorrectly()
    {
        EntityData entityData = MasterFactory.EntityDataFromSpeciesKey(SpeciesKey.CHARMANDER);

        entityData.level = 100;
        entityData.Update();

        Assert.AreEqual(203, entityData.Attack);
    }

    [Test]
    public void EntityDefenceCalculatedCorrectly()
    {
        EntityData entityData = MasterFactory.EntityDataFromSpeciesKey(SpeciesKey.CHARMANDER);

        entityData.level = 100;
        entityData.Update();

        Assert.AreEqual(185, entityData.Defence);
    }

    [Test]
    public void EntitySpecialAttackCalculatedCorrectly()
    {
        EntityData entityData = MasterFactory.EntityDataFromSpeciesKey(SpeciesKey.CHARMANDER);

        entityData.level = 100;
        entityData.Update();

        Assert.AreEqual(219, entityData.SpecialAttack);
    }

    [Test]
    public void EntitySpecialDefenceCalculatedCorrectly()
    {
        EntityData entityData = MasterFactory.EntityDataFromSpeciesKey(SpeciesKey.CHARMANDER);

        entityData.level = 100;
        entityData.Update();

        Assert.AreEqual(199, entityData.SpecialDefence);
    }

    [Test]
    public void EntitySpeedCalculatedCorrectly()
    {
        EntityData entityData = MasterFactory.EntityDataFromSpeciesKey(SpeciesKey.CHARMANDER);

        entityData.level = 100;
        entityData.Update();

        Assert.AreEqual(229, entityData.Speed);
    }
}
