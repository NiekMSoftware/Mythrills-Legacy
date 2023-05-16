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
                        EnemyAttacks();
                        break;
                    case 1:
                        EnemyCantHeal();
                        break;
                    default:
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
                        isHealing = true;
                        EnemyHeals();
                        break;
                    case 1:
                        isHealing = false;
                        EnemyAttacks();
                        break;
                    default:
                        isHealing = true;
                        EnemyHeals();
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
    
    private void EnemyAttacks()
    {
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
    
    private void EnemyHeals()
    {
        //Run the healing logic
        _enemyText.EnemyHeals();
    }

    private void EnemyCantHeal()
    {
        
    }
}