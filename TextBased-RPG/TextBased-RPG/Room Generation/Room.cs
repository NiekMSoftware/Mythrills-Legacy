using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RPG.Room_Generation;

public class Room
{
    //Make an array or list of the Biomes
    public static Generation[] biomes = new Generation[20];

    public int currentBiome;
    private int currentCity;
    public Player currentplayer;
    public Encounter encounter;
    
    PlayerDeath _playerDeath;
    Game game;

    public Room(Player player, Game game)
    {
        this.currentplayer = player;
        this.game = game;
        
        this.encounter = new Encounter(this.currentplayer, this.game);
    }
    public void Run()
    {
        GenerationBiomes();
        RunGeneration();
    }
    
    void RunGeneration()
    {
        while (true)
        {
            RunBiome();
        }
    }

    #region Story Telling

    public static void Prologue1()
    {
        // Introduction
        Console.WriteLine("You awoke to the stars lit in the distant sky.");
        Console.WriteLine("As you did so, you remembered the words of your late father.\n");
        Console.ReadKey();
        
        Console.WriteLine("<< Don't you ever think I'm gone son. I'll always be watching you from up there.. >> ");
        Console.WriteLine("He mumbled, with a moody smile. His father's dying words..\n");
        Console.ReadKey();
        
        Console.WriteLine("As you kept looking at the twinkling dots, you couldn't help but wonder" +
                          " if they would ever be in your reach.");
        Console.WriteLine("If you could reach the stars, maybe then you could find your father..\n");
        Console.ReadKey();

        Console.WriteLine("And tell him..\n\n");
        
        // Clear out the Console
        Console.ReadKey();
        Console.Clear();
    }

    #endregion

    void CidricFight() {
        this.encounter.CidricEncounter();
    }
    
    #region Generate Envoirenment
    
