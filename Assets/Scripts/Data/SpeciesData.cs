using System.Collections.Generic;

public class SpeciesData
{
    public string name;
    public List<string> attributeKeys;

    public List<KeyValuePair<string, int>> speciesMoveLearnData;

    #region Base Stats
    public int baseHealth;
    public int baseAttack;
    public int baseDefence;
    public int baseSpecialAttack;
    public int baseSpecialDefence;
    public int baseSpeed;
    #endregion Base Stats
}
