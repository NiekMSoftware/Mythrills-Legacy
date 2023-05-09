namespace RPG;

public class PlayerActions
{
    private static Random rand = new Random();
    
    //TODO: Make a new action to the Enemy that is defending
    //Also make it so the enemy's defense can be broken
    public static void EnemyIsDefending()
    {
        //Make it a 20% chance of the enemy failing to defend
        switch (rand.Next(0,5))
        {
            case 0:
                ActionToDefense();
                break;
            case 1:
                EnemyFailedDefend();
                break;
            default:
                ActionToDefense();
                break;
        }
    }

    #region Actions when Enemy Defends

    private static void ActionToDefense()
    {
        string[] text = new[]
        {
            $"The Enemy did defend",
            "wow he defended"
        };

        string defendedText = text[rand.Next(0, text.Length)];
        Console.WriteLine(defendedText);
        EnemyActions.isDefending = false;
    }

    private static void EnemyFailedDefend()
    {
        string nameEnemy = EnemyStats.nameEnemy;
        
        int dealDamage = (RunGame.currentPlayer.weaponValue + rand.Next(4, 12))
                         - (EnemyStats.armorEnemy / 4);
        
        string[] text = new[]
        {
            $"Bruh the {nameEnemy} failed to defend, you did {dealDamage} damage!"
        };

        string defendedText = text[rand.Next(0, text.Length)];
        Console.WriteLine(defendedText);
        
        EnemyActions.isDefending = false;

        //Lower the health of the enemy
        EnemyStats.healthEnemy -= dealDamage;
    }

    #endregion

    #region Enemy is Healing

    public static void HealOrAttack()
    {
        switch (rand.Next(0,2))
        {
            case 0:
                AttackWhenHeal();
                break;
            case 1:
                EnemyHeals();
                break;
        }
    }
    
    public static void AttackWhenHeal()
    {
        int dealDamage = (RunGame.currentPlayer.damage + RunGame.currentPlayer.weaponValue)
                         + (RunGame.currentPlayer.weaponValue / EnemyStats.armorEnemy);

        string[] text = new[]
        {
            $"They healed, but I dealt {dealDamage} damage!",
        };

        string attackText = text[rand.Next(0, text.Length)];
        Console.WriteLine(attackText);

        EnemyActions.isHealing = false;
    }

    public static void EnemyHeals()
    {
        EnemyActions.Heal();
        
        string[] text = new[]
        {
           "You've let the enemy heal, you stupid"
        };

        string attackText = text[rand.Next(0, text.Length)];
        Console.WriteLine(attackText);

        EnemyActions.isHealing = false;
    }
    
    #endregion
}