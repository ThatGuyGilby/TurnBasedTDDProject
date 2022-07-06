using NUnit.Framework;

public class EntityDataTests
{
    [TestCase(100, SpeciesKey.CHARMANDER, ExpectedResult = 140)]
    public int EntityAttackCalculatedCorrectly(int level, SpeciesKey speciesKey)
    {
        Entity entity = new EntityBuilder().WithLevel(level).WithSpecies(speciesKey).Build();

        return entity.Attack;
    }

    [TestCase(5, SpeciesKey.CHARMANDER, ExpectedResult = 1)]
    [TestCase(100, SpeciesKey.CHARMANDER, ExpectedResult = 4)]
    [TestCase(5, SpeciesKey.BULBASAUR, ExpectedResult = 2)]
    public int EntityCreatedWithMoves(int level, SpeciesKey speciesKey)
    {
        Entity entity = new EntityBuilder().WithLevel(level).WithSpecies(speciesKey).Build();

        foreach (var item in entity.MoveslotDatas)
        {
            HelperFunctions.Log(item.moveKey.ToString());
        }

        return entity.MoveslotDatas.Count;
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
}