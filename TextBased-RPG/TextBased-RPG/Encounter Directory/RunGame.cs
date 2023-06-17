using RPG.Room_Generation;

namespace RPG;

public class RunGame
{
    private bool enteredOptionsKey;
    
    //Reference to the Player Script
    public static Player currentPlayer = new Player();
    
    //Make a unending loop
    public static bool mainLoop = true;
    
    // Boolean for player Name
    public static bool hasNoName;

    public void StartGame()
    {
        hasNoName = false;
        Console.Clear();

        while (!hasNoName)
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
                Console.WriteLine("It won't be easy.. but I know you can do it!");
                Console.ReadKey();
                Console.Clear();
                hasNoName = true;
            }

        }
       
        while (mainLoop)
            Room.Run();
        
        // Clear out the console
        Console.ReadKey();
        Console.Clear();
    }
}