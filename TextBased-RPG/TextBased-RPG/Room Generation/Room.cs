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
    
    public static void GenerationBiomes()
    {
        //Generate all the biomes
        
        biomes[0] = new Generation(0,
            "You awoke at a random place, no where to be heard.." +
            "\nYou hear some noises at the East..",
            new string[] { "east" },
            new string[] { "You stand there, all by yourself in the pitch black.."},
            new int[] { 1 },
            false,
            false);

        biomes[1] = new Generation(1,
            "",
            new string[] { "west", "east", "north" },
            new string[] { "" },
            new int[] { 0, 2, 3 },
            false,
            false);
        biomes[2] = new Generation(2,
            "",
            new string[] { "" },
            new string[] { "" },
            new int[] { },
            true,
            false);
    }

    public static void GenerationCity()
    {
        //Generate the city
        city[0] = new Generation(0,
            "",
            new string[] { "" },
            new string[] { "" },
            new[] { 1 },
            false,
            false);
    }

    #endregion

    #region RunGeneration

    static void RunBiome()
    {
        Console.WriteLine(biomes[currentBiome].description);

        string input = Console.ReadLine().ToLower();

        //Check how many option a room has
        if (biomes[currentBiome].choices.Length == 1)
        {
            //Check if the roomChoice is equal to the Input
            if (biomes[currentBiome].choices[0] == input)
            {
                Console.WriteLine(biomes[currentBiome].results[0]);
                currentBiome = biomes[currentBiome].exit[0];
            }
            else
                Console.WriteLine("Please enter a valid Input..");
        }
        else if (biomes[currentBiome].choices.Length == 2)
        {
            //Check if the roomChoice is equal to the Input
            if (biomes[currentBiome].choices[0] == input)
            {
                Console.WriteLine(biomes[currentBiome].results[0]);
                currentBiome = biomes[currentBiome].exit[0];
            }
            else if (biomes[currentBiome].choices[1] == input)
            {
                Console.WriteLine(biomes[currentBiome].results[1]);
                currentBiome = biomes[currentBiome].exit[1];
            }
            else
                Console.WriteLine("Please enter a valid Input..");
        }
        Console.Clear();
    }

    static void RunCity()
    {
        Console.WriteLine(city[currentCity].description);

        string input = Console.ReadLine().ToLower();

        if (city[currentCity].choices.Length == 1)
        {
            if (city[currentCity].choices[0] == input)
            {
                Console.WriteLine(city[currentCity].results[0]);
                currentCity = city[currentCity].exit[0];
            }
            else
                Console.WriteLine("Please enter a valid input..");
        }
        else if (city[currentCity].choices.Length == 2)
        {
            //Check if the choice is equal to the input
            if (biomes[currentBiome].choices[0] == input)
            {
                Console.WriteLine(city[currentCity].results[0]);
                currentCity = city[currentCity].exit[0];
            }
            else if (biomes[currentBiome].choices[1] == input)
            {
                Console.WriteLine(city[currentCity].results[1]);
                currentCity = city[currentCity].exit[1];
            }
        }
    }

    #endregion
}

public class Generation
{
    public int biomeID;

    public string description;
    public string[] choices;
    public string[] results;

    public int[] exit;
    
    public bool areaEnemiesEncounter;
    public bool cityEnemiesEncounter;

    public Generation(int _biomeID, string _description, string[] _choices, string[] _results, int[] _exit, bool _areaEnemiesEncounter, bool _cityEnemiesEncounter)
    {
        //Connect up the variables
        biomeID = _biomeID;
        
        description = _description;
        choices = _choices;
        results = _results;
        
        exit = _exit;

        areaEnemiesEncounter = _areaEnemiesEncounter;
        cityEnemiesEncounter = _cityEnemiesEncounter;

        /*
         * What to do? READ THIS
         *
         * Check when a certain ID has been reached, perhaps add a boolean that checks if there should be enemies there
         * or not;
         *
         */
        
        // //Run the Combat at a certain ID of the Area or City
        // if (_areaEnemiesEncounter)
        //     Encounter.AreaEnemyEncounter();

    }
}