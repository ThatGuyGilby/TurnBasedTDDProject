using System.Collections.Generic;

public class BattleData
{
    public Entity activeEnemyEntity;
    public Entity activePlayerEntity;
    public List<Entity> enemyEntities;
    public List<ICommand> executedCommands;
    public List<Entity> playerEntities;
    public List<ICommand> queuedCommands;
    public WeatherData weatherData;

    public BattleData(List<Entity> playerEntities, List<Entity> enemyEntities, WeatherData weatherData)
    {
        this.playerEntities = playerEntities;
        this.enemyEntities = enemyEntities;

        queuedCommands = new List<ICommand>();
        executedCommands = new List<ICommand>();

        this.weatherData = weatherData;
    }
}