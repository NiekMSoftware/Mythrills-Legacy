using RPG.Room_Generation;

namespace RPG;

public class PlayerDeath
{
    static Random rand = new Random();
    
    // reference to other class
    //static Game game = new Game();
    
    public Room biome;

    private static Generation _generation;

    private Player currentPlayer;
    
    public PlayerDeath(Player player)
    {
        this.currentPlayer = player;
        this.biome = new Room(this.currentPlayer);
    }
    public static void PlayerDiedAtGate()
    {
        // Give in a story for the Player that died at the gate
        Console.WriteLine("Upon entering the gates, you are struck in the side by a spear and die.\n");
        Console.WriteLine("Unfortunate how a legend’s tale can end so abruptly.\n\n");
       
        Console.ReadKey();
        
        // // Reset all the statistics to it's default value
        // PlayerInit.currentPlayer.name = "";
        //
        // PlayerInit.currentPlayer.health = 100;
        // PlayerInit.currentPlayer.maxHealth = 100;
        // PlayerInit.currentPlayer.armorValue = 5;
        //
        // PlayerInit.currentPlayer.damage = 10;
        // PlayerInit.currentPlayer.weaponValue = 15;
        //
        // PlayerInit.currentPlayer.level = 1;
        // PlayerInit.currentPlayer.exp = 0;
        // PlayerInit.currentPlayer.minExp = 1;
        // PlayerInit.currentPlayer.maxExp = 10;
        //
        // PlayerInit.currentPlayer.evasion = 20;
        //
        // PlayerInit.currentPlayer.minHealthHealing = 20;
        // PlayerInit.currentPlayer.potions = 3;
        // PlayerInit.currentPlayer.potionValue = 30;
        //
        // PlayerInit.currentPlayer.levelCrystal = 0;
        // PlayerInit.currentPlayer.coins = 0;

        // Restart Game
        // game.RunTitleScreen_();
        
        
        
        // _generation.playerDied = false;
        // game = new Game();

    }
}