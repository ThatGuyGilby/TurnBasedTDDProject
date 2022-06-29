using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private EntityData entityData;

    #region Properties
    public string Name => entityData.nickname;
    public int Health => entityData.health;
    public int CurrentHealth => entityData.currentHealth;
    public int Level => entityData.level;
    public int Attack => entityData.attack;
    public int Defence => entityData.defence;
    public int SpecialAttack => entityData.specialAttack;
    public int SpecialDefence => entityData.specialDefence;
    public int Speed => entityData.speed;
    #endregion Properties

    public Entity(EntityData entityData)
    {
        this.entityData = entityData;
        Initialize();
    }

    public void Initialize()
    {
        CalculateStats();

        entityData.currentHealth = entityData.health;
        entityData.alive = true;
    }

    private void CalculateStats()
    {
        entityData.health = TempCalculateStat(entityData.speciesData.baseHealth, Constants.HP_MINIMUM_VALUE, entityData.level);
        entityData.attack = TempCalculateStat(entityData.speciesData.baseAttack, Constants.OTHER_STAT_MINIMUM_VALUE);
        entityData.defence = TempCalculateStat(entityData.speciesData.baseDefence, Constants.OTHER_STAT_MINIMUM_VALUE);
        entityData.specialAttack = TempCalculateStat(entityData.speciesData.baseSpecialAttack, Constants.OTHER_STAT_MINIMUM_VALUE);
        entityData.specialDefence = TempCalculateStat(entityData.speciesData.baseSpecialDefence, Constants.OTHER_STAT_MINIMUM_VALUE);
        entityData.speed = TempCalculateStat(entityData.speciesData.baseSpeed, Constants.OTHER_STAT_MINIMUM_VALUE);
    }

    public void SetLevel(int level)
    {
        entityData.level = level;
        CalculateStats();
    }

    public bool IsAlive()
    {
        return entityData.alive;
    }

    public float GetIncomingMultiplier(string attributeString)
    {
        float multiplier = 1f;

        AttributeData incomingAttribute = HelperFunctions.AttributeDataFromString(attributeString);

        List<AttributeData> attributeDatas = new List<AttributeData>();

        foreach (var item in entityData.speciesData.attributeKeys)
        {
            attributeDatas.Add(HelperFunctions.AttributeDataFromString(item));
        }

        foreach (var item in attributeDatas)
        {
            if (item.resistances.Contains(incomingAttribute.name))
            {
                multiplier *= 0.5f;
            }

            if (item.weaknesses.Contains(incomingAttribute.name))
            {
                multiplier *= 2f;
            }

            if (item.immunities.Contains(incomingAttribute.name))
            {
                multiplier = 0;
            }
        }

        return multiplier;
    }


    public float GetSTABMultiplier(string attributeString)
    {
        float multiplier = 1f;

        AttributeData moveAttribute = HelperFunctions.AttributeDataFromString(attributeString);

        List<AttributeData> attributeDatas = new List<AttributeData>();

        foreach (var item in entityData.speciesData.attributeKeys)
        {
            attributeDatas.Add(HelperFunctions.AttributeDataFromString(item));
        }

        foreach (var item in attributeDatas)
        {
            if (item.name == moveAttribute.name)
            {
                multiplier = 1.5f;
            }
        }

        return multiplier;
    }


    private int TempCalculateStat(int _base, int _minimumValue, int _additionalBonus = 0)
    {
        return CalculateStat(_base, Constants.DUMMY_IV, Constants.DUMMY_EV, _minimumValue, Constants.DUMMY_NATURE, _additionalBonus);
    }

    private int CalculateStat(int _base, int _iv, int _ev, int _minimumValue, float _natureMultiplier, int _additionalBonus = 0)
    {
        return (int)((Mathf.FloorToInt(0.01f * (2f * _base + _iv + (0.25f * _ev)) * entityData.level) + _additionalBonus + _minimumValue) * _natureMultiplier);
    }

    public void Update()
    {
        CalculateStats();
    }

    public void TakeDamage(int _damage)
    {
        _damage = Mathf.Max(_damage, 0);

        entityData.currentHealth -= _damage;

        if (entityData.currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        entityData.alive = false;
        entityData.currentHealth = 0;
    }
}
