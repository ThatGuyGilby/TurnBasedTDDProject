using UnityEngine;

public class EntityAttackEntityCommand : ICommand
{
    #region Public Fields

    public Entity attacker;
    public Entity defender;
    public MoveKey moveKey;

    #endregion Public Fields

    #region Public Constructors

    public EntityAttackEntityCommand(Entity attacker, Entity defender, MoveKey moveKey)
    {
        this.attacker = attacker;
        this.defender = defender;
        this.moveKey = moveKey;
    }

    #endregion Public Constructors

    #region Public Methods

    public void Execute()
    {
        MoveData moveData = HelperFunctions.moveDataRepository.DataFromKey(moveKey);

        float moveAttributeDamageMultiplier = defender.GetIncomingMultiplier(moveData.attributeKey);
        float stabBonus = attacker.GetSTABMultiplier(moveData.attributeKey);
        // weather bonus
        // random roll
        int power = moveData.power;
        int atk = 0;
        int def = 0;

        HelperFunctions.Log($"{attacker.Name} used {moveData.name}!");

        if (moveData.preset == "Physical")
        {
            atk = attacker.Attack;
            def = defender.Defence;
        }

        if (moveData.preset == "Special")
        {
            atk = attacker.SpecialAttack;
            def = defender.SpecialDefence;
        }

        if (moveData.preset == "Special" || moveData.preset == "Physical")
        {
            switch (moveAttributeDamageMultiplier)
            {
                case 0.25f:
                case 0.5f:
                    HelperFunctions.Log("It's not very effectivve...");
                    break;

                case 2f:
                case 4f:
                    HelperFunctions.Log("It's super effective!");
                    break;
            }

            float baseDamage = (((((2f * (float)attacker.Level) / 5f) + 2f) * power * atk / def) / 50f) + 2f;

            baseDamage *= moveAttributeDamageMultiplier;
            baseDamage *= stabBonus;

            int damage = Mathf.RoundToInt(baseDamage);

            if (attacker.IsAlive())
            {
                defender.TakeDamage(damage);

                float percentDamage = (damage / (float)defender.Health) * 100f;

                HelperFunctions.Log($"The opposing {defender.Name} lost {Mathf.RoundToInt(percentDamage)}% of its health!");

                if (!defender.IsAlive())
                {
                    HelperFunctions.Log($"The opposing {defender.Name} fainted!");
                }
            }
        }
    }

    #endregion Public Methods
}