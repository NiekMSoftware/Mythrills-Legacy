using System.Diagnostics;

namespace RPG.EnemyCombat;

public class Enemy_Choice
{
    //References to other classes
    private static PlayerInput _playerInput = new PlayerInput();
    private Enemy_Combat_Text _enemyText = new Enemy_Combat_Text();
    
    //Boolean
    public static bool isDefending;
    public static bool isHealing;
    public static bool cantHeal;
    
    //Random
    private static Random rand = new Random();

    //Enemy chooses with a random what to do
    public void EnemyChoice()
    {
        if (EnemyStats.healthEnemy <= EnemyStats.maxHealthEnemy / 3)
        {
            if (EnemyStats.potions <= 0)
            {
                //Give the AI still 25% chance to try to Heal
                switch (rand.Next(0,5))
                {
                    case 0:
                        cantHeal = false;
                        EnemyAttacks();
                        break;
                    case 1:
                        cantHeal = true;
                        EnemyCantHeal();
                        break;
                    default:
                        cantHeal = false;
                        EnemyAttacks();
                        break;
                }
            }
            else
            {
                //Make it a 11% chance for the enemy to attack when 
                //they should actually heal
                switch (rand.Next(0,9))
                {
                    case 0:
                        cantHeal = true;
                        isHealing = false;
                        HealingFailure();
                        break;
                    case 1:
                        isHealing = false;
                        cantHeal = false;
                        EnemyAttacks();
                        break;
                    default:
                        cantHeal = true;
                        isHealing = false;
                        HealingFailure();
                        break;
                }
            }
        }
        else
        {
            //Make it a 25% chance that the enemy will Defend
            //Else, attack!
            switch (rand.Next(0,4))
            {
                case 0:
                    //Attack
                    isDefending = false;
                    isHealing = false;
                    EnemyAttacks();
                    break;
                case 1:
                    //Defend
                    isDefending = true;
                    EnemyDefends();
                    break;
                default:
                    //Attack
                    isDefending = false;
                    isHealing = false;
                    EnemyAttacks();
                    break;
            }
        }
    }
    
    public void EnemyAttacks()
    {
        //20% chance of hitting a Critical Hit
        switch (rand.Next(0,5))
        {
            case 0:
                _enemyText.EnemyAttacks();
                break;
            case 1:
                _enemyText.EnemyAttacksCritical();
                break;
            default:
                _enemyText.EnemyAttacks();
                break;
        }
    }

    private void EnemyDefends()
    {
        //Run the Defend logic    
        _enemyText.EnemyDefends();
    }

    private void HealingFailure()
    {
        //Make it a 12% chance for the healing to fail
        switch (rand.Next(0,7))
        {
            case 0:
                EnemyHeals();
                break;
            case 1:
                EnemyCantHeal();
                break;
            default:
                EnemyCantHeal();
                break;
        }
    }
    private void EnemyHeals()
    {
        //Run the healing logic
        _enemyText.EnemyHeals();
    }

    private void EnemyCantHeal()
    {
        _enemyText.EnemyCantHeal();
    }
}