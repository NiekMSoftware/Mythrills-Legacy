using RPG.Room_Generation;

namespace RPG;

public class PlayerDeath
{
    static Random rand = new Random();
    
    // reference to other class
    //static Game game = new Game();
    
    public Room biome;

    Player currentPlayer;
    Game game;
    
    public PlayerDeath(Player player, Game game)
    {
        this.currentPlayer = player;
        this.game = game;
    }
    public void PlayerDiedAtGate()
    {
        // Give in a story for the Player that died at the gate
        Console.WriteLine("Upon entering the gates, you are struck in the side by a spear and die.\n");
        Console.WriteLine("Unfortunate how a legend’s tale can end so abruptly.\n\n");
       
        Console.ReadKey();
        Console.Clear();

        // Reset the game
        game.Start();
    }
}