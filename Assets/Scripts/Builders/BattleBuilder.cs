using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBuilder : IBuilder<Battle>
{
    private List<Entity> playerEntities;
    private List<Entity> enemyEntities;

    public Battle Build()
    {
        BattleData battleData = new BattleDataBuilder().WithPlayerEntities(playerEntities).WithEnemyEntities(enemyEntities).Build();

        return new Battle(battleData);
    }

    public BattleBuilder()
    {
        this.playerEntities = new List<Entity>();
        this.enemyEntities = new List<Entity>();
    }

    public BattleBuilder WithPlayerEntity(Entity entity)
    {
        playerEntities.Add(entity);
        return this;
    }

    public BattleBuilder WithEnemyEntity(Entity entity)
    {
        enemyEntities.Add(entity);
        return this;
    }

    public BattleBuilder WithPlayerEntities(List<Entity> entities)
    {
        playerEntities.AddRange(entities);
        return this;
    }

    public BattleBuilder WithEnemyEntities(List<Entity> entities)
    {
        enemyEntities.AddRange(entities);
        return this;
    }
}
