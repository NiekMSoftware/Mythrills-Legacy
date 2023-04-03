using System.Collections;

namespace RPG;

public class Encounter
{
    #region Random and References
    private static Random rand = new Random();
    private static PlayerInput _playerInput = new PlayerInput();
    private static Player _player = new Player();
    #endregion

    #region Encounters
    public static void FirstEncounter()
    {
        Console.WriteLine("You encountered an enemy! - CONCEPT");
        Console.ReadKey();
        Combat(false, "Human Rogue", 20,60, 69);
    }

    private static void BasicFightEncounter()
    {
        Console.Clear();
        Console.WriteLine("You turn the corner and see another enemy..");
        Console.ReadKey();
        Combat(true, "", 0,0,0);
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
    
    
    #endregion

    #region Combat & Misc
    
    //-Make a combat system
    public static void Combat(bool _randomEnemyPower, string _nameEnemy, int _powerEnemy, int _randomHealthEnemy, int _speedEnemy)
    {
        //Random enemy encounter
        if (_randomEnemyPower)
        {
            EnemyStats.nameEnemy = GetName();
            EnemyStats.powerEnemy = rand.Next(15,40);
            EnemyStats.speedEnemy = rand.Next(20, 40);
            
            EnemyStats.healthEnemy = rand.Next(60, 120);
            EnemyStats.maxHealthEnemy = EnemyStats.healthEnemy;
        }
        else
        {
            //Static enemy encounters
            EnemyStats.nameEnemy = _nameEnemy;
            EnemyStats.powerEnemy = _powerEnemy;
            EnemyStats.speedEnemy = _speedEnemy;
            
            //Health
            EnemyStats.healthEnemy = _randomHealthEnemy;
            EnemyStats.maxHealthEnemy = _randomHealthEnemy;
        }
        
        //Make a reference to the Experience class
        GainExperience gainEXP = new GainExperience();

        //Make a loop using Health
        while (EnemyStats.healthEnemy > 0)
        {
            Console.Clear();
            Console.WriteLine(EnemyStats.nameEnemy);
            Console.WriteLine("Power: " + EnemyStats.powerEnemy + " / " + "Health: " + EnemyStats.healthEnemy + " / " + EnemyStats.maxHealthEnemy +
                              "\nSpeed: " + EnemyStats.speedEnemy);
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║                            ║");
            Console.WriteLine("║   A(ttack)     D(effend)   ║");
            Console.WriteLine("║    R(un)        H(eal)     ║");
            Console.WriteLine("║          L(eap)            ║");
            Console.WriteLine("║                            ║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.WriteLine("Potions: " + RunGame.currentPlayer.potions + "  Health: " + RunGame.currentPlayer.health + " / " 
                              + RunGame.currentPlayer.maxHealth);
            Console.WriteLine("Level: " + RunGame.currentPlayer.level + " EXP: " + RunGame.currentPlayer.exp + " / " 
                              + RunGame.currentPlayer.maxExp);

            if (_speedEnemy > _player.speed)
            {
                //Let the enemy attack first
                Console.WriteLine("Rawr me angy");
                
                //Await what action the Player gives
                _playerInput.Input();
                
                //Clear out the Console for repeat
                Console.Clear();
            }
            else
            {
                //If the player is faster, let the player attack first!
                _playerInput.Input();
            }
            
            if (RunGame.currentPlayer.health <= 0)
            {
                //Player dies
                Console.Clear();
                Console.WriteLine("As the " + EnemyStats.nameEnemy + " stands menacingly tall and comes down to strike. " +
                                  "You have been slain by the almighty " + EnemyStats.nameEnemy);
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
        Console.WriteLine("As you stand victorious won the battle against the " + EnemyStats.nameEnemy + 
                          ", its body dissolves into " + c + " gold coins!");
        
        //Add the coins to our player
        RunGame.currentPlayer.coins += c;
        
        /*
         * Add EXP to our Player
         */
        int experiencePlayer = 0;
        
        if (EnemyStats.powerEnemy <= 20)
        {
            //Randomize the exp gain
            experiencePlayer = rand.Next(5,16);
        }
        else if (EnemyStats.powerEnemy <= 30)
        {
            //Randomize the exp gain
            experiencePlayer = rand.Next(10,26);
        }
        else if (EnemyStats.powerEnemy <= 40)
        {
            //Randomize the exp gain
            experiencePlayer = rand.Next(27,56);
        }
        else if (EnemyStats.powerEnemy <= 50)
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
    #endregion

    #region Resetting all Stats Upon Death

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
    

    #endregion

    #region Random Name for Enemy

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
    

    #endregion
}