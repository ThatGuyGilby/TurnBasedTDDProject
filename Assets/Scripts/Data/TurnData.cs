using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnData
{
    public Entity attackerEntity;
    public Entity defenderEntity;
    public MoveKey moveKey;

    public TurnData(Entity attackerEntity, Entity defenderEntity, MoveKey moveKey)
    {
        this.attackerEntity = attackerEntity;
        this.defenderEntity = defenderEntity;
        this.moveKey = moveKey;
    }
}
