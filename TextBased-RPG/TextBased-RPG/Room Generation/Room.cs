using System.ComponentModel;

namespace RPG.Room_Generation;

public class Room
{
    //Make an array or list of the Biomes
    public static Generation[] biomes = new Generation[6];
    public static Generation[] city = new Generation[6];
    
    private static int currentBiome;
    private static int currentCity;

    public static void Run()
    {
        GenerationBiomes();
        RunGeneration();
    }
    
    static void RunGeneration()
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
    
    #region Generate Envoirenment
    
    // Generate all the biomes
    public static void GenerationBiomes()
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
                "lit up the skies themselves, seemingly stronger than the stars."
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
                "next to the gates."
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
            false);
        biomes[2] = new Generation(2,
            new string[]
            {
               
            },
            new ConsoleColor[]
            {
               
            },
            new string[]
            {
               // Choises
            },
            new string[]
            {
               
            },
            new int[]
            {
                
            },
            false,
            true);
    }

    #endregion

    #region RunGeneration

    static void RunBiome()
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
        
        // If the current biome has an enemy run the combat
        if (biomes[currentBiome].areaEnemiesEncounter)
        {
            Console.Clear();
            Encounter.SkeletonEncounter();
            
            biomes[currentBiome].areaEnemiesEncounter = false;
        }
        
        // If the current biome is set for a static player death
            // Insert that down here
            if (biomes[currentBiome].playerDied)
            {
                // Insert logic for player death
                PlayerDeath.PlayerDiedAtGate();
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
    public bool playerDied;

    public Generation(int _biomeID, string[] _description, ConsoleColor[] _textColor, string[] _choices, 
                        string[] _results, int[] _exit, bool _areaEnemiesEncounter, bool _playerDied)
    {
        //Connect up the variables
        biomeID = _biomeID;

        description = _description;
        textColor = _textColor;
        
        choices = _choices;
        results = _results;
        
        exit = _exit;

        areaEnemiesEncounter = _areaEnemiesEncounter;
        playerDied = _playerDied;
    }
}