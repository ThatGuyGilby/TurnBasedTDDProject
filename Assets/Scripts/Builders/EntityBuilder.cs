using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBuilder : Builder
{
    int level = 5;

    public EntityBuilder WithLevel(int level)
    {
        this.level = level;
        return this;
    }

    public Entity Build(SpeciesKey speciesKey = SpeciesKey.CHARMANDER)
    {
        EntityData entityData = new EntityDataBuilder().WithLevel(level).Build(speciesKey);

        return new Entity(entityData);
    }
}
