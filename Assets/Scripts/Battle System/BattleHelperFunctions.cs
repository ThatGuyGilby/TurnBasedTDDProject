using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHelperFunctions
{
    public static void ProcessAttack(TurnData turnData, BattleData battleData)
    {
        Entity attacker = turnData.attackerEntity;
        Entity defender = turnData.defenderEntity;
        MoveData move = HelperFunctions.MoveDataFromMoveKey(turnData.moveKey);

        var k = defender.GetIncomingMultiplier(move.attributeKey);
        Debug.Log(k);

        int power = move.power;

        int damage = power;

        if (attacker.IsAlive())
        {
            Debug.Log(damage);
            defender.TakeDamage(damage);
        }
    }
}
