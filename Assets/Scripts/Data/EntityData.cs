using System.Collections.Generic;

public class EntityData
{
    #region Public Fields

    public int level;
    public string nickname;
    public SpeciesData speciesData;
    public SpeciesKey speciesKey;

    #endregion Public Fields

    #region Persistant Data

    public bool alive;
    public int currentHealth;
    public List<MoveslotData> moveslotDatas;

    #endregion Persistant Data

    #region Stats

    public int attack;
    public int defence;
    public int health;
    public int specialAttack;
    public int specialDefence;
    public int speed;

    #endregion Stats

    #region Public Constructors

    public EntityData(string nickname, int level, SpeciesKey speciesKey, SpeciesData speciesData, List<MoveslotData> moveslotDatas)
    {
        this.nickname = nickname;
        this.level = level;
        this.speciesKey = speciesKey;
        this.speciesData = speciesData;
        this.moveslotDatas = moveslotDatas;
    }

    #endregion Public Constructors
}