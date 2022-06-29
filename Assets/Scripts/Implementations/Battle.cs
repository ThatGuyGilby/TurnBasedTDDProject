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

    public void QueueCommand(ICommand command)
    {
        battleData.queuedCommands.Add(command);
    }

    public void ExecuteQueuedCommands()
    {
        foreach (var item in battleData.queuedCommands)
        {
            item.Execute();
            battleData.executedCommands.Add(item);
        }

        battleData.queuedCommands = new List<ICommand>();
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
