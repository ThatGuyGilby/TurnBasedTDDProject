using System;
using System.Collections.Generic;

public class BattleBuilder : IBuilder<Battle>
{
    private List<Entity> enemyEntities;
    private List<Entity> playerEntities;
    private WeatherKey weatherKey;

    public BattleBuilder()
    {
        this.playerEntities = new List<Entity>();
        this.enemyEntities = new List<Entity>();
    }

    public Battle Build()
    {
        BattleData battleData = new BattleDataBuilder().WithPlayerEntities(playerEntities).WithEnemyEntities(enemyEntities).WithWeatherKey(weatherKey).Build();

        return new Battle(battleData);
    }

    public BattleBuilder WithEnemyEntities(List<Entity> entities)
    {
        enemyEntities.AddRange(entities);
        return this;
    }

    public BattleBuilder WithEnemyEntity(Entity entity, int amountOfTimesToAdd = 1)
    {
        for (int i = 0; i < amountOfTimesToAdd; i++)
        {
            enemyEntities.Add(entity);
        }

        return this;
    }

    public BattleBuilder WithPlayer(Player player)
    {
        playerEntities.AddRange(player.Party);
        return this;
    }

    public BattleBuilder WithPlayerEntities(List<Entity> entities)
    {
        playerEntities.AddRange(entities);
        return this;
    }

    public BattleBuilder WithPlayerEntity(Entity entity, int amountOfTimesToAdd = 1)
    {
        for (int i = 0; i < amountOfTimesToAdd; i++)
        {
            playerEntities.Add(entity);
        }

        return this;
    }

    public BattleBuilder WithWeatherKey(WeatherKey weatherKey)
    {
        this.weatherKey = weatherKey;
        return this;
    }
}