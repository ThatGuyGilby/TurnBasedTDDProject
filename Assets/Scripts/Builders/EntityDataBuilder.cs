using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDataBuilder : Builder
{
    string nickname = "";
    int level = 5;

    public EntityDataBuilder WithNickname(string nickname)
    {
        this.nickname = nickname;
        return this;
    }

    public EntityDataBuilder WithLevel(int level)
    {
        this.level = level;
        return this;
    }

    public EntityData Build(SpeciesKey speciesKey = SpeciesKey.CHARMANDER)
    {
        SpeciesData speciesData = HelperFunctions.SpeciesDataFromSpeciesKey(speciesKey);

        if (nickname == "")
        {
            nickname = speciesData.name;
        }

        return new EntityData(nickname, level, speciesKey, speciesData);
    }
}
