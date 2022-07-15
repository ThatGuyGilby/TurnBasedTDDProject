using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataBuilder : IBuilder<PlayerData>
{
    private string name;
    private List<Entity> party;

    public PlayerDataBuilder()
    {
        HelperFunctions.Log($"PlayerData initializing...");
        name = "New Trainer";
        party = new List<Entity>();
        HelperFunctions.Log($"PlayerData initialized...");
        HelperFunctions.Log($"PlayerData party.Count: {party.Count}");
    }

    public PlayerData Build()
    {
        HelperFunctions.Log($"PlayerData party.Count: {party.Count}");

        if (party.Count == 0)
        {
            HelperFunctions.ThrowException("Player can not be created with a party size of 0");
        }

        return new PlayerData(name, party);
    }

    public PlayerDataBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }

    public PlayerDataBuilder WithParty(List<Entity> party)
    {
        HelperFunctions.Log($"PlayerData party.Count before: {party.Count}");
        this.party.AddRange(party);
        HelperFunctions.Log($"PlayerData party.Count after: {party.Count}");
        return this;
    }
}