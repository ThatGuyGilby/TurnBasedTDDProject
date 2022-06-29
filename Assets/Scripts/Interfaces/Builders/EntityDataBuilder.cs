using System.Collections.Generic;

public class EntityDataBuilder : IBuilder<EntityData>
{
    private string nickname;
    private int level;
    private SpeciesKey speciesKey;

    public EntityData Build()
    {
        SpeciesData speciesData = HelperFunctions.SpeciesDataFromSpeciesKey(speciesKey);

        if (nickname == "")
        {
            nickname = speciesData.name;
        }

        List<MoveslotData> moveslotDatas = new List<MoveslotData>();

        HelperFunctions.LogReminder("Make the moveslots generate the last 4 moves that pokemon would have learned");

        return new EntityData(nickname, level, speciesKey, speciesData, moveslotDatas);
    }

    public EntityDataBuilder()
    {
        this.nickname = "";
        this.level = 1;
        this.speciesKey = SpeciesKey.CHARMANDER;
    }

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

    public EntityDataBuilder WithSpecies(SpeciesKey speciesKey)
    {
        this.speciesKey = speciesKey;
        return this;
    }
}