    // Generate all the biomes
    public void GenerationBiomes()
    {
        // Story Prologue:
        Prologue1();
        
        // Biome 1:
        biomes[0] = new Generation(0,
            new string[]
            { 
                "<< the Grass Fields >> \n\n",
                "Awoken from the fields, with an epiphany in regards to what you must do,\n",
                "you set out on a journey to gain strength.\n",
                "Not remembering how you got to lie down in said fields, you scratched your head\n",
                "and decided to ask around if they found anyone.\n\n",
                "In the night, a bright city at ",
                "south ",
                "lit up the skies themselves, seemingly stronger than the stars.\n"
            },
            new ConsoleColor[]
            {
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray
            },
            new string[]
            {
                "south"
            },
            new string[]
            {
                "You decided to walk down the path to the city..\n" +
                "You also heard a noise from deep below.."
            },
            new int[]
            {
               1
            },
            false,
            false,
            false);
        
        // Biome 2:
        biomes[1] = new Generation(1,
            new string[]
            {
                "<< Carestavis, Starlit City >> \n",
                "Upon encountering the city, you noticed a lack of guards atop the city's towering walls,\n",
                "along with a gate to the ",
                "north ",
                "that appeared to have been smashed open by something terrifyingly strong.\n\n",
                "Strangely, a tent seemed to have been set down to the ",
                "west ",
                "next to the gates.\n"
            },
            new ConsoleColor[]
            {
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray
            },
            new string[]
            {
                // Choice East
                "north",
                "west"
            },
            new string[]
            {
                // Display dialogue for entering the gates
                "You decided to enter the main gate...",
                
                // Display dialogue for approaching the tent
                "Upon approaching the tent, a man yells at you loudly;"
            },
            new int[]
            {
                // go north into the gate
                2,
                
                // go to the tent
                3
            },
            true,
            false,
            false);
        
        // Biome 2, Player died
        biomes[2] = new Generation(2,
            new string[]
            {
               
            },
            new ConsoleColor[]
            {
               
            },
            new string[]
            {
                
            },
            new string[]
            {
               
            },
            new int[]
            {
                
            },
            false,
            false,
            true);
        
        biomes[3] = new Generation(3,
            new string[]
            {
               "The man appears to be some kind of cleric, but clad in black and grey cloth and armor, making him look" +
                    "rather gloomy...\n",
               "<< Who're you? Can't say I've seen a face 'rond these parts in the past decade. " +
                    "'Person's, that is. >>\n",
               "You could ",
               "ignore ",
               "the man, or you could ",
               "ask more ",
               "about the city.\n"
            },
            new ConsoleColor[]
            {
                ConsoleColor.Gray,
                ConsoleColor.DarkYellow,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray
            },
            new string[]
            {
                 "ignore",
                 "ask more"
            },
            new string[]
            {
                // Ignore the man
                "Upon ignoring the man, he clicks his tongue and leaves for the city.\n" +
                "A short while after, he seems to disappear, leaving you in the dust.\n\n" +
                "You must enter the gate once more, however, the gate is now unprotected.\n",
                
                // Result after asking more
                "Upon asking more, he tells you the city before you is the great Starlit City itself."
            },
            new int[]
            {
                // Return back to where the player is at the City
                4,
                
                // Talk to the man
                5
            },
            false,
            false,
            false);

        // Dialogue with the man
        biomes[5] = new Generation(5,
            new string[]
            {
                // Description city
               "<< A great city that catches and reflects light from the stars, where the concept of 'dark' doesn't exist.\n" +
               "A magic formation captures light from the stars and secures it for use within the city >>\n\n",
               
               // Give the player the option to ask who they are
               "Ask ",
               "who you are ",
               "to the man (include: ?) \n"
            },
            new ConsoleColor[]
            {
               ConsoleColor.DarkYellow,
               ConsoleColor.Gray,
               ConsoleColor.DarkRed,
               ConsoleColor.Gray
            },
            new string[]
            {
                "who am i?"
            },
            new string[]
            {
               "<< Damn, ‘nother one o’ those, are ya? How the hell should I know? >>\n" +
               "He looks a little annoyed."
            },
            new int[]
            {
                6
            },
            false,
            false,
            false);
        
        // Continue the dialogue with the man
        biomes[6] = new Generation(6,
            new string[]
            {
               "Upon asking what the man means, he answers:\n",
               "<< Amnisacs. Buncha dumbasses that don't remember who or what they are.\n" +
               "All trynna become stronger for some reason though. Bet you're just like that.\n" +
               "Well, good for you, 'cause Starlit's possesed by a ",
               "madman.\n",
               "Dumbass exiled all his citizins and left 'imself with a city of dimwit fighters. Can't even think\n" +
               "the poor shits. I'd almost cry for 'em. >>\n\n",
               "The man tells you to leave him alone and come back if you ever find something valuable in the city.\n",
               "You are free to ",
               "enter ",
               "the city..\n"
            },
            new ConsoleColor[]
            {
               ConsoleColor.Gray,
               ConsoleColor.DarkCyan,
               ConsoleColor.DarkYellow,
               ConsoleColor.Gray,
               ConsoleColor.Gray,
               ConsoleColor.Gray,
               ConsoleColor.DarkRed,
               ConsoleColor.Gray
            },
            new string[]
            {
                "enter"
            },
            new string[]
            {
               "You walked down into the city.."
            },
            new int[]
            {
                7
            },
            false,
            false,
            false);
        
        // OPTIMAL
            //Biome 4 || Same as the first Generation, but now the man has left:
        biomes[4] = new Generation(4,
            new string[]
            {
                "<< Carestavis, Starlit City >> \n",
                "Upon encountering the city, you noticed no guards atop the city's towering walls,\n",
                "along with a gate to the ",
                "north ",
                "that appeared to have been smashed open by something terrifyingly strong.\n\n",
                "You are now free to ",
                "enter ",
                "the gate..\n"
            },
            new ConsoleColor[]
            {
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray,
            },
            new string[]
            {
                "enter"
            },
            new string[]
            {
                "You walked down into the city.."
            },
            new int[]
            {
                7
            },
            false,
            false,
            false);
        
       
        // Entered the city
        biomes[7] = new Generation(8,
            new string[]
            {
               "In the city there's a ",
               "church,\n",
               "a manor next to the church, a ",
               "park ",
               "and a ",
               "central square.\n"
            },
            new ConsoleColor[]
            {
               ConsoleColor.Gray,
               ConsoleColor.DarkRed,
               ConsoleColor.Gray,
               ConsoleColor.DarkRed,
               ConsoleColor.Gray,
               ConsoleColor.DarkRed
            },
            new string[]
            {
                "park",
                "central square",
                "church"
            },
            new string[]
            {
               "You enter the park carefully...",
               "You entered the city square, but...",
               "You made your way to the church.."
            },
            new int[]
            {
               8,
               9,
               10
            },
            false,
            false,
            false);
        
        // Entered the park
        biomes[8] = new Generation(8,
            new string[]
            {
                "<< Carestavis, Starlit City >>\n\n",
                "Inside the park, you find a single man siting on his knees,\n" +
                "looking as though his soul was pulled from him.\n",
                "You could either ",
                "loot ",
                "the man's corpse. Or, ",
                "leave ",
                "him be.\n"
            },
            new ConsoleColor[]
            {
                ConsoleColor.DarkCyan,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray
            },
            new string[]
            {
                "loot",
                "leave"
            },
            new string[]
            {
                "Upon looting him, you acquire the << Aristocratic Note >> \n" +
                "that will allow you to recruit help for beating the Final Boss.",
                
                "You decided to leave the man alone, praying for a peaceful going for the man..."
            },
            new int[]
            {
                // Looting | Return to where you came from
                11,
                
                // Back to the previous one
                7
            },
            false,
            false,
            false);
        
        // Back to where the player came from
        biomes[11] = new Generation(11,
            new string[]
            {
                "You came back from where you came from,\n" +
                "you could either go to the ",
                "city square ",
                "or go to the ",
                "church.\n"
            },
            new ConsoleColor[]
            {
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed
            },
            new string[]
            {
               "city square",
               "church"
            },
            new string[]
            {
                "You entered the city square, but...",
                "You made your way to the church.."
            },
            new int[]
            {
               9,
               10
            },
            false,
            false,
            false);
        
        // Entered the city square
        biomes[9] = new Generation(9,
            new string[]
            {
                "<< City Square - Carestavis, Starlit City >>\n\n",
               "The city square is crawling with dimwit soldiers,\n" +
               "rather weak opponents one on one, however, with the large amount of them,\n" +
               "you got overwhelmed and lost the grip on your weapon."
            },
            new ConsoleColor[]
            {
                ConsoleColor.DarkCyan,
                ConsoleColor.Gray
            },
            new string[]
            {
               
            },
            new string[]
            {
                
            },
            new int[]
            {
               
            },
            false,
            false,
            true);
        
        // Entered the Church
        biomes[10] = new Generation(10,
            new string[]
            {
                "<< Church of Henrika - Carestavis, Starlit City >>\n\n",
               "Inside the church, you found the ",
               "Starlit Spear,\n",
               "a weapon that can only be wielded when met with the right requirements.\n\n",
               "Take ",
               "the Spear\n"
            },
            new ConsoleColor[]
            {
                ConsoleColor.DarkCyan,
                ConsoleColor.Gray,
                ConsoleColor.DarkCyan,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray
            },
            new string[]
            {
               "take"
            },
            new string[]
            {
                "Upon trying to take the weapon...\n" +
                "Cidric, Last of the Knights stopped you and charged at you!"
            },
            new int[]
            {
               12
            },
            false,
            false,
            false);
        
        // After the fight
        biomes[12] = new Generation(12,
            new string[]
            {
                "Once you have defeated Cidric, you look around the church for,\n",
                "the entrance of the Manor.\n\n",
                "To be continued..."
            },
            new ConsoleColor[]
            {
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray
            },
            new string[]
            {
              
            },
            new string[]
            {
                
            },
            new int[]
            {
               
            },
            false,
            true,
            false);
    }

