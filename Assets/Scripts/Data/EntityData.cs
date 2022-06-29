using System.Collections.Generic;

public class EntityData
{
    public string nickname;
    public int level;
    public SpeciesKey speciesKey;
    public SpeciesData speciesData;

    #region Persistant Data
    public int currentHealth;
    public bool alive;
    public List<MoveslotData> moveslotDatas;
    #endregion Persistant Data

    #region Stats
    public int health;
    public int attack;
    public int defence;
    public int specialAttack;
    public int specialDefence;
    public int speed;
    #endregion Stats

    public EntityData(string nickname, int level, SpeciesKey speciesKey, SpeciesData speciesData, List<MoveslotData> moveslotDatas)
    {
        this.nickname = nickname;
        this.level = level;
        this.speciesKey = speciesKey;
        this.speciesData = speciesData;
        this.moveslotDatas = moveslotDatas;
    }
}
