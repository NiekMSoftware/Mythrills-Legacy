using RPG.Room_Generation;

namespace RPG;

public class PlayerDeath
{
    static Random rand = new Random();
    
    // reference to other class
    static Game game = new Game();
    static Room biome = new Room();

    private static Generation _generation;
    public static void PlayerDiedAtGate()
    {
        // Give in a story for the Player that died at the gate
        Console.WriteLine("Upon entering the gates, you are struck in the side by a spear and die.\n");
        Console.WriteLine("Unfortunate how a legend’s tale can end so abruptly.\n\n");
       
        Console.ReadKey();
        
        // Reset all the statistics to it's default value
        RunGame.currentPlayer.name = "";
        
        RunGame.currentPlayer.health = 100;
        RunGame.currentPlayer.maxHealth = 100;
        RunGame.currentPlayer.armorValue = 5;

        RunGame.currentPlayer.damage = 10;
        RunGame.currentPlayer.weaponValue = 15;

        RunGame.currentPlayer.level = 1;
        RunGame.currentPlayer.exp = 0;
        RunGame.currentPlayer.minExp = 1;
        RunGame.currentPlayer.maxExp = 10;

        RunGame.currentPlayer.evasion = 20;
        
        RunGame.currentPlayer.minHealthHealing = 20;
        RunGame.currentPlayer.potions = 3;
        RunGame.currentPlayer.potionValue = 30;

        RunGame.currentPlayer.levelCrystal = 0;
        RunGame.currentPlayer.coins = 0;

        // Restart Game
        // game.RunTitleScreen_();
        
        
        
        // _generation.playerDied = false;
        // game = new Game();

    }
}