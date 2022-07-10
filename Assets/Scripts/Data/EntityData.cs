using System.Collections.Generic;

public class EntityData
{
    public bool alive;
    public int attack;
    public int currentHealth;
    public int defence;
    public int health;
    public int level;
    public List<MoveslotData> moveslotDatas;
    public string nickname;
    public int specialAttack;
    public int specialDefence;
    public SpeciesData speciesData;
    public SpeciesKey speciesKey;
    public int speed;

    public EntityData(string nickname, int level, SpeciesKey speciesKey, SpeciesData speciesData, List<MoveslotData> moveslotDatas)
    {
        this.nickname = nickname;
        this.level = level;
        this.speciesKey = speciesKey;
        this.speciesData = speciesData;
        this.moveslotDatas = moveslotDatas;
    }
}