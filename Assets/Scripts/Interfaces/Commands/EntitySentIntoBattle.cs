using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySentIntoBattle : ICommand
{
    #region Public Fields

    public Entity entity;
    public Entity other;

    #endregion Public Fields

    #region Public Constructors

    public EntitySentIntoBattle(Entity entity, Entity otherEntity)
    {
        this.entity = entity;
        this.other = otherEntity;
    }

    #endregion Public Constructors

    #region Public Methods

    public void Execute()
    {
        HelperFunctions.Log($"{entity.Name} was sent out!");
    }

    #endregion Public Methods
}