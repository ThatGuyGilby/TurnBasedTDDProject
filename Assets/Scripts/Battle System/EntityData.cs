using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData
{
    public string nickname;
    public int level;
    public SpeciesKey speciesKey;
    public SpeciesData speciesData;

    public int Health;
    public int Attack;

    public EntityData(string nickname, int level, SpeciesKey speciesKey, SpeciesData speciesData)
    {
        this.nickname = nickname;
        this.level = level;
        this.speciesKey = speciesKey;
        this.speciesData = speciesData;

        CalculateStats();
    }

    private void CalculateStats()
    {
        Health = CalculateStat(speciesData.baseHealth, Constants.DUMMY_IV, Constants.DUMMY_EV, Constants.HP_MINIMUM_VALUE, Constants.DUMMY_NATURE, level);
        Attack = CalculateStat(speciesData.baseAttack, Constants.DUMMY_IV, Constants.DUMMY_EV, Constants.OTHER_STAT_MINIMUM_VALUE, Constants.DUMMY_NATURE);
    }

    private int CalculateStat(int _base, int _iv, int _ev, int _minimum, float _nature, int _additionalBonus = 0)
    {
        return (int)((Mathf.FloorToInt(0.01f * (2f * _base + _iv + (0.25f * _ev)) * level) + _additionalBonus + _minimum) * _nature);
    }

    public void Update()
    {
        CalculateStats();
    }
}
