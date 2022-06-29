using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EntityFunctionTests
{
    [TestCase(SpeciesKey.CHARMANDER, "Fire", 1.5f)]
    [TestCase(SpeciesKey.CHARMANDER, "Grass", 1f)]
    [TestCase(SpeciesKey.BULBASAUR, "Grass", 1.5f)]
    [TestCase(SpeciesKey.BULBASAUR, "Water", 1f)]
    public void EntityGetSTABMMultiplier(SpeciesKey speciesKey, string attributeString, float expectedMultiplier)
    {
        Entity entity = new EntityBuilder().WithSpecies(speciesKey).Build();

        float actual = entity.GetSTABMultiplier(attributeString);
        float expected = expectedMultiplier;

        Assert.AreEqual(expected, actual);
    }

    [TestCase(SpeciesKey.CHARMANDER, "Fire", 0.5f)]
    [TestCase(SpeciesKey.CHARMANDER, "Grass", 0.5f)]
    [TestCase(SpeciesKey.BULBASAUR, "Ice", 2f)]
    [TestCase(SpeciesKey.BULBASAUR, "Water", 0.5f)]
    public void EntityGetIncomingMMultiplier(SpeciesKey speciesKey, string attributeString, float expectedMultiplier)
    {
        Entity entity = new EntityBuilder().WithSpecies(speciesKey).Build();

        float actual = entity.GetIncomingMultiplier(attributeString);
        float expected = expectedMultiplier;

        Assert.AreEqual(expected, actual);
    }

    [TestCase(5)]
    [TestCase(25)]
    [TestCase(50)]
    public void EntityTakeDamageBelowZero(int damageToTake)
    {
        Entity entity = new EntityBuilder().Build();

        entity.TakeDamage(damageToTake);

        bool isBelowZero = (entity.CurrentHealth < 0);

        Assert.IsFalse(isBelowZero);
    }

    [TestCase(-5)]
    [TestCase(-25)]
    [TestCase(-50)]
    public void EntityTakeDamageNeggativeInput(int damageToTake)
    {
        Entity entity = new EntityBuilder().Build();

        int hpBefore = entity.CurrentHealth;

        entity.TakeDamage(damageToTake);

        int hpAfter = entity.CurrentHealth;

        bool healthIncreased = (hpAfter > hpBefore);

        Assert.IsFalse(healthIncreased);
    }

    [Test]
    public void EntityDie()
    {
        Entity entity = new EntityBuilder().Build();

        entity.Die();

        Assert.IsFalse(entity.IsAlive());
    }
}
