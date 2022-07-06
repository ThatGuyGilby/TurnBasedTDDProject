using System;
using System.Collections.Generic;

public class EntityDataBuilder : IBuilder<EntityData>
{
    private int level;
    private string nickname;
    private SpeciesKey speciesKey;

    public EntityDataBuilder()
    {
        this.nickname = "";
        this.level = 1;
        this.speciesKey = SpeciesKey.CHARMANDER;
    }

    public EntityData Build()
    {
        SpeciesData speciesData = RepositoryManager.speciesDataRepository.DataFromKey(speciesKey);

        if (nickname == "")
        {
            nickname = speciesData.name;
        }

        List<MoveslotData> moveslotDatas = GenerateDefaultMoveslotData(speciesData, level);
        HelperFunctions.LogReminder("Make the moveslots generate the last 4 moves that pokemon would have learned");

        return new EntityData(nickname, level, speciesKey, speciesData, moveslotDatas);
    }

    public EntityDataBuilder WithLevel(int level)
    {
        this.level = level;
        return this;
    }

    public EntityDataBuilder WithNickname(string nickname)
    {
        this.nickname = nickname;
        return this;
    }

    public EntityDataBuilder WithSpecies(SpeciesKey speciesKey)
    {
        this.speciesKey = speciesKey;
        return this;
    }

    private List<MoveslotData> GenerateDefaultMoveslotData(SpeciesData speciesData, int entityLevel)
    {
        List<MoveslotData> defaultMoveslotDatas = new List<MoveslotData>();

        for (int i = speciesData.speciesMoveLearnData.Count - 1; i >= 0; i--)
        {
            int currentMoveLevel = speciesData.speciesMoveLearnData[i].Value;
            string currentMoveString = speciesData.speciesMoveLearnData[i].Key;
            MoveKey moveKey = HelperFunctions.StringToMoveKey(currentMoveString);

            if (currentMoveLevel <= entityLevel)
            {
                if (defaultMoveslotDatas.Count < Constants.NUMBER_OF_LEARNABLE_MOVES)
                {
                    defaultMoveslotDatas.Add(new MoveslotData(moveKey));
                }
            }
        }

        return defaultMoveslotDatas;
    }
}