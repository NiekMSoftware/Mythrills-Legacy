namespace RPG;

public class EnemyActions
{
    /*
     * Give the Enemy the ability to do several things;
     * Heal: restore health
     * Defend: if the speed is higher, it is able to defend
     * Attack: based also on speed
     */

    //Player Reference
    private Player _player = new Player();
    
    //Global Variables
    private Random rand = new Random();
    
    //Bool to check if the AI defended
    public static bool isDefending = false;
    
    //Bool to detect if the enemy healed
    public static bool isHealing = false;

    public void RunCombat()
    {
        EnemyCombat();
    }
    public void EnemyCombat()
    {
        if (EnemyStats.speedEnemy > _player.speed)
        {
            if (EnemyStats.healthEnemy <= EnemyStats.maxHealthEnemy / rand.Next(2,6))
            {
                if (EnemyStats.potions <= 0)
                {
                    switch (rand.Next(0,2))
                    {
                        case 0:
                            Console.WriteLine("Me cant heal :(");
                            break;
                        case 1:
                            Defend();
                            break;
                    }
                }
                else
                {
                    isHealing = true;
                    Heal();
                }
            }
            else
            {
                isHealing = false;
                switch (rand.Next(0,2))
                {
                    case 0:
                        isDefending = false;
                        Attack();
                        break;
                    case 1:
                        isDefending = true;
                        Defend();
                        break;
                }
            }
        }
        else
        {
            switch (rand.Next(0,2))
            {
                case 0:
                    Attack();
                    break;
                case 1:
                    Heal();
                    break;
            }
        }
    }

    #region Enemy Combat Region

    
    private void Attack()
    {
        int dealDamage;
        int bonusDamage;

        bool hitCritical = false;
        
        //Give the AI a 25% chance to Critical Hit
        if (rand.Next(0, 4) == 0)
        {
            bonusDamage = EnemyStats.powerEnemy + rand.Next(3, 12);
        
            //Add extra damage to the Attack of the enemy
            dealDamage = EnemyStats.powerEnemy + bonusDamage;

            Console.WriteLine("A critical hit!");
            Console.WriteLine("The enemy hit you for " + dealDamage);
            RunGame.currentPlayer.health -= dealDamage;
        }
        else
        {
            dealDamage = EnemyStats.powerEnemy + rand.Next(0,4);
            Console.WriteLine("The enemy hit you for " + dealDamage);
            RunGame.currentPlayer.health -= dealDamage;
        }
    }

    private void Defend()
    {
        if (isDefending)
            EnemyInteraction.EnemyDefending();
    }

    private void Heal()
    {
        if (EnemyStats.potions <= 0)
            EnemyStats.potions = 0;

        EnemyStats.potionValue = rand.Next(30, 40);

        if (EnemyStats.potions <= 0)
        {
            switch (rand.Next(0,1))
            {
                case 0:
                    Attack();
                    break;
                case 1:
                    Defend();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Hehe too bad, me Heal now");
            EnemyStats.healthEnemy += EnemyStats.potionValue;
            Console.WriteLine("They gained " + EnemyStats.potionValue + " health");

            if (EnemyStats.healthEnemy >= EnemyStats.maxHealthEnemy)
            {
                EnemyStats.healthEnemy = EnemyStats.maxHealthEnemy;
            }
            EnemyStats.potions--;
        }
    }
    
    
    #endregion
}