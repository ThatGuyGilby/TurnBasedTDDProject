using System.Collections.Generic;

public class BattleData
{
    #region Public Fields

    public Entity activeEnemyEntity;
    public Entity activePlayerEntity;
    public List<Entity> enemyEntities;
    public List<ICommand> executedCommands;
    public List<Entity> playerEntities;
    public List<ICommand> queuedCommands;

    public WeatherData weatherData;

    #endregion Public Fields

    #region Public Constructors

    public BattleData(List<Entity> playerEntities, List<Entity> enemyEntities, WeatherData weatherData)
    {
        this.playerEntities = playerEntities;
        this.enemyEntities = enemyEntities;

        queuedCommands = new List<ICommand>();
        executedCommands = new List<ICommand>();

        this.weatherData = weatherData;
    }

    #endregion Public Constructors
}