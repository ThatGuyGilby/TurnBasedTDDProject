using System.Collections.Generic;

public class SpeciesData : DataSource
{
    public int baseAttack;
    public int baseDefence;
    public int baseHealth;
    public int baseSpecialAttack;
    public int baseSpecialDefence;
    public int baseSpeed;
    public string primaryAttributeKey;
    public string secondaryAttributeKey;
    public List<KeyValuePair<string, int>> speciesMoveLearnData;
}