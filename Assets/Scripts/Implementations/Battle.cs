using System.Collections.Generic;

public class Battle : IInvoker
{
    #region Private Fields

    private BattleData battleData;

    #endregion Private Fields

    #region Properties

    public Entity ActiveEnemyEntity => battleData.activeEnemyEntity;

    #endregion Properties

    #region Public Constructors

    public Battle(BattleData battleData)
    {
        this.battleData = battleData;
    }

    #endregion Public Constructors

    #region Public Properties

    public bool IsInitialized { get; private set; }

    #endregion Public Properties

    #region Public Methods

    public void ExecuteQueuedCommands()
    {
        foreach (var item in battleData.queuedCommands)
        {
            item.Execute();
            battleData.executedCommands.Add(item);
        }

        battleData.queuedCommands = new List<ICommand>();
    }

    public void Initialize()
    {
        HelperFunctions.Log($"{battleData.weatherData.weatherMessage}");

        if (battleData.enemyEntities.Count == 0 || battleData.enemyEntities.Count > Constants.MAX_PARTY_SIZE)
        {
            HelperFunctions.ThrowException($"Invalid enemy party size: {battleData.enemyEntities.Count}");
        }

        if (battleData.playerEntities.Count == 0 || battleData.playerEntities.Count > Constants.MAX_PARTY_SIZE)
        {
            HelperFunctions.ThrowException($"Invalid player party size: {battleData.playerEntities.Count}");
        }

        SetActiveEntities();

        if (battleData.activePlayerEntity == null || battleData.activeEnemyEntity == null)
        {
            return;
        }

        IsInitialized = true;
    }

    public void QueueCommand(ICommand command)
    {
        battleData.queuedCommands.Add(command);
    }

    #endregion Public Methods

    #region Private Methods

    private void SendEntityIntoBattle(Entity entity, Entity other, ref Entity activeEntity)
    {
        EntitySentIntoBattle entitySentIntoBattle = new EntitySentIntoBattle(entity, other);
        QueueCommand(entitySentIntoBattle);

        activeEntity = entity;
    }

    private void SetActiveEntities()
    {
        SendEntityIntoBattle(battleData.playerEntities[0], battleData.activeEnemyEntity, ref battleData.activePlayerEntity);
        SendEntityIntoBattle(battleData.enemyEntities[0], battleData.activePlayerEntity, ref battleData.activeEnemyEntity);

        ExecuteQueuedCommands();
    }

    #endregion Private Methods
}