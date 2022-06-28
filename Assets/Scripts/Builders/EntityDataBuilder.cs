using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDataBuilder : SuperBuilder
{
    public static EntityData Build(SpeciesKey speciesKey)
    {
        SpeciesData speciesData = HelperFunctions.SpeciesDataFromSpeciesKey(speciesKey);

        return new EntityData(speciesData.name, 5, speciesKey, speciesData);
    }
}
