Module Module1

    REM Chicago Game v.2
    REM version 2 adding comments on login system Patrick Ali 04/12/13
    REM Game rules:
    REM 2 players, player 1 is human and player 2 is the computer 
    REM There is 11 rounds starting at round 2 as two die cannot make 1, it finishes at round 12
    REM each round is worth 1 point which is awarded to the player if their die roll equals 
    REM the round number such as 
    REM in round 2 (first round) the player rolls one on both their dies they will get a total 
    REM of 2 so they will get a point
    REM However if they get anything else they get no points that round 

    REM variables required so far:
    REM Round (this is to keep count of the rounds and end the loop when they 
    REM have reached the 12th round (11th round))
    REM Die number as new random (this will give the players a random number between 1 
    REM and 6 so its parameters are 1, 7)
    REM Human die 1 as integer (this will be player ones first throw on each round, 
    REM this will be a random number)
    REM Human die 2 as integer (this will be player ones second throw on each round, 
    REM this will also be a random number)
    REM Human dice total as integer (this will add both human die one and human die 2 to give the 
    REM total that will be compared to the rounds number)
    REM Player 1 score as integer (this will be player ones total score after each round and 
    REM will be used to determine the winner)
    REM Computer die 1 as integer (this will be player twos first throw on each round, 
    REM this will be a random number)
    REM Computer die 2 as integer (this will be player twos second throw on each round, 
    REM this will also be a random number) 
    REM Computer dice total as integer (this will add both computer die one and computer die 2 
    REM to give the total that will be compared to the rounds number) 
    REM Player 2 score as integer (this will be player ones total score after each round and 
    REM will be used to determine the winner)

    Sub Main()

        REM Welcome area 
        REM This is where you will welcome the players to the game and tell them the rules of the 
        REM Chicago(game)
        REM Once the players have read the rules they will be prompted to press enter to start the game

        REM Main game section 

        REM *********Start of For loop*********

        REM The For loop will be a repetition of this section for the 11 rounds, 
        REM this line will also tell the computer what round is 
        REM as the computer will be counting the number of times this section has been repeated 
        REM so this number will be what round
        REM it is, i.e. after 2 rounds it will be round 4 because we start at round 2

        REM Declare Win as equal to the round 

        REM Player one section

        REM First tell the player what round it is and what number they need to win the round
        REM Roll of the first human die
        REM Roll of the second human die 
        REM Add both human die 1 and human die 2 to get player ones total for the round
        REM Tell the player what their dice rolls where this round (what human die 1 and 
        REM human die 2 were) 
        REM Compare Human dice total with the round number 

        REM If statement begins  
        REM If human dice roll is equal to the round number then player ones score has one added on 
        REM If statement ends

        REM Tell the player one their total score for the game so far

        REM Player two section

        REM First tell the player what round it is and what number they need to win the round
        REM Roll of the first computer die
        REM Roll of the second computer die 
        REM Add both computer die 1 and computer die 2 to get player twos total for the round
        REM Tell the player what their dice rolls where this round (what computer die 1 and 
        REM computer die 2 were) 
        REM Compare computer dice total with the round number 

        REM If statement begins  
        REM If computer dice roll is equal to the round number then player twos score has one added on 
        REM If statement ends

        REM Tell the player two their total score for the game so far

        REM *********End of For loop*********

        REM Once all eleven rounds have been done for both players tell them who has won the game 
        REM by comparing the scores
        REM If player one score is greater than player two score then display a message saying 
        REM player one has won
        REM If player one score is lesser than player two score then display a message saying 
        REM player two has won
        REM If player one score is equal to player two score then display a message saying 
        REM the game is a draw


    End Sub

End Module
