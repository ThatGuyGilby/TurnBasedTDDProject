using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class Battle
{
    private BattleData battleData;

    public Battle(BattleData battleData)
    {
        this.battleData = battleData;
    }

    public bool IsInitialized { get; private set; }

    public void Initialize()
    {
        if (battleData.enemyEntities.Count == 0 || battleData.playerEntities.Count == 0)
        {
            return;
        }

        SetActiveEntities();

        if (battleData.activePlayerEntity == null || battleData.activeEnemyEntity == null)
        {
            return;
        }

        IsInitialized = true;
    }

    private void SetActiveEntities()
    {
        battleData.activePlayerEntity = battleData.playerEntities[0];
        battleData.activeEnemyEntity = battleData.enemyEntities[0];
    }

    public int EntityAttackEntity(Entity attacker, Entity defender, MoveKey moveKey)
    {
        MoveData moveData = HelperFunctions.MoveDataFromMoveKey(moveKey);

        float moveAttributeDamageMultiplier = defender.GetIncomingMultiplier(moveData.attributeKey);
        int power = moveData.power;
        int atk = attacker.Attack;
        int def = defender.Defence;

        float baseDamage = (((((2f * (float)attacker.Level) / 5f) + 2f)*power*atk/def)/50f)+2f;

        baseDamage *= moveAttributeDamageMultiplier;

        int damage = Mathf.CeilToInt(baseDamage);

        if (attacker.IsAlive())
        {
            Debug.Log($"{defender.Name} took {damage} damage from {attacker.Name}'s {moveData.name}");
            defender.TakeDamage(damage);
            return damage;
        }

        return 0;
    }

    public void ProcessTurnData(List<TurnData> turnDatas)
    {
        List<TurnData> sortedList = turnDatas.OrderByDescending(o => o.attackerEntity.Speed).ToList();

        // TODO: Speed ties

        foreach(TurnData turnData in sortedList)
        {
            HelperFunctions.ProcessAttack(turnData, battleData);
        }
    }
}
