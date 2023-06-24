﻿using System.Collections.Specialized;
using RPG.EnemyCombat;

namespace RPG;

public class PlayerInput
{
    //Enemy stats
    private EnemyStats _enemy = new EnemyStats();
    
    //Combat Enemy and Player
    private Enemy_Choice enemyChoice;
    // private Enemy_Combat_Text enemyText;
    
    private Player_Combat_Text playerText;
    
    //Random
    private Random rand = new Random();
    // Player
    public Player currentPlayer;

    public bool isAttacking;
    public static bool isHealing;

    public PlayerInput(Player player)
    {
        this.currentPlayer = player;
        this.playerText = new Player_Combat_Text(this.currentPlayer, this);
        this.enemyChoice = new Enemy_Choice(this.currentPlayer, this);
        // this.enemyText = new Enemy_Combat_Text(this.currentPlayer);
    }

    /*
     * Receive the Player's Input
     */
    public void Input()
    {
        string input = Console.ReadLine();

        switch (input.ToLower())
        {
            case string a when a == "a":
                Attack();
                break;
            case string d when d == "d":
                Defend();
                break;
            case string h when h == "h":
                Heal();
                break;
            case string l when l == "l":
                Leap();
                break;
            default:
                NoInput();
                break;
        }
    }
    
    #region Player Actions
    private void Attack()
    {
        isAttacking = true;
        
        //Check if the enemy is faster than the player
        if (EnemyStats.speedEnemy > this.currentPlayer.speed)
        {
            //Run the enemy script
            enemyChoice.EnemyChoice();
            
            // Check if the enemy is defending
            if (this.enemyChoice.isDefending) {
                this.playerText.EnemyDidDefend();
            }
            
            //Run the Player Attack 
            playerText.PlayerAttackSlow();
            
        } // If not then run the other combat
        else if (this.currentPlayer.speed > EnemyStats.speedEnemy)
        {
            //First run the Player Combat
            playerText.PlayerAttackFast();
        }
        
        Console.ReadLine();
    }

    private void Defend()
    {
        //The power of the enemy will be lessened
        int damageTaken = (EnemyStats.powerEnemy / 3) - this.currentPlayer.armorValue;
        if (damageTaken < 0)
            damageTaken = 0;

        //Make a random value so it will negate damage back to the enemy in our Defensive stance
        int dealDamage = rand.Next(2, this.currentPlayer.weaponValue);

        //Make a random value to gain health back
        int gainHealth = rand.Next(5, this.currentPlayer.minHealthHealing);

        //Make an array with different texts when defending
        string text = "";
        string[] defendText = new[]
        {
            $"As the {EnemyStats.nameEnemy} prepares to strike you down, you ready your sword in a defensive stance." +
            $"\nYou lose {damageTaken} health and dealt {dealDamage} damage!",
            $"The {EnemyStats.nameEnemy} charges at you ever so magnificent, you hold your sword with both hands in a" +
            $" effective yet majestic stance. " +
            $"\nYou lost {damageTaken} health, but managed to deal {dealDamage} damage with a marvelous swing!",
            $"As the {EnemyStats.nameEnemy} charges at you rapidly, you ready yourself from impact." +
            $"\nWith courage you release a sigh and cough up blood from the impact," +
            $"\nyou lost {damageTaken} health..." +
            $"\nthe {EnemyStats.nameEnemy} looks afraid, as the wound you inflicted was more than it could endure!" +
            $"\nYou dealt {dealDamage} damage..."
        };

        //Randomize defend texts
        text = defendText[rand.Next(0, defendText.Length)];

        //Make an array to defend and get health back from it
        string[] defendTextHealth = new[]
        {
            $"As you successfully defend yourself against the {EnemyStats.nameEnemy}," +
            $"\nyou managed to steal it's life and use it gain {gainHealth} health!"
        };

        //Make it a chance to gain health back, 2% chance
        if (rand.Next(1, 51) == 1)
        {
            //Gain health when successful
            this.currentPlayer.health += gainHealth;

            Console.WriteLine(defendTextHealth[0]);

            //Return health back to the max when higher 
            if (this.currentPlayer.health >= this.currentPlayer.maxHealth)
            {
                this.currentPlayer.health = this.currentPlayer.maxHealth;
            }
        }
        else
        {
            Console.WriteLine(text);
            //Lower health
            this.currentPlayer.health -= damageTaken;
            EnemyStats.healthEnemy -= dealDamage;
        }

        Console.ReadLine();
    }
    
