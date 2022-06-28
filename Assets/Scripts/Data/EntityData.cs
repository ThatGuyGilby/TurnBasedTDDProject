using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData
{
    public string nickname;
    public int level;
    public SpeciesKey speciesKey;
    public SpeciesData speciesData;

    #region Persistant Data
    public int currentHealth;
    public bool alive;
    #endregion Persistant Data

    #region Stats
    public int health;
    public int attack;
    public int defence;
    public int specialAttack;
    public int specialDefence;
    public int speed;
    #endregion Stats

    public EntityData(string nickname, int level, SpeciesKey speciesKey, SpeciesData speciesData)
    {
        this.nickname = nickname;
        this.level = level;
        this.speciesKey = speciesKey;
        this.speciesData = speciesData;
    }
}
