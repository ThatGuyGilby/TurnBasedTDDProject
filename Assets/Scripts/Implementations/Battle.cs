using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Battle : IInvoker
{
    [SerializeField] private BattleData battleData;

    public Battle(BattleData battleData)
    {
        this.battleData = battleData;
        Initialize();
    }

    public Entity ActiveEnemyEntity => battleData.activeEnemyEntity;
    public Entity ActivePlayerEntity => battleData.activePlayerEntity;
    public bool IsFinished { get; private set; }
    public bool IsInitialized { get; private set; }

    public void ApplyEndOfTurnEffects()
    {
        if (!ActiveEnemyEntity.IsAlive())
        {
            HelperFunctions.Log("You won!");
            IsFinished = true;
        }

        if (!ActivePlayerEntity.IsAlive())
        {
            HelperFunctions.Log("You lost!");
            IsFinished = true;
        }
    }

    public float GetWeatherMultiplier(string attributeString)
    {
        float multiplier = 1.0f;

        AttributeData moveAttribute = RepositoryManager.attributeDataRepository.DataFromString(attributeString);

        List<AttributeData> powerBoostedTypes = new List<AttributeData>();

        //HelperFunctions.Log($"{battleData.weatherData.name}");

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
        IsFinished = false;
    }

    public void ProcessTurn()
    {
        foreach (ICommand command in battleData.queuedCommands)
        {
            command.Execute();
            battleData.executedCommands.Add(command);
        }

        battleData.queuedCommands = new List<ICommand>();

        ApplyEndOfTurnEffects();
    }

    public void QueueCommand(ICommand command)
    {
        battleData.queuedCommands.Add(command);
    }

    public void SendPlayerInput(int moveIndex)
    {
        if (moveIndex >= Constants.NUMBER_OF_LEARNABLE_MOVES)
        {
            HelperFunctions.ThrowException("moveIndex was above the learnable move limit.");
        }

        if (moveIndex > ActivePlayerEntity.MoveslotDatas.Count)
        {
            HelperFunctions.ThrowException("moveIndex was above the number of known moves");
        }

        // Player attack command
        QueueCommand(GenerateAttackCommand(ActivePlayerEntity, ActiveEnemyEntity, moveIndex));

        // Enemy attack command
        QueueCommand(GenerateAttackCommand(ActiveEnemyEntity, ActivePlayerEntity, 0));

        // Process the turn
        ProcessTurn();
    }

    private EntityAttackEntityCommand GenerateAttackCommand(Entity attacker, Entity defender, int moveIndex)
    {
        return new EntityAttackEntityCommand(attacker, defender, attacker.MoveslotDatas[moveIndex].moveKey, this);
    }

    private void SendEntityIntoBattle(Entity entity, Entity other, ref Entity activeEntity)
    {
        EntitySentIntoBattle entitySentIntoBattle = new EntitySentIntoBattle(entity, other);
        entitySentIntoBattle.Execute();

        activeEntity = entity;
    }

    private void SetActiveEntities()
    {
        SendEntityIntoBattle(battleData.playerEntities[0], battleData.activeEnemyEntity, ref battleData.activePlayerEntity);
        SendEntityIntoBattle(battleData.enemyEntities[0], battleData.activePlayerEntity, ref battleData.activeEnemyEntity);
    }
}