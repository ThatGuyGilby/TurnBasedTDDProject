using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnData
{
    public EntityData attackerEntityData;
    public EntityData defenderEntityData;
    public MoveKey moveKey;

    public TurnData(EntityData attackerEntityData, EntityData defenderEntityData, MoveKey moveKey)
    {
        this.attackerEntityData = attackerEntityData;
        this.defenderEntityData = defenderEntityData;
        this.moveKey = moveKey;
    }
}
