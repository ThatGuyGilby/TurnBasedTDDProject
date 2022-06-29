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
        if (battleData.enemyEntities.Count == 0 || battleData.playerEntities.Count == 0)
        {
            return;
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

    private void SetActiveEntities()
    {
        battleData.activePlayerEntity = battleData.playerEntities[0];
        battleData.activeEnemyEntity = battleData.enemyEntities[0];
    }

    #endregion Private Methods
}