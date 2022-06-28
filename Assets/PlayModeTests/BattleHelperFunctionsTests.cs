using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BattleHelperFunctionsTests
{
    [Test]
    public void ProcessAttackDealsDamageCorrectly()
    {
        BattleManager battleManager = new BattleManager();

        battleManager.InitializeBattle();

        TurnData turnDataPlayer = new TurnData(battleManager.playerEntity, battleManager.enemyEntity, MoveKey.TACKLE);
        TurnData turnDataEnemy = new TurnData(battleManager.enemyEntity, battleManager.playerEntity, MoveKey.TACKLE);

        List<TurnData> turnDatas = new List<TurnData>();
        turnDatas.Add(turnDataPlayer);
        turnDatas.Add(turnDataEnemy);

        battleManager.ProcessTurnData(turnDatas);
    }
}
