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
    public int Health;
    public int Attack;
    public int Defence;
    public int SpecialAttack;
    public int SpecialDefence;
    public int Speed;
    #endregion Stats

    public EntityData(string nickname, int level, SpeciesKey speciesKey, SpeciesData speciesData)
    {
        this.nickname = nickname;
        this.level = level;
        this.speciesKey = speciesKey;
        this.speciesData = speciesData;

        CalculateStats();

        currentHealth = Health;
        alive = true;
    }

    private void CalculateStats()
    {
        Health = TempCalculateStat(speciesData.baseHealth, Constants.HP_MINIMUM_VALUE, level);
        Attack = TempCalculateStat(speciesData.baseAttack, Constants.OTHER_STAT_MINIMUM_VALUE);
        Defence = TempCalculateStat(speciesData.baseDefence, Constants.OTHER_STAT_MINIMUM_VALUE);
        SpecialAttack = TempCalculateStat(speciesData.baseSpecialAttack, Constants.OTHER_STAT_MINIMUM_VALUE);
        SpecialDefence = TempCalculateStat(speciesData.baseSpecialDefence, Constants.OTHER_STAT_MINIMUM_VALUE);
        Speed = TempCalculateStat(speciesData.baseSpeed, Constants.OTHER_STAT_MINIMUM_VALUE);
    }

    private int TempCalculateStat(int _base, int _minimumValue, int _additionalBonus = 0)
    {
        return CalculateStat(_base, Constants.DUMMY_IV, Constants.DUMMY_EV, _minimumValue, Constants.DUMMY_NATURE, _additionalBonus);
    }

    private int CalculateStat(int _base, int _iv, int _ev, int _minimumValue, float _natureMultiplier, int _additionalBonus = 0)
    {
        return (int)((Mathf.FloorToInt(0.01f * (2f * _base + _iv + (0.25f * _ev)) * level) + _additionalBonus + _minimumValue) * _natureMultiplier);
    }

    public void Update()
    {
        CalculateStats();
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth <= 0)
        {
            alive = false;
            currentHealth = 0;
        }
    }
}
