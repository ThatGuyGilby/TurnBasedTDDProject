using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class BattleManager
{
    public BattleData battleData;
    public Entity playerEntity;
    public Entity enemyEntity;

    public bool IsInitialized { get; private set; }

    public BattleManager()
    {
        IsInitialized = false;
    }

    public void InitializeBattle()
    {
        battleData = new BattleData();

        playerEntity = GetDummyEntity();
        enemyEntity = GetDummyEntity(SpeciesKey.BULBASAUR);

        IsInitialized = true;
    }

    public void ProcessTurnData(List<TurnData> turnDatas)
    {
        List<TurnData> sortedList = turnDatas.OrderByDescending(o => o.attackerEntity.Speed).ToList();

        // TODO: Speed ties

        foreach(TurnData turnData in sortedList)
        {
            BattleHelperFunctions.ProcessAttack(turnData, battleData);
        }
    }

    public Entity GetDummyEntity(SpeciesKey speciesKey = SpeciesKey.CHARMANDER)
    {
        return EntityBuilder.Build(speciesKey);
    }
}
