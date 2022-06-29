using System.Collections.Generic;

public class EntityDataBuilder : IBuilder<EntityData>
{
    #region Private Fields

    private int level;
    private string nickname;
    private SpeciesKey speciesKey;

    #endregion Private Fields

    #region Public Constructors

    public EntityDataBuilder()
    {
        this.nickname = "";
        this.level = 1;
        this.speciesKey = SpeciesKey.CHARMANDER;
    }

    #endregion Public Constructors

    #region Public Methods

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

    #endregion Public Methods
}