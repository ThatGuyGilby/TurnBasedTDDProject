using System.Collections.Generic;

public class BattleData
{
    public List<Entity> playerEntities;
    public List<Entity> enemyEntities;

    public Entity activePlayerEntity;
    public Entity activeEnemyEntity;

    public List<ICommand> queuedCommands;
    public List<ICommand> executedCommands;

    public BattleData(List<Entity> playerEntities, List<Entity> enemyEntities)
    {
        this.playerEntities = playerEntities;
        this.enemyEntities = enemyEntities;

        queuedCommands = new List<ICommand>();
        executedCommands = new List<ICommand>();
    }
}
