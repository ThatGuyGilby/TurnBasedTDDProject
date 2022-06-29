using System.Collections.Generic;

public class AttributeData
{
    public string name;
    public List<string> resistances;
    public List<string> weaknesses;
    public List<string> immunities;

    public AttributeData(string name, List<string> resistances, List<string> weaknesses, List<string> immunities)
    {
        this.name = name;
        this.resistances = resistances;
        this.weaknesses = weaknesses;
        this.immunities = immunities;
    }
}
