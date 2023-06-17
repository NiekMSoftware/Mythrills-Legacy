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

    #region Generate Envoirenment
    
    // Generate all the biomes
    public static void GenerationBiomes()
    {
        // Biome 1:
        biomes[0] = new Generation(0,
            new string[]
            {
                "You awoke as there was a traveler sitting next to you..\n",
                "<< Oh you are finally awake >> ",
                "said the Traveller \n\n",
                "The traveler asked what your name was, you replied with ", 
                $"{RunGame.currentPlayer.name}\n\n",
                "<< So ",
                $"{RunGame.currentPlayer.name}",
                ".. go ",
                "east ",
                "from here to go to the nearest Town.\n Get some food and rest up!>>\n\n\n"
            },
            new ConsoleColor[]
            {
                // Game dialogue
                ConsoleColor.Gray,
                
                // Conversation
                ConsoleColor.DarkYellow,
                
                // Game dialogue
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                
                // Name
                ConsoleColor.DarkGreen,
                
                // Game dialogue
                ConsoleColor.DarkYellow,
                
                // Name
                ConsoleColor.DarkGreen,
                
                // Game dialogue
                ConsoleColor.DarkYellow,
                
                // DIRECTION
                ConsoleColor.DarkRed,
                
                // Game dialogue
                ConsoleColor.DarkYellow
            },
            new string[]
            {
                // Choice East
                "east"
            },
            new string[]
            {
                // Display Dialogue to go to the east
                "You slowly make your way to the Town\n\n"
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
                "You look back to the ",
                "west ",
                "As you take a deep breath and continue onwards\n",
                "to the centre of the City..\n\n",
                "You hear a noise to the ",
                "north ",
                "maybe there is an enemy there or something.."
            },
            new ConsoleColor[]
            {
                ConsoleColor.Gray,
                ConsoleColor.Red,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.Gray,
                ConsoleColor.DarkRed,
                ConsoleColor.Gray
            },
            new string[]
            {
                "west",
                "north"
            },
            new string[]
            {
                "You decided to go back to ask more questions to the traveler..",
                "You look around from where the sound came from.. but nothing to see.."
            },
            new int[]
            {
                // Back to begin
                0,
                // Go north
                2,
                // Go east
                3,
                //Go South
                4
            },
            false,
            false);
        biomes[2] = new Generation(2,
            new string[]
            {
                "Blah blah blah.. go ",
                "south ",
                "to head back to the city"
            },
            new ConsoleColor[]
            {
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
                "You decided to quickly go back to the City"
            },
            new int[]
            {
                1
            },
            true,
            false);
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
    public bool cityEnemiesEncounter;

    public Generation(int _biomeID, string[] _description, ConsoleColor[] _textColor, string[] _choices, 
                        string[] _results, int[] _exit, bool _areaEnemiesEncounter, bool _cityEnemiesEncounter)
    {
        //Connect up the variables
        biomeID = _biomeID;
        
        description = _description;
        textColor = _textColor;
        
        choices = _choices;
        results = _results;
        
        exit = _exit;

        areaEnemiesEncounter = _areaEnemiesEncounter;
        cityEnemiesEncounter = _cityEnemiesEncounter;
    }
}