using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager
{
    public bool IsInitialized { get; private set; }

    public BattleManager()
    {
        IsInitialized = false;
    }

    public void InitializeBattle()
    {
        Debug.Log("Initializing battle");

        EntityData playerEntity = GetDummyEntityData();
        EntityData enemyEntity = GetDummyEntityData();

        Debug.Log(playerEntity.nickname + " vs. " + enemyEntity.nickname);

        IsInitialized = true;
    }

    private EntityData GetDummyEntityData(string nickname = "")
    {
        EntityData entityData = MasterFactory.EntityDataFromSpeciesKey(SpeciesKey.CHARMANDER);

        if (nickname != "")
        {
            entityData.nickname = nickname;
        }

        return entityData;
    }
}
