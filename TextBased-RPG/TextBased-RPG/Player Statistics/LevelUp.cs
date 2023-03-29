namespace RPG;

public class GainExperience
{
    private static Random rand = new Random();

    public void LevelUp()
    {
        int remainingExp;
        
        //Check if the EXP hit its max EXP and add more value to that
        if (RunGame.currentPlayer.exp >= RunGame.currentPlayer.maxExp)
        {
            //Add a level
            RunGame.currentPlayer.level++;

            //Calculate the amount of how much exp is left
            remainingExp = RunGame.currentPlayer.exp - RunGame.currentPlayer.maxExp;

            //Return the exp back to zero
            RunGame.currentPlayer.exp = 0;
            
            //Add the amount that remained
            RunGame.currentPlayer.exp = remainingExp + RunGame.currentPlayer.exp;

            //Increase the amount of exp by a random value
            RunGame.currentPlayer.maxExp = (RunGame.currentPlayer.minExp + rand.Next(1, 5) + RunGame.currentPlayer.maxExp);
            
            //Add a level up crystal to the player's inventory
            RunGame.currentPlayer.levelCrystal++;
        }
    }
    
    /*
     * Level up any stat we would like, this will allow us to gain
     * either more Health, Defense, Damage
     */
}