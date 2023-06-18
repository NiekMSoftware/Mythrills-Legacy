namespace RPG;

public class GainExperience
{
    private static Random rand = new Random();
    private Player currentPlayer;

    public GainExperience(Player player)
    {
        this.currentPlayer = player;
    }

    public void LevelUp()
    {
        int remainingExp;
        
        //Check if the EXP hit its max EXP and add more value to that
        if( this.currentPlayer.exp >= this.currentPlayer.maxExp)
        {
            //Add a level
            this.currentPlayer.level++;

            //Calculate the amount of how much exp is left
            remainingExp = this.currentPlayer.exp - this.currentPlayer.maxExp;

            //Return the exp back to zero
            this.currentPlayer.exp = 0;
            
            //Add the amount that remained
            this.currentPlayer.exp = remainingExp + this.currentPlayer.exp;

            //Increase the amount of exp by a random value
            this.currentPlayer.maxExp = (this.currentPlayer.minExp + rand.Next(1, 5) + this.currentPlayer.maxExp);
            
            //Add a level up crystal to the player's inventory
            this.currentPlayer.levelCrystal++;
        }
    }
    
    /*
     * Level up any stat we would like, this will allow us to gain
     * either more Health, Defense, Damage
     */
}