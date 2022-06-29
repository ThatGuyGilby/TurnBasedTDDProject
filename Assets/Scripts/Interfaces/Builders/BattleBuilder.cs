using System.Collections.Generic;

public class BattleBuilder : IBuilder<Battle>
{
    #region Private Fields

    private List<Entity> enemyEntities;
    private List<Entity> playerEntities;

    #endregion Private Fields

    #region Public Constructors

    public BattleBuilder()
    {
        this.playerEntities = new List<Entity>();
        this.enemyEntities = new List<Entity>();
    }

    #endregion Public Constructors

    #region Public Methods

    public Battle Build()
    {
        BattleData battleData = new BattleDataBuilder().WithPlayerEntities(playerEntities).WithEnemyEntities(enemyEntities).Build();

        return new Battle(battleData);
    }

    public BattleBuilder WithEnemyEntities(List<Entity> entities)
    {
        enemyEntities.AddRange(entities);
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

    public BattleBuilder WithPlayerEntity(Entity entity)
    {
        playerEntities.Add(entity);
        return this;
    }

    #endregion Public Methods
}