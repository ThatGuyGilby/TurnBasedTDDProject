using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager
{
    public BattleData battleData;
    public EntityData playerEntity;
    public EntityData enemyEntity;

    public bool IsInitialized { get; private set; }

    public BattleManager()
    {
        IsInitialized = false;
    }

    public void InitializeBattle()
    {
        battleData = new BattleData();

        playerEntity = GetDummyEntityData();
        enemyEntity = GetDummyEntityData(SpeciesKey.BULBASAUR);

        IsInitialized = true;
    }

    public void ProcessTurnData(List<TurnData> turnDatas)
    {
        List<TurnData> sortedList = turnDatas.OrderByDescending(o => o.attackerEntityData.Speed).ToList();

        // TODO: Speed ties

        foreach(TurnData turnData in sortedList)
        {
            BattleHelperFunctions.ProcessAttack(turnData, battleData);
        }
    }

    private EntityData GetDummyEntityData(SpeciesKey speciesKey = SpeciesKey.CHARMANDER,  string nickname = "")
    {
        EntityData entityData = MasterFactory.EntityDataFromSpeciesKey(speciesKey);

        if (nickname != "")
        {
            entityData.nickname = nickname;
        }

        return entityData;
    }
}