    #endregion

    #region RunGeneration

    void RunBiome()
    {
        Generation activeBiome = biomes[currentBiome]; 
        
        // We change the foreground color based on the index
        for (int i = 0; i < activeBiome.description.Length ; i++)
        {
            Console.ForegroundColor = activeBiome.textColor[i];
            Console.Write(activeBiome.description[i]);
        }
        
        // We reset the color back to gray
        Console.ForegroundColor = ConsoleColor.Gray;

        string input = Console.ReadLine().ToLower();

        //Check how many option a room has
        if (biomes[currentBiome].choices.Length == 1)
        {
            //Check if the roomChoice is equal to the Input
            if (biomes[currentBiome].choices[0] == input)
            {
                Console.Clear();
                
                Console.WriteLine(biomes[currentBiome].results[0]);
                currentBiome = biomes[currentBiome].exit[0];
                
                // Clear out the console
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Please enter a valid Input..");
                Console.ReadKey();
                Console.Clear();
            }
            
        }
        else if (biomes[currentBiome].choices.Length == 2)
        {
            //Check if the roomChoice is equal to the Input
            if (biomes[currentBiome].choices[0] == input)
            {
                Console.Clear();

                Console.WriteLine(biomes[currentBiome].results[0]);
                currentBiome = biomes[currentBiome].exit[0];
                
                // Clear out the console
                Console.ReadKey();
                Console.Clear();
            }
            else if (biomes[currentBiome].choices[1] == input)
            {
                Console.Clear();
                
                Console.WriteLine(biomes[currentBiome].results[1]);
                currentBiome = biomes[currentBiome].exit[1];
                
                // Clear out the console
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Please enter a valid Input..");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (biomes[currentBiome].choices.Length == 3)
        {
            //Check if the roomChoice is equal to the Input
            if (biomes[currentBiome].choices[0] == input)
            {
                Console.Clear();

                Console.WriteLine(biomes[currentBiome].results[0]);
                currentBiome = biomes[currentBiome].exit[0];
                
                // Clear out the console
                Console.ReadKey();
                Console.Clear();
            }
            else if (biomes[currentBiome].choices[1] == input)
            {
                Console.Clear();
                
                Console.WriteLine(biomes[currentBiome].results[1]);
                currentBiome = biomes[currentBiome].exit[1];
                
                // Clear out the console
                Console.ReadKey();
                Console.Clear();
            }
            else if (biomes[currentBiome].choices[2] == input)
            {
                Console.Clear();
                
                Console.WriteLine(biomes[currentBiome].results[2]);
                currentBiome = biomes[currentBiome].exit[2];
                
                // Clear out the console
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Please enter a valid Input..");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        // If the current biome has an enemy run the combat
        if (biomes[currentBiome].areaEnemiesEncounter)
        {
            Console.Clear();
            this.encounter.SkeletonEncounter();
            
            biomes[currentBiome].areaEnemiesEncounter = false;
        }

        if (biomes[this.currentBiome].miniBossBattle) {
            Console.Clear();
            
            // Run the combat
            this.encounter.CidricEncounter();

            biomes[this.currentBiome].miniBossBattle = false;
        }
        
        // If the current biome is set for a static player death
            // Insert that down here
        if (biomes[currentBiome].playerDied) {
            // Make a new object of the Player Death
            this._playerDeath = new PlayerDeath(this.currentplayer, this.game);
            
            // Insert logic for player death
            this._playerDeath.PlayerDied();

            biomes[currentBiome].playerDied = false;
        }
    }

    #endregion
}

public class Generation
{
    public int biomeID;

    public string[] description;
    public ConsoleColor[] textColor;
    public string[] choices;
    public string[] results;

    public int[] exit;
    
    public bool areaEnemiesEncounter;
    public bool miniBossBattle;
    public bool playerDied;

    public Generation(int _biomeID, string[] _description, ConsoleColor[] _textColor, string[] _choices, 
                        string[] _results, int[] _exit, bool _areaEnemiesEncounter, bool _miniBossBattle, bool _playerDied)
    {
        //Connect up the variables
        biomeID = _biomeID;

        description = _description;
        textColor = _textColor;
        
        choices = _choices;
        results = _results;
        
        exit = _exit;

        areaEnemiesEncounter = _areaEnemiesEncounter;
        miniBossBattle = _miniBossBattle;
        
        playerDied = _playerDied;
    }
}