using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesData
{
    public string name;
    public List<string> attributeKeys;

    #region Base Stats
    public int baseHealth;
    public int baseAttack;
    public int baseDefence;
    public int baseSpecialAttack;
    public int baseSpecialDefence;
    public int baseSpeed;
    #endregion Base Stats

    public SpeciesData(string name, int baseHealth, int baseAttack, int baseDefence, int baseSpecialAttack, int baseSpecialDefence, int baseSpeed, List<string> attributeKeys)
    {
        this.name = name;
        this.baseHealth = baseHealth;
        this.baseAttack = baseAttack;
        this.baseDefence = baseDefence;
        this.baseSpecialAttack = baseSpecialAttack;
        this.baseSpecialDefence = baseSpecialDefence;
        this.baseSpeed = baseSpeed;
        this.attributeKeys = attributeKeys;
    }

    public float GetIncomingMultiplier(string attributeString)
    {
        float multiplier = 1f;

        AttributeData incomingAttribute = MasterFactory.AttributeDataFromString(attributeString);

        List<AttributeData> attributeDatas = new List<AttributeData>();

        foreach (var item in attributeKeys)
        {
            attributeDatas.Add(MasterFactory.AttributeDataFromString(item));
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
}
