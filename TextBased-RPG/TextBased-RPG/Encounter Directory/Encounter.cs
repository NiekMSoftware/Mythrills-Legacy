using System.Collections;
using RPG.Room_Generation;

namespace RPG;

public class Encounter
{
    #region Random and References
    
    private Random rand = new Random();
    private PlayerInput _playerInput;
    private Player _player;
    private Generation generation;
    Game game;
    
    #endregion
    
    public Encounter(Player player, Game game)
    {
        this._player = player;
        this.game = game;
        
        this._playerInput = new PlayerInput(this._player);
    }
    
    #region Encounters
    public void FirstEncounter()
    {
        Console.WriteLine("You encountered an enemy! - CONCEPT");
        Console.ReadKey();
        Combat(false, "Human Rogue", 20,32, 100, 69);
    }

    public void CidricEncounter() {
        Console.WriteLine("Cidric stood before you with a mighty pose...");
        Console.ReadLine();
        
        Combat(false, "Cidric, Last of the Knights", 20, 25, 150, 10);
    }

    #region BiomeEncounters
    
    public void SkeletonEncounter()
    {
        string[] text = new[]
        {
            // String 1
            "You feel the ground shake violently, you ready your sword for combat.." +
            "\nA white hand comes out of the ground reaching to the ground to pull itself back up.." +
            "\n\nA skeleton has appeared!",
        };

        string introSkeleton = text[rand.Next(0, text.Length)];

        Console.WriteLine(introSkeleton);
        Console.ReadKey();
        
        Combat(false, "Skeleton", 0, 10, 50, 15);
    }

    #endregion
    
    //Encounter tools

    #endregion

    #region Combat & Misc
    
    //-Make a combat system
    public void Combat(bool _randomEnemyPower, string _nameEnemy, int _armorValue, int _powerEnemy, int _HealthEnemy, int _speedEnemy)
    {
        //Random enemy encounter
        if (_randomEnemyPower)
        {
            EnemyStats.nameEnemy = GetName();
            EnemyStats.armorEnemy = rand.Next(5, 25);
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
            EnemyStats.healthEnemy = _HealthEnemy;
            EnemyStats.maxHealthEnemy = _HealthEnemy;
            
            //Armour
            EnemyStats.armorEnemy = _armorValue;
        }
        
        //Make a reference to the Experience class
        GainExperience gainEXP = new GainExperience(this._player);

        //Make a loop using Health
        while (EnemyStats.healthEnemy > 0)
        {
            Console.Clear();
            Console.WriteLine(EnemyStats.nameEnemy);
            Console.WriteLine("Level: " + EnemyStats.powerEnemy + " | " + "Speed: " + EnemyStats.speedEnemy
                              + "\nArmour: " + EnemyStats.armorEnemy + " | " + "Health: " +
                              EnemyStats.healthEnemy + " / " + EnemyStats.maxHealthEnemy +
                              "\nPotions: " + EnemyStats.potions);
            Console.WriteLine($"|=============================|");
            Console.WriteLine($"|   A(ttack)     D(efend)     |");
            Console.WriteLine($"|    H(eal)       L(eap)      |");
            Console.WriteLine($"|=============================|");
            Console.WriteLine("");
            Console.WriteLine($"You:                         ");
            Console.WriteLine($"Potions: "+ this._player.potions + " Health: "
                              + this._player.health + " / " + this._player.maxHealth);
            Console.WriteLine($"Level: " + this._player.level + " | EXP: " + this._player.exp + " / "
                              + this._player.maxExp);

            if (_speedEnemy > _player.speed)
            {
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
            
            if (this._player.health <= 0)
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
                //Game titleScreen = new Game();
                //titleScreen.RunTitleScreen_();
            }
        }

        //Collect gold coins
        int c = rand.Next(10,50);

        Console.Clear();
        Console.WriteLine("As you stand victorious won the battle against the " + EnemyStats.nameEnemy + 
                          ", its body dissolves into " + c + " gold coins!");
        Console.ReadLine();
        
        //Add the coins to our player
        this._player.coins += c;
        
        /*
         * Add EXP to our Player
         */
        int experiencePlayer = 0;
        
        //TODO: Putt this in a new method with a SWitch case
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
        else if (EnemyStats.powerEnemy <= 70)
        {
            experiencePlayer = rand.Next(106, 231);
        }
        
        //Insert EXP to player
        this._player.exp += experiencePlayer;
            
        //Level up the player
        gainEXP.LevelUp();
            
        //Let the player know what they received
        Console.WriteLine("You also gained " + experiencePlayer + " EXP!");
        Console.WriteLine("");
        Console.WriteLine("You have received a Level Up Crystal!");
        Console.WriteLine("Use this to level up various stats!");
        Console.ReadKey();
        Console.Clear();
    }
    #endregion

    #region Resetting all Stats Upon Death

    public void ResetPlayer()
    {
        game.Start();
    }
    

    #endregion

    #region Random Name for Enemy

    public string GetName()
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