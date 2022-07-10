using System.Collections.Generic;

public class BattleDataBuilder : IBuilder<BattleData>
{
    private List<Entity> enemyEntities;
    private List<Entity> playerEntities;
    private WeatherData weatherData;

    public BattleDataBuilder()
    {
        this.playerEntities = new List<Entity>();
        this.enemyEntities = new List<Entity>();
        weatherData = new WeatherDataBuilder().Build();
    }

    public BattleData Build()
    {
        return new BattleData(playerEntities, enemyEntities, weatherData);
    }

    public BattleDataBuilder WithEnemyEntities(List<Entity> entities)
    {
        enemyEntities.AddRange(entities);
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

    public BattleDataBuilder WithPlayerEntity(Entity entity)
    {
        playerEntities.Add(entity);
        return this;
    }

    public BattleDataBuilder WithWeatherKey(WeatherKey weatherKey)
    {
        weatherData = new WeatherDataBuilder().WithWeatherKey(weatherKey).Build();
        return this;
    }
}