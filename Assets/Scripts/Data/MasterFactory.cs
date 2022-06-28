using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterFactory
{
    public static SpeciesData SpeciesDataFromSpeciesKey(SpeciesKey key)
    {
        switch(key)
        {
            case SpeciesKey.CHARMANDER:
                return new SpeciesData("Charmander", 39, 52, 43, 60, 50, 65);
        }

        return new SpeciesData("Null", -1, -1, -1, -1, -1, -1);
    }

    public static EntityData EntityDataFromSpeciesKey(SpeciesKey speciesKey)
    {
        SpeciesData speciesData = SpeciesDataFromSpeciesKey(speciesKey);

        return new EntityData(speciesData.name, 5, speciesKey, speciesData);
    }
}
