using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BattleBehaviourTests
{
    [UnityTest]
    public IEnumerator BattleBehaviourInitialize()
    {
        BattleBehaviour battleBehaviour = GameObject.FindObjectOfType<BattleBehaviour>();

        Entity charmander = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.CHARMANDER).Build();
        Entity bulbasaur = new EntityBuilder().WithLevel(5).WithSpecies(SpeciesKey.BULBASAUR).Build();

        Player player = new PlayerBuilder().WithEntity(charmander).Build();

        yield return null;

        battleBehaviour.Initialize(new BattleBuilder().WithEnemyEntity(bulbasaur).WithPlayer(player).WithWeatherKey(WeatherKey.SUN));

        Assert.IsTrue(battleBehaviour.IsInitialized);
    }

    [UnityTest]
    public IEnumerator BattleBehaviourIsFoundInTestScene()
    {
        BattleBehaviour battleBehaviour = GameObject.FindObjectOfType<BattleBehaviour>();

        yield return null;

        Assert.NotNull(battleBehaviour);
    }

    [OneTimeSetUp]
    public void LoadTestScene()
    {
        SceneManager.LoadScene("BattleTestScene");
    }
}