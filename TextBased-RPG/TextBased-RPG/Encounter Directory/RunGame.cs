namespace RPG;

public class RunGame
{
    private bool enteredOptionsKey;
    
    //Reference to the Player Script
    public static Player currentPlayer = new Player();
    
    //Make a unending loop for battles
    public static bool mainLoop = true;

    public void StartGame()
    {
        Console.Clear();
        
        //start game here
        Console.WriteLine("PLACEHOLDER NAME!");
        Console.WriteLine("Insert Player Name:");

        //Insert player name
        currentPlayer.name = Console.ReadLine();
        Console.Clear();
        
        //Check if the player has given no input for a name
        if (currentPlayer.name == "")
            Console.WriteLine("You don't even remember your own name...");
        else
            Console.WriteLine("You know certainly your name is " + currentPlayer.name);

        //continue story
        Console.ReadKey();
        Console.Clear();
        
        //First encounter
        Encounter.FirstEncounter();
        
        //Random Encounters, ENDLESS MODE
        while (mainLoop)
        {
            Encounter.RandomEncounter();
        }
    }
}