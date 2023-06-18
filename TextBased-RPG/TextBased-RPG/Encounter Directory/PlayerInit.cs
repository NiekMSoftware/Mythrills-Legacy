using RPG.Room_Generation;

namespace RPG;

public class PlayerInit
{
    private bool enteredOptionsKey;
    
    //Reference to the Player Script
    public Player currentPlayer;
    
    //Make a unending loop
    //public static bool mainLoop = true;
    
    // Boolean for player Name
    public bool hasNoName;

    public PlayerInit(Player player)
    {
        currentPlayer = player;
        InitPlayer();
    }
    
    public void InitPlayer()
    {
        hasNoName = true;
        Console.Clear();

        while (hasNoName)
        {
            // Ask the player for their name
            Console.WriteLine("What is your name Traveller?");
            string name = Console.ReadLine();

            if (name == "")
            {
                Console.WriteLine("Please Traveller, tell me your name..");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"Hmm.. alright {name}! You must embark on a journey");
                Console.ReadKey();
                Console.WriteLine("It won't be easy.. but I know you can do it! Press any key...");
                Console.ReadKey();
                Console.Clear();
                currentPlayer.name = name;
                hasNoName = false;
            }

        }
    }
}