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

    public bool diedAtGate;
    public bool died;

    void CheckPlayerDeath() {
        if (this.diedAtGate) {
            this.PlayerDied();    
        }
        
        else if (this.died) {
            
        }
    }
    
    public PlayerDeath(Player player, Game game)
    {
        this.currentPlayer = player;
        this.game = game;
    } 
    public void PlayerDied()
    {
        string[] text = {
            // 1st string
            "Unfortunately, you are struck in the side by a spear and die.\n" +
            "Unfortunate how a legend's tale can end so abruptly\n\n",
            
            // 2nd string
            "A dimwit soldier grabbed your head from behind and slit your throat open.\n" +
            "You collapsed on the ground as you hear in your final moments that the dimwit soldier is laughing at you\n\n",
            
            // 3rd string
            "You got struck by a mighty spear from behind, piercing straight through your chest\n",
            "Upon reaching your hand to your chest you collapse and die\n\n"
        };

        string deathText = text[rand.Next(text.Length)];

        Console.WriteLine(deathText);
        
        Console.ReadKey();
        Console.Clear();

        // Reset the game
        game.Start();
    }
}