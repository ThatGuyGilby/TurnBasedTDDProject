using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleData
{
    public List<Entity> playerEntities;
    public List<Entity> enemyEntities;

    public Entity activePlayerEntity;
    public Entity activeEnemyEntity;

    public BattleData(List<Entity> playerEntities, List<Entity> enemyEntities)
    {
        this.playerEntities = playerEntities;
        this.enemyEntities = enemyEntities;
    }
}
