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

        IsInitialized = true;
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
