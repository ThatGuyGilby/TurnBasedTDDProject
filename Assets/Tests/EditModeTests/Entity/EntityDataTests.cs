using NUnit.Framework;

public class EntityDataTests
{
    #region Public Methods

    [Test]
    public void EntityAttackCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build();

        Assert.AreEqual(203, entity.Attack);
    }

    [Test]
    public void EntityDefenceCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build();

        Assert.AreEqual(185, entity.Defence);
    }

    [Test]
    public void EntityHealthCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build();

        Assert.AreEqual(282, entity.Health);
    }

    [Test]
    public void EntitySpecialAttackCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build();

        Assert.AreEqual(219, entity.SpecialAttack);
    }

    [Test]
    public void EntitySpecialDefenceCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build();

        Assert.AreEqual(199, entity.SpecialDefence);
    }

    [Test]
    public void EntitySpeedCalculatedCorrectly()
    {
        Entity entity = new EntityBuilder().WithLevel(100).Build();

        Assert.AreEqual(229, entity.Speed);
    }

    #endregion Public Methods
}