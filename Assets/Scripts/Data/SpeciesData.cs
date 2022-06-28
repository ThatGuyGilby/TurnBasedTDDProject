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
}
