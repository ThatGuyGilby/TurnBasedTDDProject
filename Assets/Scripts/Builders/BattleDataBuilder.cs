using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDataBuilder : IBuilder<BattleData>
{
    private List<Entity> playerEntities;
    private List<Entity> enemyEntities;

    public BattleDataBuilder()
    {
        this.playerEntities = new List<Entity>();
        this.enemyEntities = new List<Entity>();
    }

    public BattleDataBuilder WithPlayerEntity(Entity entity)
    {
        playerEntities.Add(entity);
        return this;
    }

    public BattleDataBuilder WithEnemyEntity(Entity entity)
    {
        enemyEntities.Add(entity);
        return this;
    }

    public BattleDataBuilder WithPlayerEntities(List<Entity> entities)
    {
        playerEntities.AddRange(entities);
        return this;
    }

    public BattleDataBuilder WithEnemyEntities(List<Entity> entities)
    {
        enemyEntities.AddRange(entities);
        return this;
    }

    public BattleData Build()
    {
        return new BattleData(playerEntities, enemyEntities);
    }
}
