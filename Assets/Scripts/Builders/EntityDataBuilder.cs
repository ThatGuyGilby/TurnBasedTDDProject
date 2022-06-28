using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDataBuilder : Builder
{
    int level = 5;

    public EntityDataBuilder WithLevel(int level)
    {
        this.level = level;
        return this;
    }

    public EntityData Build(SpeciesKey speciesKey = SpeciesKey.CHARMANDER)
    {
        SpeciesData speciesData = HelperFunctions.SpeciesDataFromSpeciesKey(speciesKey);

        return new EntityData(speciesData.name, level, speciesKey, speciesData);
    }
}
