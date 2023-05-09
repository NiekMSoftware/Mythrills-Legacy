﻿namespace RPG;

public class EnemyActions
{
    /*
     * Give the Enemy the ability to do several things;
     * Heal: restore health
     * Defend: if the speed is higher, it is able to defend
     * Attack: based also on speed
     */

    //Player Reference
    private Player _player = new Player();
    
    //Global Variables
    private static Random rand = new Random();
    
    //Bool to check if the AI defended
    public static bool isDefending = false;

    public static bool isDefendingSlow = false;
    
    //Bool to detect if the enemy healed
    public static bool isHealing = false;

    public static void RunCombat()
    {
        EnemyCombat();
    }
    public static void EnemyCombat()
    {
        if (EnemyStats.speedEnemy > RunGame.currentPlayer.speed)
        {
            EnemyCombatChoise.EnemyChoice_SpeedHigh();
        }
        else //if slower then run this
        {
            EnemyCombatChoise.EnemyChoice_SpeedLow();
        }
    }

    #region Enemy Combat Region

    
    public static void Attack()
    {
        int dealDamage;
        int bonusDamage;

        bool hitCritical = false;
        
        //Give the AI a 5% chance to Critical Hit
        if (rand.Next(0, 20) == 0)
        {
            bonusDamage = EnemyStats.powerEnemy + rand.Next(3, 12);
        
            //Add extra damage to the Attack of the enemy
            dealDamage = EnemyStats.powerEnemy + bonusDamage;

            Console.WriteLine("A critical hit!");
            Console.WriteLine("The enemy hit you for " + dealDamage);
            RunGame.currentPlayer.health -= dealDamage;
        }
        else
        {
            dealDamage = EnemyStats.powerEnemy + rand.Next(0,4);
            Console.WriteLine("The enemy hit you for " + dealDamage);
            RunGame.currentPlayer.health -= dealDamage;
        }
    }
    
    public static void Heal()
    {
        if (EnemyStats.potions <= 0)
                EnemyStats.potions = 0;

        EnemyStats.potionValue = rand.Next(30, 40);

        if (EnemyStats.potions <= 0)
        {
            switch (rand.Next(0,1))
            {
                case 0:
                    Attack();
                    break;
                case 1:
                    Defend();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Hehe too bad, me Heal now");
            EnemyStats.healthEnemy += EnemyStats.potionValue;
            Console.WriteLine("They gained " + EnemyStats.potionValue + " health");

            if (EnemyStats.healthEnemy >= EnemyStats.maxHealthEnemy)
            {
                EnemyStats.healthEnemy = EnemyStats.maxHealthEnemy;
            }
            EnemyStats.potions--;
        }
    }
    private static void Defend()
    {
        isDefending = true;
        Console.WriteLine("Successfully defended");
    }
    
    public static void DefendSlowSpeed()
    {
        Console.WriteLine("Successfully defended whilst being slower");
        Console.ReadLine();
    }

    public static void DefendHighSpeed()
    {
        isDefending = true;
        Console.WriteLine("Successfully defended");
    }
    
    #endregion
}