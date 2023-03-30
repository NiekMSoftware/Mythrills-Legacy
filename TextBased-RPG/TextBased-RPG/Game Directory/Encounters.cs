using System.Collections;

namespace RPG;

public class Encounters
{
    private static Random rand = new Random();
    private static PlayerInput _playerInput = new PlayerInput();
    
    //Enemy stats
    public static string nameEnemy = "";
    public static int powerEnemy = 0;
    public static int healthEnemy = 0;
    public static int maxHealthEnemy;
    
    //Encounters
    public static void FirstEncounter()
    {
        Console.WriteLine("You encountered an enemy! - CONCEPT");
        Console.ReadKey();
        Combat(false, "Human Rogue", 20,60);
    }

    public static void BasicFightEncounter()
    {
        Console.Clear();
        Console.WriteLine("You turn the corner and see another enemy..");
        Console.ReadKey();
        Combat(true, "", 0,0);
    }

    //Encounter tools
    public static void RandomEncounter()
    {
        switch (rand.Next(0,1))
        {
            case 0:
                BasicFightEncounter();
                break;
        }
    }
    
    //-Make a combat system
    public static void Combat(bool _randomEnemyPower, string _nameEnemy, int _powerEnemy, int _randomHealthEnemy)
    {
        //Random enemy encounter
        if (_randomEnemyPower)
        {
            nameEnemy = GetName();
            powerEnemy = rand.Next(15,40);
            healthEnemy = rand.Next(60, 120);
            maxHealthEnemy = healthEnemy;
        }
        else
        {
            //Static enemy encounters
            nameEnemy = _nameEnemy;
            powerEnemy = _powerEnemy;
            healthEnemy = _randomHealthEnemy;
            maxHealthEnemy = _randomHealthEnemy;
        }
        
        //Make a reference to the Experience class
        GainExperience gainEXP = new GainExperience();

        //Make a loop using Health
        while (healthEnemy > 0)
        {
            Console.Clear();
            Console.WriteLine(nameEnemy);
            Console.WriteLine("Power: " + powerEnemy + " / " + "Health: " + healthEnemy + " / " + maxHealthEnemy);
            
            Console.WriteLine("==============================");
            Console.WriteLine("|                            |");
            Console.WriteLine("|   A(ttack)     D(effend)   |");
            Console.WriteLine("|    R(un)        H(eal)     |");
            Console.WriteLine("|          L(eap)            |");
            Console.WriteLine("|                            |");
            Console.WriteLine("==============================");
            Console.WriteLine(" Potions: " + RunGame.currentPlayer.potions + "  Health: " + RunGame.currentPlayer.health + " / " + RunGame.currentPlayer.maxHealth);
            Console.WriteLine(" Level: " + RunGame.currentPlayer.level + " EXP: " + RunGame.currentPlayer.exp + " / " + RunGame.currentPlayer.maxExp);

            /*
             * Player Input
             */
           _playerInput.Input();

            if (RunGame.currentPlayer.health <= 0)
            {
                //Player dies
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("As the " + nameEnemy + " stands menacingly tall and comes down to strike. " +
                                  "You have been slain by the almighty " + nameEnemy);
                Console.WriteLine("");
                Console.WriteLine("Returning to Title Screen");
                Console.ReadKey();

                /*
                 * Reset all the stats the player got
                 */
                ResetPlayer();

                //Return to main Menu
                Game titleScreen = new Game();
                titleScreen.RunTitleScreen_();
            }
        }

        //Collect gold coins
        int c = rand.Next(10,50);

        Console.Clear();
        Console.WriteLine("As you stand victorious won the battle against the " + nameEnemy + 
                          ", its body dissolves into " + c + " gold coins!");
        
        //Add the coins to our player
        RunGame.currentPlayer.coins += c;
        
        /*
         * Add EXP to our Player
         */
        int experiencePlayer = 0;
        
        if (powerEnemy <= 20)
        {
            //Randomize the exp gain
            experiencePlayer = rand.Next(5,16);
        }
        else if (powerEnemy <= 30)
        {
            //Randomize the exp gain
            experiencePlayer = rand.Next(10,26);
        }
        else if (powerEnemy <= 40)
        {
            //Randomize the exp gain
            experiencePlayer = rand.Next(27,56);
        }
        else if (powerEnemy <= 50)
        {
            //Randomize the exp gain
            experiencePlayer = rand.Next(57, 105);
        }
        
        //Insert EXP to player
        RunGame.currentPlayer.exp += experiencePlayer;
            
        //Level up the player
        gainEXP.LevelUp();
            
        //Let the player know what they received
        Console.WriteLine("You also gained " + experiencePlayer + " EXP!");
        Console.WriteLine("");
        Console.WriteLine("You have received a Level Up Crystal!");
        Console.WriteLine("Use this to level up various stats!");
        Console.ReadKey();
    }

    public static void ResetPlayer()
    {
        //Reset all the stats the player got
        RunGame.currentPlayer.name = "";

        RunGame.currentPlayer.minHealthHealing = 20;
        RunGame.currentPlayer.health = 100;
        RunGame.currentPlayer.maxHealth = 100;
        RunGame.currentPlayer.armorValue = 0;

        RunGame.currentPlayer.damage = 10;
        
        RunGame.currentPlayer.level = 1;
        RunGame.currentPlayer.exp = 0;

        RunGame.currentPlayer.evasion = 20;
        RunGame.currentPlayer.leap = 10;
        
        RunGame.currentPlayer.coins = 0;
        RunGame.currentPlayer.potions = 3;
        RunGame.currentPlayer.potionValue = 30;

        RunGame.currentPlayer.weaponValue = 15;
    }
    
    public static string GetName()
    {
        switch (rand.Next(0, 4))
        {
            case 0:
                return "Skeleton";
            break;
            case 1:
                return "Valkyrie";
            break;
            case 2:
                return "Dwarf";
            break;
            case 3:
                return "Soldier";
            break;
        }
        return "Human Rogue";
    }

    public static void EnemyFunctions()
    {
        /*
          * Give the AI an ability to Defend, Dodge, Counter or Heal
        */

        string input = Console.ReadLine();

        //Defend
        if (input.ToLower() == "a" || input.ToLower() == "A")
        {
            //Give the ability to Defend
            
            
            //Give the ability to Dodge
            
            
            //Give the ability to Counter
            
            
            //Give the ability to Heal
        }
    }
}