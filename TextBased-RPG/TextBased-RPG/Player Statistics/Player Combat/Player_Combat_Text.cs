using RPG.EnemyCombat;

namespace RPG;

public class Player_Combat_Text
{
    private Random rand = new Random();
    private Enemy_Combat_Text enemyText;

    PlayerInput playerInput;
    
    //Reference the Enemy Choice class
    private Enemy_Choice enemyChoice;
    public Player currentPlayer;
        
    public Player_Combat_Text(Player _player, PlayerInput _playerInput)
    {
        this.currentPlayer = _player;
        this.playerInput = _playerInput;
        
        this.enemyChoice = new Enemy_Choice(this.currentPlayer, this.playerInput);
        this.enemyText = new Enemy_Combat_Text(this.currentPlayer);
    }

    #region Player Attacks

    public void PlayerAttackFast()
    {
        // Let's see what the enemy does before I can strike
        this.enemyChoice.EnemyChoice();
        
        if (this.enemyChoice.isDefending) {
            this.EnemyDidDefend();
        }
        else {
            int dealDamage = (this.currentPlayer.damage + this.currentPlayer.weaponValue);

            string[] text = new[]
            {
                //TODO: Display 6 different strings when Attacking Faster
            
                //String 1
                "You bravely sheathe your Sword, gazing with a soulless" +
                $"\nface at the {EnemyStats.nameEnemy}..." +
                $"You cut your blade through the {EnemyStats.nameEnemy}s flesh" +
                $"\nand dealt {dealDamage}",
            
                //String 2
                "ye"
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
    }

    public void PlayerAttackSlow()
    {
        if (this.enemyChoice.isDefending)
            //Use the Method to display the array
            EnemyFailedDefendOrNot();
        else if (this.enemyChoice.isHealing)
            EnemyDidHeal();
        else if (this.enemyChoice.cantHeal)
            EnemyFailedHealing();
        else //if the enemy is not defending or healing,
            //display text for attacking
        {
            int dealDamage = this.currentPlayer.damage + this.currentPlayer.weaponValue;

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

    #endregion

    //TODO: Make 5 different strings for when you heal
    #region Player Heals

    public void PlayerHeals() { 
        int potionValue = this.currentPlayer.potionValue;

        if (this.currentPlayer.health < this.currentPlayer.maxHealth)
        {
            string[] text = new[]
            {
                $"You gained {potionValue} health!",
                $"You gained {potionValue} health!",
            };

            string healingText = text[rand.Next(0, text.Length)];

            Console.WriteLine(healingText);

            //Add the potion health value to the player's Health
            this.currentPlayer.health += potionValue;
            
            //Check if the Enemy's HP is below a third
            if (EnemyStats.healthEnemy <= EnemyStats.maxHealthEnemy / 3)
            {
                //Give it a 10% chance for the enemy to Attack instead of heal
                switch (rand.Next(0,10))
                {
                    case 0:
                        enemyText.EnemyHeals();
                        break;
                    case 1:
                        enemyChoice.EnemyAttacks();
                        break;
                    default:
                        enemyText.EnemyHeals();
                        break;
                }
            }
            else
                enemyText.EnemyDamagesYou();
        }
        
        // Check if the player health is higher than max health
        if (this.currentPlayer.health + potionValue > this.currentPlayer.maxHealth)
            this.currentPlayer.health = this.currentPlayer.maxHealth;
    }

    #endregion

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
        if(this.enemyChoice.cantHeal)
            EnemyFailedHealing();
        else
            EnemyDidHeal();    
    }
    
    public void EnemyDidDefend()
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
        int dealDamage = this.currentPlayer.damage + this.currentPlayer.weaponValue;
        
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
        
        void EnemyDidHeal()
        {
            //Display several strings
            string[] text = new[]
            {
                $"\nThe {EnemyStats.nameEnemy} successfully healed"
            };

            //Randomize the array
            string healingText = text[rand.Next(0, text.Length)];

            //Display the text
            Console.WriteLine(healingText);
        }

        void EnemyFailedHealing()
        {
            int dealDamage = (this.currentPlayer.damage + this.currentPlayer.weaponValue)
                             + rand.Next(3, 12);

            string[] text = new[]
            {
                //TODO: Make 4 different strings in this array
                
                "The enemy thought he could heal, but you managed" +
                $"\nto deal {dealDamage} damage!" +
                $"\n\nThe {EnemyStats.nameEnemy} was unable to regain health"
            };

            //Randomize the array
            string damageText = text[rand.Next(0, text.Length)];
            
            //Display the text
            Console.WriteLine(damageText);
            
            //Remove health based on the damage
            EnemyStats.healthEnemy -= dealDamage;

            //Continue logic
        }

        #endregion
    
    #endregion
}