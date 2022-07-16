using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBehaviour : MonoBehaviour
{
    [SerializeField] private Battle battle;

    public bool IsInitialized => battle.IsInitialized;

    public void Initialize(BattleBuilder battleBuilder)
    {
        battle = battleBuilder.Build();
    }

    public void SendPlayerMove(int moveIndex)
    {
        battle.SendPlayerInput(moveIndex);
    }

    private void Start()
    {
        battle = null;
    }
}