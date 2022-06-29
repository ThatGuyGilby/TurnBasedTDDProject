using NUnit.Framework;

public class BattleTests
{
    [Test]
    public void BattleIsInitialized()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).Build();

        battle.Initialize();

        Assert.IsTrue(battle.IsInitialized);
    }

    [Test]
    public void BattleQueueAndExecuteCommand()
    {
        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        charmander.Initialize();

        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();
        bulbasaur.Initialize();

        Battle battle = new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayerEntity(charmander).Build();
        battle.Initialize();

        ICommand playerAttackEnemyCommand = new EntityAttackEntityCommand(charmander, bulbasaur, MoveKey.FLAMETHROWER);
        battle.QueueCommand(playerAttackEnemyCommand);
        battle.ExecuteQueuedCommands();

        Assert.IsFalse(battle.ActiveEnemyEntity.IsAlive());
    }

    [Test]
    public void Ttt()
    {
        //HelperFunctions.OutputDummyData();
    }
}
