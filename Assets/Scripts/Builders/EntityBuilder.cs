using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBuilder : Builder
{
    string nickname = "";
    int level = 5;

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

    public Entity Build(SpeciesKey speciesKey = SpeciesKey.CHARMANDER)
    {
        EntityData entityData = new EntityDataBuilder().WithNickname(nickname).WithLevel(level).Build(speciesKey);

        return new Entity(entityData);
    }
}
