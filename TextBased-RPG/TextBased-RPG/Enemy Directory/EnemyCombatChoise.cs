namespace RPG;

public class EnemyCombatChoise
{
    //Make a reference to the EnemyActions class
    EnemyActions eActions = new EnemyActions();

    //Make a new random
    static Random rand = new Random();

    public static void ChoiceOfEnemy()
    {
        if (EnemyActions.isDefendingSlow)
            EnemyChoice_SpeedLow();
        else if(EnemyActions.isDefending)
            EnemyChoice_SpeedHigh();
    }
    
    //TODO: Make a method for the AI when its speed is lower and determine its Action
    public static void EnemyChoice_SpeedLow()
    {
        //Run a random to see what action the AI can do
        int lowHP_random = rand.Next(0, 2);

        //Let the AI decide what to do with a random
        if (EnemyStats.healthEnemy <= (EnemyStats.healthEnemy / 2))
        {
            switch (lowHP_random)
            {
                case 0:
                    EnemyActions.RunCombat();
                    break;
                case 1:
                    EnemyActions.DefendSlowSpeed();
                    break;
            }
        }
        else
        {
            switch (rand.Next(0,2))
            {
                case 0:
                    EnemyActions.RunCombat();
                    break;
                case 1:
                    EnemyActions.DefendSlowSpeed();
                    break;
            }
        }
    }

    public static void EnemyChoice_SpeedHigh()
    {
        if (EnemyStats.healthEnemy <= EnemyStats.maxHealthEnemy / 2)
        {
            EnemyActions.Heal();
        }
        else
        {
            switch (rand.Next(0,2))
            {
                case 0:
                    EnemyActions.Attack();
                    break;
                case 1:
                    EnemyActions.DefendHighSpeed();
                    break;
            }
        }
    }
}