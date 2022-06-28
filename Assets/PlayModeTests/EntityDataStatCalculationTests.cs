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
}
