using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySentIntoBattle : ICommand
{
    public Entity entity;
    public Entity other;

    public EntitySentIntoBattle(Entity entity, Entity otherEntity)
    {
        this.entity = entity;
        this.other = otherEntity;
    }

    public void Execute()
    {
        HelperFunctions.Log($"{entity.Name} was sent out!");
    }
}