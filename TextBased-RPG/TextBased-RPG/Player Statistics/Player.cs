namespace RPG;

public class Player
{
    /*
     * Player Statistics
     */
    public string name;
    
    //Health
    public int minHealthHealing = 20;
    public int health = 100;
    public int maxHealth = 100;
    
    //Armor
    public int armorValue = 5;
    
    //Damage
    public int damage = 10;
    
    //Level
    public int level = 1;
    public int exp;

    public int minExp = 1;
    public int maxExp = 10;
    
    //Evade
    public int evasion = 20;
    
    //Leaping
    public int leap = 10;
    
    //Speed
    public int speed = 25;

    /*
     * Level Up Material
     */
    public int levelCrystal;
    
    /*
     * Inventory
     */
    public int coins;
    public int potions = 3;
    public int potionValue = 30;
    
    //Weapons
    public int weaponValue = 15;
}