namespace RPG;

public class EnemyInteraction
{
    private static Random rand = new Random();
    public static void EnemyDefend()
    {
        //25% chance of failing to defend
        int random = rand.Next(0, 5);

        int dealtDamagePlayer = RunGame.currentPlayer.weaponValue +
                                RunGame.currentPlayer.damage / EnemyStats.armorEnemy;
        
        if (random == 0)
        {
            string text = "";
            string[] defendFail =
            {
                "He failed at defending. Me dealt damage"
            };

            //Choose a random string as a result
            text = defendFail[rand.Next(0, defendFail.Length)];

            Console.WriteLine(text);
        }
        else
        {
            string text = "";
            string[] defend =
            {
                "He defend."
            };
            
            //Choose a random string as a result
            text = defend[rand.Next(0, defend.Length)];

            Console.WriteLine(text);
        }
    }
}