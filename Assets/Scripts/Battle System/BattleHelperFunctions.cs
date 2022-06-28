using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHelperFunctions
{
    public static void ProcessAttack(TurnData turnData, BattleData battleData)
    {
        int _damage = MasterFactory.MoveDataFromMoveKey(turnData.moveKey).power;

        if (turnData.attackerEntityData.alive)
        {
            Debug.Log($"{turnData.attackerEntityData.nickname} attacked {turnData.defenderEntityData.nickname}");
            turnData.defenderEntityData.TakeDamage(_damage);
        }
    }
}
