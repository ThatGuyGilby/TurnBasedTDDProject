using System.Collections.Generic;

[System.Serializable]
public class EntityData
{
    public bool alive;
    public int currentHealth;
    public int level;

    public List<MoveslotData> moveslotDatas;
    public string nickname;
    public SpeciesData speciesData;
    public SpeciesKey speciesKey;

    #region Stats

    public int attack;
    public int defence;
    public int health;
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