namespace RPG;

public class EnemyInteraction
{
    private static Random rand = new Random();

    public static bool failed;
    public static bool succeed;
    
    //Gather the name of the enemy
    private static string nameEnemy = EnemyStats.nameEnemy;

    public static void ChanceOfFailure()
    {
        //33% chance of the AI failing to defend
        int chanceOfFailure = rand.Next(0, 4);

        if (chanceOfFailure == 0)
            FailedEnemyDefend();
        else
            SuccessEnemyDefend();
    }
    
    // TODO: Predict the Player their Input and use that data
    public static void FailedEnemyDefend()
    {
        //Let the player deal damage
        int dealtDamagePlayer = RunGame.currentPlayer.weaponValue +
                                RunGame.currentPlayer.damage / EnemyStats.armorEnemy;
        
        string text = "";
        string[] defendFail =
        {
            //TODO: Make 6 different strings for when the enemy failed at defending
            
            //String Text Number 1
            $"The {nameEnemy} is standing in a mighty and defensive" +
            "stance, preparing itself for a massive blow!\n" +
            $"You see an open gap as you pierce your weapon with a powerful stab,\n" +
            $"you dealt {dealtDamagePlayer} damage!",
            
            //String text number 2
            "Haha he failed what a loser...",
            
            //String text number 3
        };

        //Choose a random string as a result
        text = defendFail[rand.Next(0, defendFail.Length)];
        
        Console.WriteLine(text);

        //Lower health
        EnemyStats.healthEnemy -= dealtDamagePlayer;
    }

    public static void SuccessEnemyDefend()
    {
        string text = "";
        string[] defend =
        {
            //TODO: Make 6 different strings for Defending

            "He defend...",
            "Wow.. he did defend.."
        };
            
        //Choose a random string as a result
        text = defend[rand.Next(0, defend.Length)];

        Console.WriteLine(text);
    }
}