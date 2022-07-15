using System.Collections.Generic;

public class PlayerData
{
    public string name;
    public List<Entity> party;

    public PlayerData(string name, List<Entity> party)
    {
        this.name = name;
        this.party = party;
    }
}