using System.Collections.Generic;

public class SpeciesData
{
    #region Public Fields

    public List<string> attributeKeys;
    public string name;
    public List<KeyValuePair<string, int>> speciesMoveLearnData;

    #endregion Public Fields

    #region Base Stats

    public int baseAttack;
    public int baseDefence;
    public int baseHealth;
    public int baseSpecialAttack;
    public int baseSpecialDefence;
    public int baseSpeed;

    #endregion Base Stats
}