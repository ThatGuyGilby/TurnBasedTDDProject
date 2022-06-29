using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBuilder : IBuilder<Entity>
{
    private string nickname;
    private int level;
    private SpeciesKey speciesKey;

    public EntityBuilder()
    {
        this.nickname = "";
        this.level = 1;
        this.speciesKey = SpeciesKey.CHARMANDER;
    }

    public EntityBuilder WithNickname(string nickname)
    {
        this.nickname = nickname;
        return this;
    }
    public EntityBuilder WithLevel(int level)
    {
        this.level = level;
        return this;
    }

    public EntityBuilder WithSpecies(SpeciesKey speciesKey)
    {
        this.speciesKey = speciesKey;
        return this;
    }

    public Entity Build()
    {
        EntityData entityData = new EntityDataBuilder().WithNickname(nickname).WithLevel(level).WithSpecies(speciesKey).Build();

        return new Entity(entityData);
    }
}
