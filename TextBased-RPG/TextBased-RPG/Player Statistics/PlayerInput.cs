using System.Collections.Specialized;

namespace RPG;

public class PlayerInput
{
    private static EnemyStats _enemy = new EnemyStats();
    private static Random rand = new Random();

    /*
     * Receive the Player's Input
     */
    public void Input()
    {
        string input = Console.ReadLine();

        switch (input.ToLower())
        {
            case string a when a.Contains("a"):
                Attack();
                break;
            case string d when d.Contains("d"):
                Defend();
                break;
            case string r when r.Contains("r"):
                Run();
                break;
            case string h when h.Contains("h"):
                Heal();
                break;
            case string l when l.Contains("l"):
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
         //Damage the player
            int damageTaken = (EnemyStats.powerEnemy - RunGame.currentPlayer.armorValue) + rand.Next(2, 10);

            if (damageTaken < 0)
                damageTaken = 0;

            //Make a random value so it will add more damage to our Weapon (so critical hit)
            int dealDamage = 0;

            /*
             * Make it so you're able to miss
             */
            if (rand.Next(0, RunGame.currentPlayer.evasion) == 1)
            {
                Console.WriteLine("You missed!");
                Console.WriteLine("You took " + damageTaken + " damage!");
            }
            else
            {
                dealDamage = (RunGame.currentPlayer.weaponValue + RunGame.currentPlayer.damage) + rand.Next(0, 8);

                //Make an array with different texts when attacking
                string text = "";
                string[] attackText = new[]
                {
                    $"With haste you surge forth, your sword flying through your hands!" +
                    $"\nAs you pass the {EnemyStats.nameEnemy} strikes you" +
                    $"\nYou dealt {dealDamage} damage!" +
                    $"\nYou received {damageTaken} damage!",
                    $"You run towards the {EnemyStats.nameEnemy} with your blade in two hands, you strike! " +
                    $"\nYou managed to deal {dealDamage} to the {EnemyStats.nameEnemy}!" +
                    $"\nThe {EnemyStats.nameEnemy} managed to stab you ever so slightly and dealt {damageTaken} damage!",
                    $"You quickly try to evade the {EnemyStats.nameEnemy} and strike its legs dealing {dealDamage} damage!" +
                    $"\nUnfortunately, the {EnemyStats.nameEnemy} managed to throw it's weapon in your stomach..." +
                    $"\nThe {EnemyStats.nameEnemy} dealt {damageTaken} damage!",
                    $"With anger and yet a lot of fear, your sword trembling but heroic in your hands!" +
                    $"\nYou charge at the {EnemyStats.nameEnemy} piercing your sword through the {EnemyStats.nameEnemy}'s chest!" +
                    $"\nYou dealt {dealDamage} damage!" +
                    $"\nThe {EnemyStats.nameEnemy} managed to hit you as hard back dealing {damageTaken} damage!"
                };

                //randomize attack texts
                text = attackText[rand.Next(0, attackText.Length)];

                //Attack
                Console.WriteLine(text);
            }

            //Lower health
            RunGame.currentPlayer.health -= damageTaken;
            EnemyStats.healthEnemy -= dealDamage;

            Console.ReadLine();
    }

    private void Defend()
    {
          //The power of the enemy will be lessened
            int damageTaken = (EnemyStats.powerEnemy / 3) - RunGame.currentPlayer.armorValue;
            if (damageTaken < 0)
                damageTaken = 0;

            //Make a random value so it will negate damage back to the enemy in our Defensive stance
            int dealDamage = rand.Next(2, RunGame.currentPlayer.weaponValue);

            //Make a random value to gain health back
            int gainHealth = rand.Next(5, RunGame.currentPlayer.minHealthHealing);

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
                RunGame.currentPlayer.health += gainHealth;

                Console.WriteLine(defendTextHealth[0]);

                //Return health back to the max when higher 
                if (RunGame.currentPlayer.health >= RunGame.currentPlayer.maxHealth)
                {
                    RunGame.currentPlayer.health = RunGame.currentPlayer.maxHealth;
                }
            }
            else
            {
                Console.WriteLine(text);
                //Lower health
                RunGame.currentPlayer.health -= damageTaken;
                EnemyStats.healthEnemy -= dealDamage;
            }

            Console.ReadLine();
    }

    private void Run()
    {
        //Make a random generated number for a chance to run away
        if (rand.Next(0, 2) == 0)
        {
            //Calculate the amount of damage being taken
            int damageTaken = EnemyStats.powerEnemy - RunGame.currentPlayer.armorValue;
            if (damageTaken < 0)
                damageTaken = 0;

            //Continue story
            Console.WriteLine("As you sprint away from the " + EnemyStats.nameEnemy +
                              ", its strike catches you in the back, sending you sprawling onto the ground");
            Console.WriteLine("You lose " + damageTaken + " health and are unable to escape.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("You ran away from the " + EnemyStats.nameEnemy + " successfully escaped!");
            Console.ReadLine();
            //go to store - CONCEPT
        }

        Console.ReadLine();
    }

    private void Heal()
    {
        int maxHealth = RunGame.currentPlayer.maxHealth;

            //Check how many potions our player has left
            if (RunGame.currentPlayer.potions == 0)
            {
                //Calculate how much health we will lose upon no flasks
                int damageTaken = EnemyStats.powerEnemy - RunGame.currentPlayer.armorValue;
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
                //Declare how much a flask will heal
                int _potionValue = RunGame.currentPlayer.potionValue;

                //Declare how much damage you will take
                int damageTaken = ((EnemyStats.powerEnemy / 2) + rand.Next(0, 5)) - RunGame.currentPlayer.armorValue;
                if (damageTaken < 0)
                    damageTaken = 0;

                //Note down how many potions the player has got left
                RunGame.currentPlayer.potions--;

                //Reach max health and still use a flask
                if ((RunGame.currentPlayer.health + _potionValue) > maxHealth)
                {
                    RunGame.currentPlayer.health = RunGame.currentPlayer.maxHealth;
                    Console.WriteLine(
                        "You reached into your pouch and pull out a glowing, red flask. You take a long drink.");
                    Console.WriteLine("You gain " + _potionValue + " health");
                }
                else if (RunGame.currentPlayer.health < maxHealth)
                {
                    RunGame.currentPlayer.health += _potionValue;

                    //Continue the story
                    Console.WriteLine(
                        "You reached into your pouch and pull out a glowing, red flask. You take a long drink.");
                    Console.WriteLine("You gain " + _potionValue + " health");
                }

                //Take damage
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("As you were occupied, the " + EnemyStats.nameEnemy + " advanced and struck.");
                Console.WriteLine("You lose " + damageTaken + " health!");
                RunGame.currentPlayer.health -= damageTaken;

                //Continue
                Console.ReadLine();
            }
    }

    private void Leap()
    {
        int nonDamageTaken = 0;

            int damageTaken = (EnemyStats.powerEnemy - RunGame.currentPlayer.armorValue) + rand.Next(8, 22);

            //Make the Leap rng, so there is a chance you will get hit
            if (rand.Next(0, RunGame.currentPlayer.leap) == 0)
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
                RunGame.currentPlayer.health -= damageTaken;
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