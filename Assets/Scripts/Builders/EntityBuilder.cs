using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBuilder : SuperBuilder
{
    public static Entity Build(SpeciesKey speciesKey)
    {
        EntityData entityData = EntityDataBuilder.Build(speciesKey);

        return new Entity(entityData);
    }
}
