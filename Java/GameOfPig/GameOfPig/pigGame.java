import javax.swing.JOptionPane;
/**
 * the creation of the game pig and all the methods 
 *
 * @author ()
 * @version (2017)
 */
public class pigGame
{
    /***************the first die in gv die class**************/
    private GVdie die1;
    /***************the second die in gv die class**************/
    private GVdie die2;
    /***************an integer for player score**************/
    private int playerScore;
    /*************** an integer for the computer score*********/
    private int computerScore;
    /************** an integer for the round score*************/
    private int roundScore;
    /**************** a final int of 100 ********************/
    private final int WINNING_SCORE = 100;
    /***********************boolean for if its the players turn*****************************/
    private boolean playerTurn;

    /*******************************************************************
     *Constructor for the pig class
     */
    public pigGame(){
        die1 = new GVdie ();
        die2 = new GVdie ();
        playerScore = 0;
        roundScore = 0;
        computerScore = 0;
        System.out.println("Hello welcome to my game of pig!");
        playerTurn = true; 
    }

    /**********************************************************************
     * a getter method that returns the round score 
     * @param int for round score
     */
    public int getRoundScore (){
        return roundScore;
    }

    /*****************************************************************
     * a getter method that returns the player score
     * @param in for player score
     */
    public int getPlayerScore (){
        return playerScore;
    }

    /****************************************************************
     * a getter method that returns the computers score
     * @param int for computer score
     */
    public int getComputerScore (){
        return computerScore;
    }

    /**************************************************************
     *  a boolean method that returns true or false if the player won or not
     *  @param true if the player won and false if they did not
     */
    public boolean playerWon (){
        if( playerScore >= WINNING_SCORE){
            return true;
        }
        else{
            return false;
        }
    }

    /***************************************************************
     * a boolean method that returns true or false if the computer won or not
     * @param true if the computer won and false if they did not
     */
    public boolean computerWon (){
        if( computerScore >= WINNING_SCORE){
            return true;
        }
        else{
            return false;
        }   
    }

    /***************************************************************
     * a method that rolls the dice
     * @param no return, updates round score and retrives value of dice
     */
    private void rollDice (){
        die1.roll();
        die2.roll();
        int temp = 0;
        System.out.println("Dice 1: " + die1.getValue());
        System.out.println("Dice 2 : " + die2.getValue());
        if (die1.getValue() ==1 || die2.getValue() ==1){

            System.out.println("RoundScore: 0" );

        }
        else{
            roundScore += die1.getValue() + die2.getValue();
            System.out.println("RoundScore: " + roundScore );
        }

        
    }

    /***************************************************************
     * a method that is when the player rolls the dice
     * @param no return, uses getvalue to perform players turn
     */
    public void playerRolls (){
        //roundScore = 0;
        if(playerTurn){
            rollDice();

            if  (die1.getValue() ==1 && die2.getValue() ==1){
                roundScore = 0;
                playerScore = 0;
                playerTurn=false;
                System.out.println("Your score: " + playerScore);
            }
            else if(die1.getValue() ==1 || die2.getValue() ==1){
                playerScore = playerScore - roundScore;
                if(playerScore < 0){
                    playerScore = 0;
                }
                playerTurn = false; 
                System.out.println("Your Score:" + playerScore);
                roundScore=0;
            }else if (playerWon()){
                JOptionPane.showMessageDialog(null, "YOU WIN!!");

            }
            else{
                playerScore += die1.getValue() + die2.getValue();

                System.out.println("Your score: " +  playerScore);
            } 

        }   
    }

    /***************************************************************
     *  a method that is when the player choses to hold the die
     *  @param. no return allow the player to hold and lets the computer take its turn
     */
    public void playerHolds (){

        roundScore = 0;
        playerTurn = false;
        System.out.println("Round score: " + playerScore);
    }

    /***************************************************************
     * a method that  takes the computers turn
     * @ param. no return completes the whole turn for the computer
     */
    public void computerTurn (){

        while((!playerTurn)){
            
            rollDice();

            if(die1.getValue() ==1 && die2.getValue()==1){
                roundScore = 0;
                computerScore = 0;
                playerTurn = true;
                System.out.println("Computer score: " + computerScore);
            }
            else if(die1.getValue() ==1 || die2.getValue()==1){

                computerScore = computerScore - roundScore;
                if(computerScore < 0){
                    computerScore = 0;
                }
                playerTurn = true;
                System.out.println("Computer score: "+  (computerScore));
                roundScore = 0; 
            }
            else if(computerWon()){
                JOptionPane.showMessageDialog(null, "YOU LOST!!");
                playerTurn = false;
            }
            else if (roundScore >= 19 ){
                computerScore += die1.getValue() + die2.getValue();
                playerTurn = true;
                System.out.println("Computer score: " + computerScore);
                roundScore= 0;
            }

            else{

                computerScore += die1.getValue() + die2.getValue();

                System.out.println("Computer score: " + computerScore);
            }
        }

    }

    
    /**************************************************************
     *  a  method that restarts the game
     *  @param resets all the vaibles back to zero
     */
    public void restart (){
        playerScore = 0;
        roundScore = 0;
        computerScore =0;
        playerTurn = true; 
    }

    /*************************************************************
     * a method that tests the pigGame. has no return
     */
    public void playerTurn (){
       while(playerTurn){
            rollDice();

            if  (die1.getValue() ==1 && die2.getValue() ==1){
                roundScore = 0;
                playerScore = 0;
                playerTurn=false;
                System.out.println("Your score: " + playerScore);
            }
            else if(die1.getValue() ==1 || die2.getValue() ==1){
                playerScore = playerScore - roundScore;
                if(playerScore < 0){
                    playerScore = 0;
                }
                playerTurn = false; 
                System.out.println("Your Score:" + playerScore);
                roundScore=0;
            }else if (playerWon()){
                JOptionPane.showMessageDialog(null, "YOU WIN!!");

            }
            else{
                playerScore += die1.getValue() + die2.getValue();

                System.out.println("Your score: " +  playerScore);
            } 

        }   
    }

    /**************************************************************
     * a method that test the full game of the the pigGame. returns the game output.
     */
    public void autoGame (){
        
         while ( playerScore != WINNING_SCORE && computerScore != WINNING_SCORE){
            if(playerTurn){
                playerTurn();
              
        }
            if(!playerTurn){
                computerTurn();
          
        }
        if (playerScore >= 100){
            JOptionPane.showMessageDialog(null, "YOU WIN!!");
        }
         if (computerScore >= 100){
            JOptionPane.showMessageDialog(null, "YOU LOSE!!");
        }
        }
        
        }
    
        
    
    

    /**************************************************************
     * a boolean method that returns true or false it it is the players turn
     * @param true or false
     */
    public boolean isPlayerTurn() {
        if (playerTurn){
            return true;
        }
        else{
            return false;
        }
    }

    /****************************************************************
     * return the requested die the values are one or two
     * @ param num
     */
    public GVdie getDie (int num){
        switch (num){
            case 1:  return die1;
            default : return die2;
        }
    }

        
}
