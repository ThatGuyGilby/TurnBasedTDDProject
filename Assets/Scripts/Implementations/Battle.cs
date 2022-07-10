using System.Collections.Generic;

public class Battle : IInvoker
{
    private BattleData battleData;

    public Battle(BattleData battleData)
    {
        this.battleData = battleData;
    }

    public Entity ActiveEnemyEntity => battleData.activeEnemyEntity;
    public bool IsInitialized { get; private set; }

    public void ExecuteQueuedCommands()
    {
        foreach (var item in battleData.queuedCommands)
        {
            item.Execute();
            battleData.executedCommands.Add(item);
        }

        battleData.queuedCommands = new List<ICommand>();
    }

    public float GetWeatherMultiplier(string attributeString)
    {
        float multiplier = 1.0f;

        AttributeData moveAttribute = RepositoryManager.attributeDataRepository.DataFromString(attributeString);

        List<AttributeData> powerBoostedTypes = new List<AttributeData>();

        HelperFunctions.Log($"{battleData.weatherData.name}");

        foreach (string powerBoostedType in battleData.weatherData.powerBoostKeys)
        {
            if (powerBoostedType != "")
                powerBoostedTypes.Add(RepositoryManager.attributeDataRepository.DataFromString(powerBoostedType));
        }

        foreach (AttributeData powerBoostedType in powerBoostedTypes)
        {
            if (powerBoostedType.name == moveAttribute.name)
            {
                multiplier = 1.5f;
            }
        }

        List<AttributeData> powerReducedTypes = new List<AttributeData>();

        foreach (string powerReducedType in battleData.weatherData.powerReductionKeys)
        {
            if (powerReducedType != "")
                powerReducedTypes.Add(RepositoryManager.attributeDataRepository.DataFromString(powerReducedType));
        }

        foreach (AttributeData powerReducedType in powerReducedTypes)
        {
            if (powerReducedType.name == moveAttribute.name)
            {
                multiplier = 0.5f;
            }
        }

        return multiplier;
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
}