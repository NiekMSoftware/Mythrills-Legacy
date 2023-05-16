using RPG.EnemyCombat;

namespace RPG;

public class Player_Combat_Text
{
    private Random rand = new Random();
    
    //Reference the Enemy Choice class
    private Enemy_Choice _enemyChoice = new Enemy_Choice();

    public void PlayerAttackFast()
    {
        int dealDamage = (RunGame.currentPlayer.damage + RunGame.currentPlayer.weaponValue);

        string[] text = new[]
        {
            //TODO: Display 6 different strings when Attacking Faster
            
            //String 1
            "You bravely sheathe your Sword, gazing with a soulless" +
            $"\nface at the {EnemyStats.nameEnemy}..." +
            $"You cut your blade through the {EnemyStats.nameEnemy}s flesh" +
            $"\nand dealt {dealDamage}",
            
            //String 2
            
            //String 3
            
            //String 4
            
            //String 5
        };
            
        //Gather the Array and Randomize it
        string attackText = text[rand.Next(0, text.Length)];
            
        //Display the attack string
        Console.WriteLine(attackText);
        
        //Reduce health of the enemy
        EnemyStats.healthEnemy -= dealDamage;
    }

    public void PlayerAttackSlow()
    {
        if (Enemy_Choice.isDefending)
            //Use the Method to display the array
            EnemyFailedDefendOrNot();
        else if (Enemy_Choice.isHealing)
            EnemyFailedHealingOrNot();
        else //if the enemy is not defending, display text for attacking
        {
            int dealDamage = RunGame.currentPlayer.damage + RunGame.currentPlayer.weaponValue;

            string[] text = new[]
            {
                //TODO: Display 6 different strings when Attacking Slower
                $"\nYou managed to deal {dealDamage} damage!"
            };
                
            //Gather the Array and Randomize it
            string attackText = text[rand.Next(0, text.Length)];
                
            //Display the attack string
            Console.WriteLine(attackText);

            EnemyStats.healthEnemy -= dealDamage;
        }
    }

    #region Player Resoponse to Enemy Interaction

    void EnemyFailedDefendOrNot()
    {
        //Give it a 13% chance of the enemy failing to defend
        switch (rand.Next(0,8))
        {
            case 0:
                EnemyDidDefend();
                break;
            case 1:
                EnemyFailedDefense();
                break;
            default:
                EnemyDidDefend();
                break;
        }
    }

    void EnemyFailedHealingOrNot()
    {
        switch (rand.Next(0,8))
        {
            case 0:
                EnemyDidHeal();
                break;
            case 1:
                EnemyFailedHealing();
                break;
            default:
                EnemyDidHeal();
                break;
        }
    }
    
    void EnemyDidDefend()
    {
        
        //Display the text here of when the Enemy Defends
        string[] textDefending = new[]
        {
            //TODO: Display 3 different strings when Enemy Defends
            "\nThe enemy managed to Defend!" +
            "\nYou dealt 0 damage!"
        };
            
        //Gather the Array and Randomize it
        string defendText = textDefending[rand.Next(0, textDefending.Length)];
            
        //Display the attack string
        Console.WriteLine(defendText);
    }

    void EnemyFailedDefense()
    {
        int dealDamage = RunGame.currentPlayer.damage + RunGame.currentPlayer.weaponValue;
        
        //Display the text here of when the Enemy Defends
        string[] textFailed = new[]
        {
            //TODO: Display 4 different strings when Enemy Defends
            $"\nThe {EnemyStats.nameEnemy} failed to defend properly!" +
            $"\nYou managed to deal {dealDamage} damage!"
        };
            
        //Gather the Array and Randomize it
        string failedDefenseText = textFailed[rand.Next(0, textFailed.Length)];
            
        //Display the attack string
        Console.WriteLine(failedDefenseText);
    }

        #region Enemy Healing

        void CanHeal()
        {
            if (EnemyStats.potions <= 0)
                _enemyChoice.EnemyChoice();
            else
                EnemyRanOut();
        }
        void EnemyDidHeal()
        {
            //Calculate how much health the enemy regains
            int regainedHealth = rand.Next(15,26);
            EnemyStats.potionValue = regainedHealth;
            
            //Display several strings
            string[] text = new[]
            {
                $"Successfully, the {EnemyStats.nameEnemy} gained" +
                $"\n{regainedHealth} health back!"
            };

            //Randomize the array
            string healingText = text[rand.Next(0, text.Length)];

            //Display the text
            Console.WriteLine(healingText);
            
            //Add health back to the enemy
            EnemyStats.healthEnemy += regainedHealth;
            
            //Reduce the amount of Potions
            EnemyStats.potions--;
            if (EnemyStats.potions <= 0) //Reset the potions back to 0
                EnemyStats.potions = 0;

            //Turn the bool back to false
            Enemy_Choice.isHealing = false;
            
            //Resume logic
        }

        void EnemyFailedHealing()
        {
            int dealDamage = (RunGame.currentPlayer.damage + RunGame.currentPlayer.weaponValue)
                             + rand.Next(3, 12);

            string[] text = new[]
            {
                //TODO: Make 4 different strings in this array
                
                "The enemy thought he could heal, but you managed" +
                $"\nto deal {dealDamage} damage!" +
                $"\nThe {EnemyStats.nameEnemy} was unable to regain health"
            };

            //Randomize the array
            string damageText = text[rand.Next(0, text.Length)];
            
            //Display the text
            Console.WriteLine(damageText);
            
            //Continue logic
        }

        void EnemyRanOut()
        {
            
        }
        
        #endregion
    
    #endregion
   
}