    private void Heal()
    {
        int maxHealth = this.currentPlayer.maxHealth;
        
        

        //Check how many potions our player has left

        if (this.currentPlayer.potions == 0)
        {
            //Calculate how much health we will lose upon no flasks
            int damageTaken = EnemyStats.powerEnemy - this.currentPlayer.armorValue;
            if (damageTaken < 0)
                damageTaken = 0;

            //Fail to heal
            Console.WriteLine("As you desperately grasp for a potion in your pouch, " +
                              "all that you feel are empty glass flasks");
            Console.WriteLine("The " + EnemyStats.nameEnemy + " strikes you with a mighty blow and you lose "
                              + damageTaken + " health!");
        }
        else
        {
            playerText.PlayerHeals();
            Console.ReadKey();
        }
    }

    private void Leap()
    {
            int nonDamageTaken = 0;

            int damageTaken = (EnemyStats.powerEnemy - this.currentPlayer.armorValue) + rand.Next(8, 22);

            //Make the Leap rng, so there is a chance you will get hit
            if (rand.Next(0, this.currentPlayer.leap) == 0)
            {
                string text = "";
                string[] leapFailure = new[]
                {
                    "As you tried to leap through your enemy's legs, the " + EnemyStats.nameEnemy +
                    " catches you while you leaped.." +
                    "\nThe " + EnemyStats.nameEnemy + " sliced you brutally and dealt " + damageTaken + " damage!",
                    "You take a deep breath, controlling your breathing to getting ready to dodge the " +
                    EnemyStats.nameEnemy + ", " +
                    "\nunnoticed the " + EnemyStats.nameEnemy +
                    " charges at you and pins you down with its sword through your chest..." +
                    "\nThe " + EnemyStats.nameEnemy + " dealt " + damageTaken + " damage!",
                    "You quickly try to evade the " + EnemyStats.nameEnemy +
                    " attack by crouching! Unfortunately, the " + EnemyStats.nameEnemy + " managed to hit" +
                    "\nyou in the head with it's sword... \nThe " + EnemyStats.nameEnemy + " dealt " + damageTaken +
                    " damage!"
                };

                //Randomize the text
                text = leapFailure[rand.Next(0, leapFailure.Length)];

                //Display the text
                Console.WriteLine(text);

                //Receive damage
                this.currentPlayer.health -= damageTaken;
            }
            else
            {
                string text = "";
                string[] leapText = new[]
                {
                    "As you leaped through your enemy's legs, you successfully dodged the " + EnemyStats.nameEnemy +
                    "'s attack!" +
                    "\nYou received " + nonDamageTaken + " damage!",
                    "You take a deep breath, controlling your breathing and jump over the " + EnemyStats.nameEnemy +
                    "" +
                    "\nyou received " + nonDamageTaken + " damage!",
                    "You crouch quickly as the sword of the " + EnemyStats.nameEnemy + " almost hits you" +
                    "\nand successfully dodged it's attack! \nYou received " + nonDamageTaken + " damage!"
                };

                text = leapText[rand.Next(0, leapText.Length)];
                Console.WriteLine(text);
            }

            Console.ReadLine();
    }

    private void NoInput()
    {
        Console.WriteLine("Please enter an Input..");
        Console.ReadKey();
    }
    
    #endregion
}