using System.Collections.Generic;

public class AttributeData : DataSource
{
    public List<string> immunities;
    public List<string> resistances;
    public List<string> weaknesses;

    public AttributeData(string name, List<string> resistances, List<string> weaknesses, List<string> immunities)
    {
        this.name = name;
        this.resistances = resistances;
        this.weaknesses = weaknesses;
        this.immunities = immunities;
    }
}