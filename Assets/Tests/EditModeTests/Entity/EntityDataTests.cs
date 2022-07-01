using NUnit.Framework;

public class EntityDataTests
{
    #region Public Methods

    [TestCase(100, SpeciesKey.CHARMANDER, ExpectedResult = 140)]
    public int EntityAttackCalculatedCorrectly(int level, SpeciesKey speciesKey)
    {
        Entity entity = new EntityBuilder().WithLevel(level).WithSpecies(speciesKey).Build();

        return entity.Attack;
    }

    [TestCase(100, SpeciesKey.CHARMANDER, ExpectedResult = 122)]
    public int EntityDefenceCalculatedCorrectly(int level, SpeciesKey speciesKey)
    {
        Entity entity = new EntityBuilder().WithLevel(level).WithSpecies(speciesKey).Build();

        return entity.Defence;
    }

    [TestCase(100, SpeciesKey.CHARMANDER, ExpectedResult = 219)]
    public int EntityHealthCalculatedCorrectly(int level, SpeciesKey speciesKey)
    {
        Entity entity = new EntityBuilder().WithLevel(level).WithSpecies(speciesKey).Build();

        return entity.Health;
    }

    [TestCase(100, SpeciesKey.CHARMANDER, ExpectedResult = 156)]
    public int EntitySpecialAttackCalculatedCorrectly(int level, SpeciesKey speciesKey)
    {
        Entity entity = new EntityBuilder().WithLevel(level).WithSpecies(speciesKey).Build();

        return entity.SpecialAttack;
    }

    [TestCase(100, SpeciesKey.CHARMANDER, ExpectedResult = 136)]
    public int EntitySpecialDefenceCalculatedCorrectly(int level, SpeciesKey speciesKey)
    {
        Entity entity = new EntityBuilder().WithLevel(level).WithSpecies(speciesKey).Build();

        return entity.SpecialDefence;
    }

    [TestCase(100, SpeciesKey.CHARMANDER, ExpectedResult = 166)]
    public int EntitySpeedCalculatedCorrectly(int level, SpeciesKey speciesKey)
    {
        Entity entity = new EntityBuilder().WithLevel(level).WithSpecies(speciesKey).Build();

        return entity.Speed;
    }

    #endregion Public Methods
}