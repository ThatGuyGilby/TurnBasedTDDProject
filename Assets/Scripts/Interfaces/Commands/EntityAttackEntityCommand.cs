using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackEntityCommand : ICommand
{
    public Entity attacker;
    public Entity defender;
    public MoveKey moveKey;

    public EntityAttackEntityCommand(Entity attacker, Entity defender, MoveKey moveKey)
    {
        this.attacker = attacker;
        this.defender = defender;
        this.moveKey = moveKey;
    }

    public void Execute()
    {
        MoveData moveData = HelperFunctions.MoveDataFromMoveKey(moveKey);

        float moveAttributeDamageMultiplier = defender.GetIncomingMultiplier(moveData.attributeKey);
        // stab  bonus
        // weather bonus
        // random roll
        int power = moveData.power;
        int atk = attacker.Attack;
        int def = defender.Defence;

        float baseDamage = (((((2f * (float)attacker.Level) / 5f) + 2f) * power * atk / def) / 50f) + 2f;

        baseDamage *= moveAttributeDamageMultiplier;

        int damage = Mathf.CeilToInt(baseDamage);

        if (attacker.IsAlive())
        {
            Debug.Log($"{defender.Name} took {damage} damage from {attacker.Name}'s {moveData.name}");
            defender.TakeDamage(damage);
        }
    }
}
