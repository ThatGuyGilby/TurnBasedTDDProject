using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHelperFunctions
{
    public static void ProcessAttack(TurnData turnData, BattleData battleData)
    {
        EntityData attacker = turnData.attackerEntityData;
        EntityData defender = turnData.defenderEntityData;
        MoveData move = MasterFactory.MoveDataFromMoveKey(turnData.moveKey);

        var k = defender.speciesData.GetIncomingMultiplier(move.attributeKey);
        Debug.Log(k);

        int power = move.power;

        int damage = power;

        if (turnData.attackerEntityData.alive)
        {
            Debug.Log(damage);
            turnData.defenderEntityData.TakeDamage(damage);
        }
    }
}
