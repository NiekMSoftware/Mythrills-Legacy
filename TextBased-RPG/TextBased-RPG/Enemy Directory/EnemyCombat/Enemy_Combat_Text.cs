﻿namespace RPG.EnemyCombat;

public class Enemy_Combat_Text
{
    /*
        * TODO: Attack Function
        * -Make 6 different attack Strings for the enemy to use
        * -Make it so the Enemy is able to Critical Hit
    */
    
    //Random
    private Random rand = new Random();

    //TODO: Finish the attack array Methods
    #region Enemy Attack Methods

    public void EnemyAttacks()
    {
        //Damage
        int enemyDamage = EnemyStats.powerEnemy - RunGame.currentPlayer.armorValue;
        
        //Text to give to the Enemy to use, TODO: Give the array 6 different strings
        string[] text = new[]
        {
            //String 1
            $"The {EnemyStats.nameEnemy} dealt {enemyDamage} damage to you!",
            
            //String 2
            $"The {EnemyStats.nameEnemy} hit you with a massive blow and did " +
            $"{enemyDamage} damage!"
            
            //String 3
        };
        
        //Randomize the text use for variation
        string enemyText = text[rand.Next(0, text.Length)];

        //Display the Enemy Text usage
        Console.WriteLine(enemyText);
        
        //Decrease the health from the given damage
        RunGame.currentPlayer.health -= enemyDamage;
    }

    public void EnemyAttacksSlower()
    {
        //Damage
        int enemyDamage = EnemyStats.powerEnemy / RunGame.currentPlayer.armorValue;
        
        //Text to give to the Enemy to use, TODO: Give the array 6 different strings
        string[] text = new[]
        {
            //String 1
            $"\nAfter you struck your sword through the {EnemyStats.nameEnemy}s chest," +
            $"\nthe {EnemyStats.nameEnemy} managed to slice your ankle and" +
            $"\ndealt {enemyDamage} to you!"
            
            //String 2
            
            
            //String 3
        };
        
        //Randomize the text use for variation
        string enemyText = text[rand.Next(0, text.Length)];

        //Display the Enemy Text usage
        Console.WriteLine(enemyText);
        
        //Decrease the health from the given damage
        RunGame.currentPlayer.health -= enemyDamage;
    }
    public void EnemyAttacksCritical()
    {
        //Damage
        int enemyDamageCrit = EnemyStats.powerEnemy + rand.Next(4, 13);
        
        //Text to get used by the Enemy
        string[] text = new[]
        {
            $"A Critical Hit!" +
            $"\nThe {EnemyStats.nameEnemy} hit you" +
            $" for {enemyDamageCrit} damage!"
        };
        
        //Randomize the array
        string enemyText = text[rand.Next(0, text.Length)];
        
        //Display the Text
        Console.WriteLine(enemyText);
        
        //Decrease the health from the given damage
        RunGame.currentPlayer.health -= enemyDamageCrit;
    }
    
    #endregion

    //TODO: Finish randomizing the Strings
    #region Enemy Defend Methods

    public void EnemyDefends()
    {
        Console.WriteLine($"The {EnemyStats.nameEnemy} defended!");
    }

    #endregion

    //TODO: Finish randomizing Strings
    #region Enemy Heal Methods

    public void EnemyHeals()
    {
        string[] text = new[]
        {
            $"\nThe {EnemyStats.nameEnemy} grabbed a flask from its belt.",
        };

        string healingText = text[rand.Next(0, text.Length)];

        Console.WriteLine(healingText);
    }

    #endregion
}