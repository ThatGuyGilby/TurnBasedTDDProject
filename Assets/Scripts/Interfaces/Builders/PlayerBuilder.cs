using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilder : IBuilder<Player>
{
    private string name;
    private List<Entity> party;

    public PlayerBuilder()
    {
        name = "New Trainer";
        party = new List<Entity>();
    }

    public Player Build()
    {
        if (party.Count == 0)
        {
            HelperFunctions.ThrowException("Player can not be created with a party size of 0");
        }

        PlayerData playerData = new PlayerDataBuilder().WithParty(party).WithName(name).Build();

        return new Player(playerData);
    }

    public PlayerBuilder WithEntity(Entity entity)
    {
        party.Add(entity);
        return this;
    }

    public PlayerBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }
}