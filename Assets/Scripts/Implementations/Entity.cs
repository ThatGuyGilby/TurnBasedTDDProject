using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private EntityData entityData;

    public Entity(EntityData entityData)
    {
        this.entityData = entityData;
        Initialize();
    }

    public int Attack => entityData.attack;
    public int CurrentHealth => entityData.currentHealth;
    public int Defence => entityData.defence;
    public int Health => entityData.health;
    public int Level => entityData.level;
    public List<MoveslotData> MoveslotDatas => entityData.moveslotDatas;
    public string Name => entityData.nickname;
    public int SpecialAttack => entityData.specialAttack;
    public int SpecialDefence => entityData.specialDefence;
    public int Speed => entityData.speed;

    public void Die()
    {
        entityData.alive = false;
        entityData.currentHealth = 0;
    }

    public List<string> GetAttributeKeys()
    {
        List<string> attributeKeys = new List<string>();

        if (entityData.speciesData.primaryAttributeKey != "")
        {
            attributeKeys.Add(entityData.speciesData.primaryAttributeKey);
        }

        if (entityData.speciesData.secondaryAttributeKey != "")
        {
            attributeKeys.Add(entityData.speciesData.secondaryAttributeKey);
        }

        return attributeKeys;
    }

    public float GetIncomingMultiplier(string attributeString)
    {
        float multiplier = 1f;

        AttributeData incomingAttribute = RepositoryManager.attributeDataRepository.DataFromString(attributeString);

        List<AttributeData> attributeDatas = new List<AttributeData>();

        foreach (var item in GetAttributeKeys())
        {
            attributeDatas.Add(RepositoryManager.attributeDataRepository.DataFromString(item));
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

        AttributeData moveAttribute = RepositoryManager.attributeDataRepository.DataFromString(attributeString);

        List<AttributeData> attributeDatas = new List<AttributeData>();

        foreach (var item in GetAttributeKeys())
        {
            attributeDatas.Add(RepositoryManager.attributeDataRepository.DataFromString(item));
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

    public void Initialize()
    {
        CalculateStats();

        entityData.currentHealth = entityData.health;
        entityData.alive = true;
    }

    public bool IsAlive()
    {
        return entityData.alive;
    }

    public void SetLevel(int level)
    {
        entityData.level = level;
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

    public void Update()
    {
        CalculateStats();
    }

    private int CalculateStat(int _base, int _iv, int _ev, int _minimumValue, float _natureMultiplier, int _additionalBonus = 0)
    {
        return (int)((Mathf.FloorToInt(0.01f * (2f * _base + _iv + (0.25f * _ev)) * entityData.level) + _additionalBonus + _minimumValue) * _natureMultiplier);
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

    private int TempCalculateStat(int _base, int _minimumValue, int _additionalBonus = 0)
    {
        return CalculateStat(_base, Constants.DUMMY_IV, Constants.DUMMY_EV, _minimumValue, Constants.DUMMY_NATURE, _additionalBonus);
    }
}