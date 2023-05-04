namespace RPG;

public class EnemyInteraction
{
    private static Random rand = new Random();

    public static bool failed;
    
    //Gather the name of the enemy
    private static string nameEnemy = EnemyStats.nameEnemy;

    public static void EnemyDefending()
    {
        int chanceOfFailure = rand.Next(0, 4);

        if (chanceOfFailure == 0)
        {
            failed = true;
            FailedEnemyDefend();
        }
        else
        {
            failed = false;
            SuccessEnemyDefend();
        }
    }
    
    // TODO: Predict the Player their Input and use that data
    private static void FailedEnemyDefend()
    {
        //33% chance of failing to defend
        int random = rand.Next(0, 4);

        //Let the player deal damage
        int dealtDamagePlayer = RunGame.currentPlayer.weaponValue +
                                RunGame.currentPlayer.damage / EnemyStats.armorEnemy;
        
        if (random == 0)
        {
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
            };

            //Choose a random string as a result
            text = defendFail[rand.Next(0, defendFail.Length)];
            
            Console.WriteLine(text);

            //Lower health
            EnemyStats.healthEnemy -= dealtDamagePlayer;
        }
    }

    private static void SuccessEnemyDefend()
    {
        string text = "";
        string[] defend =
        {
            //TODO: Make 6 different strings for Defending

            "He defend..."
        };
            
        //Choose a random string as a result
        text = defend[rand.Next(0, defend.Length)];

        Console.WriteLine(text);
    }

    public static void EnemyHealing()
    {
        //TODO: Give of different actions if the enemy would heal
    }
}