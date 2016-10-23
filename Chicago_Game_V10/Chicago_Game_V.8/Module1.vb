Module Module1
    REM Chicago Game version 10 05/03/14 Patrick Ali 

    REM This structure is to create the Arrays for the player 
    Structure player
        REM This will hold the players username which will be stored as a string as there will be multiple letters and possible numbers 
        Dim user As String
        REM This will hold the players Password which will be stored as a string as there will be multiple letters and should contain
        REM Numbers as this will make the password strong   
        Dim password As String
        REM This will be their total score over all the games they have played 
        Dim balance As Integer
        REM This will be the total number of games they have played with that account 
        Dim games As Integer
        REM This will be their average score based on their total score (balance) divided by the number of games played (games) so as to
        REM Generate their average score per game
        Dim average As Double
    End Structure

    REM This is the players arrays set as the structure I have made
    Dim players(10) As player
    REM This is the variable to open the file (TextFileNum), the variable to loop the information into the arrays (x), 
    REM the variable to loop the username verification (loop1)
    Dim TextFileNum, x, loop1 As Integer
    REM The PlayerUserName variable is to record what the player types as there username and compare it to the usernames in the array
    REM The PlayerPassword variable is to record what the player types as there password and compare it to the password in the array
    REM The PlayerPassword variable is used after the username verification test
    Dim PlayerUserName, PlayerPassword As String
    REM The Die variable is used to create the number on the die roll and is set to random so as to generate a random number between a 
    REM Given parameter in this case 1-7 as you give one above the highest number you want so as to generate the highest number you want 
    Dim Die As New Random
    REM HumanDieRoll1 is used to generate the first die roll for the human for that round 
    REM HumanDieRoll2 is used to generate the second die roll for the human for that round 
    REM HumanDieTotal is used to generate the total score for the human for that round
    REM ComputerDie1 is used to generate the first die roll for the computer for that round 
    REM ComputerDie2 is used to generate the second die roll for the computer for that round 
    REM ComputerDieTotal is used to generate the total score for the Computer for that round
    REM "A" will be used as the name of the variable for the loop which will be used for the main game 
    REM Round will be used to tell the player what round it is in Chicago Game terms as round 1 is round 2 in Chicago Game terms
    REM HumanScore will be the combined total of all points scored by the human (player) during a game 
    Dim HumanDieRoll1, HumanDieRoll2, HumanDieTotal, ComputerDie1, ComputerDie2, ComputerDieTotal, A, Round, HumanScore As Integer
    REM ComputerScore will be the combined total of all points scored by the computer (opponent) during a game
    REM Position will be used to keep track of which array is being used during the login sequence so that it can be used to update the 
    REM player records when the player is finished with the game 
    Dim ComputerScore, Position As Integer
    REM This variable will be used to navigate the various options in the game such as if the player selects option one the if statement used
    REM will register that choice equals one so whatever command follow this selection will be carried out
    Dim Choice As Integer

    REM Beginning of main routine 


    Sub Main()

        TextFileNum = FreeFile()
        REM This line tells the program to open the selected file, in this case the one that holds the player records, where tis file is
        REM and what we want to do with the information inside, in this case we want to input the information from the file into the 
        REM 'player' array 
        FileOpen(TextFileNum, "H:\Dice_Players.txt", OpenMode.Input)

        REM Beginning of player array load in loop

        REM This is saying that for x 0 to nine loads in the following information (the reason for 0 to 9 rather than 1-10 is the program works
        REM as 0 being the first number rather than 1)
        For x = 0 To 9
            REM This is inputting the players usernames into the player array
            players(x).user = LineInput(TextFileNum)
            REM This is inputting the players passwords into the player array 
            players(x).password = LineInput(TextFileNum)
            REM This is inputting the amount of games each player has played into the player array 
            players(x).games = LineInput(TextFileNum)
            REM This is inputting the combined scores of all games played for each player into the player array 
            players(x).balance = LineInput(TextFileNum)
            REM This is inputting the average score for each player into the player array 
            players(x).average = LineInput(TextFileNum)

        Next

        REM End of player array load in loop

        REM This is a call to the WelcomeScreen subroutine so as to take them to the welcome screen 
        WelcomeScreen()

    End Sub

    REM End of main routine 

    REM Beginning of the WelcomeScreen subroutine 

    Sub WelcomeScreen()
        REM This welcomes the player to the Chicago game 
        Console.WriteLine("Welcome to the Chicago game")
        REM This will place a space between the line below and the line above so as to make the screen look clearer  
        Console.WriteLine(" ")
        REM This tells the player how to begin the login process 
        Console.WriteLine("If you would like to play type 1 and press enter to login")
        REM This will place a space between the line below and the line above so as to make the screen look clearer  
        Console.WriteLine(" ")
        REM This line offers the player a way to exit the program now and not have to login 
        Console.WriteLine("Else type 2 and press enter to exit")
        REM This will record the players decision so it can be used to take them where they want to go  
        Choice = Console.ReadLine()

        REM Beginning of WelcomeScreen If statement 

        REM This command will activate if the player chooses option 1 and will begin the login process  
        If Choice = 1 Then
            REM This will clear the screen and make it look less cluttered and thus more user friendly 
            Console.Clear()
            REM This is a call to the UserName subroutine so as to begin the login process 
            UserName()
            REM This command will activate if the player choses option 2 and will close the program 
        ElseIf Choice = 2 Then
            REM The End command forces the program to close as it is telling the program to stop and do nothing beyond this point
            End
            REM This command will activate if the player enters a numerical value greater than 2
            REM This will tell the player this is not a valid option and to try again
        ElseIf Choice > 2 Then
            REM This will clear the screen and make it look less cluttered and thus more user friendly 
            Console.Clear()
            REM This line tells the player they have entered an invalid numerical value 
            Console.WriteLine("Invalid option please try again")
            REM This will place a space between the line below and the line above so as to make the screen look clearer  
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to continue")
            REM This allows the player to read the above information 
            Console.ReadLine()
            REM This will clear the screen and make it look less cluttered and thus more user friendly 
            Console.Clear()
            REM This is a call to the WelcomeScreen subroutine so as to take them back to the welcome screen
            REM So they can try and enter a correct value
            WelcomeScreen()
            REM This command will activate if the player enters a numerical value less than 1
            REM This will tell the player this is not a valid option and to try again
        ElseIf Choice < 1 Then
            REM This will clear the screen and make it look less cluttered and thus more user friendly 
            Console.Clear()
            REM This line tells the player they have entered an invalid numerical value 
            Console.WriteLine("Invalid option please try again")
            REM This will place a space between the line below and the line above so as to make the screen look clearer  
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to continue")
            REM This allows the player to read the above information 
            Console.ReadLine()
            REM This will clear the screen and make it look less cluttered and thus more user friendly 
            Console.Clear()
            REM This is a call to the WelcomeScreen subroutine so as to take them back to the welcome screen
            REM So they can try and enter a correct value
            WelcomeScreen()
        End If

        REM End of WelcomeScreen If statement 

    End Sub

    REM End of the WelcomeScreen subroutine 

    REM Beginning of UserName subroutine 

    Sub UserName()

        REM This asks the player for their username 
        Console.WriteLine("Please enter username")
        REM This assigns the value for the PlayerUserName Variable as what the player typed in as their username 
        PlayerUserName = Console.ReadLine()

        REM Beginning of username check loop 

        REM This loop (loop1) will run 10 times each time checking the typed username against those in the player arrays 
        For loop1 = 0 To 9

            REM Beginning of username check if statement 

            REM This will check if what the player has typed in matches any username in the array 
            If players(loop1).user = PlayerUserName Then
                REM If this is successful it will note the players username position so later the corresponding file can be
                REM updated to include the new information 
                Position = loop1
                REM This will clear the screen so as to make it look less cluttered 
                Console.Clear()
                REM After having a correct username the program will call the Password subroutine 
                Password()
                End
            End If

            REM End of username check if statement 

        Next

        REM End of username check loop

        REM Beginning of username failure if statement 

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This will be activated if there is no match in the loop above, this if statement will check again if there is no match if 
        REM the statement is true it will execute its command, in this case to tell them they have typed an incorrect username and should try again  
        If players(loop1).user <> PlayerUserName Then
            REM This will inform them that there was no match to username they gave 
            Console.WriteLine("User name incorrect")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This will tell them how to start this section again 
            Console.WriteLine("Please press enter to go back")
            REM This will allow the player to read the above information 
            Console.ReadLine()
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This will call the UserName subroutine so the player can try again  
            UserName()
        End If

        REM End of username failure if statement

    End Sub

    REM End of UserName subroutine 

    REM Beginning of Password subroutine 

    Sub Password()

        REM This asks the player for their password 
        Console.WriteLine("Please enter password")
        REM This assigns the value for the PlayerPassword Variable as what the player typed in as their password 
        PlayerPassword = Console.ReadLine()


        REM This will check if what the player has typed in matches the corresponding password to the username in the array
        If players(Position).password = PlayerPassword Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM After having a correct password the program will call the Welcome subroutine
            Welcome()
            REM This will be activated if there is no match in the loop above, this if statement will check again if there is no match if 
            REM the statement is true it will execute its command, in this case to tell them they have typed an incorrect password and should try again 
        ElseIf players(Position).password <> PlayerPassword Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This will inform them that there was no match to password they gave 
            Console.WriteLine("Password Incorrect")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This will tell them how to start this section again 
            Console.WriteLine("Please press enter to go back")
            REM This will allow the player to read the above information 
            Console.ReadLine()
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This will call the Password subroutine so the player can try again   
            Password()
        End If


    End Sub

    REM End of the Password subroutine 

    REM Beginning of the welcome subroutine 

    Sub Welcome()
        REM This line welcomes the player to the game and will use the player’s username so as to create a more personal gaming experience 
        Console.WriteLine("Hello" & " " & PlayerUserName & " " & "To continue select an option from the list below by typing the")
        REM This follows on from the last line and explains how to navigate the main menu
        Console.WriteLine("corresponding number and pressing the enter key")
        REM This is used to leave a one line gap between the welcome text and option one so as to make the screen look less pressed together 
        Console.WriteLine(" ")
        REM This line allows the player to navigate to the main game as it tells them what number they need to enter to go to this 
        Console.WriteLine("1 Play Game")
        REM This is used to leave a one line gap between the option one and option two so as to make the screen look less pressed together 
        Console.WriteLine(" ")
        REM This line allows the player to navigate to the Help screen as it tells them what number they need to enter to go to this   
        Console.WriteLine("2 Help")
        REM This is used to leave a one line gap between the option one and option two so as to make the screen look less pressed together
        Console.WriteLine(" ")
        REM This line allows the player to navigate to the Scoreboard as it tells them what number they need to enter to go to this
        Console.WriteLine("3 Scoreboard")
        REM This is used to leave a one line gap between the option one and option two so as to make the screen look less pressed together
        Console.WriteLine(" ")
        REM This line allows the player to navigate to the exit as it tells them what number they need to enter to go to this
        Console.WriteLine("4 Exit")
        REM This is where the program will record what the value of choice is so this can be used in the next section which will take the player
        REM to their chosen destination  
        Choice = Console.ReadLine()

        REM Beginning of the Choice If statement 

        REM This is the section that will take the player to the main game if the correct option is selected, in this case option 1 
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceGame subroutine so as to confirm player selection 
            ChoiceGame()
            REM This is the section that will take the player to the help screen if the correct option is selected, in this case option 2 
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceHelp subroutine so as to confirm player selection 
            ChoiceHelp()
            REM This is the section that will take the player to the scoreboard if the correct option is selected, in this case option 3 
        ElseIf Choice = "3" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceScoreboard subroutine so as to confirm player selection 
            ChoiceScoreboard()
            REM This is the section that will take the player to the exit if the correct option is selected, in this case option 4 
        ElseIf Choice = "4" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceExit subroutine so as to confirm player selection 
            ChoiceExit()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice > 4 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the Welcome subroutine so they can start over  
            Welcome()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the Welcome subroutine so they can start over  
            Welcome()
        End If

        REM End of the Choice If statement 

    End Sub

    REM End of the welcome subroutine 

    REM Beginning of ChoiceGameWelcome subroutine 

    Sub ChoiceGameWelcome()

        REM This asks the player if they are sure this is what they want 
        Console.WriteLine("Are you sure you want to return to the main menu")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them of how to continue on their chosen path 
        Console.WriteLine("If so Type 1 and press enter to return to the main menu ")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them how to get back to the game
        Console.WriteLine("If not Type 2 and press enter to go back")
        REM This will tell the program the value of the choice variable 
        Choice = Console.ReadLine()

        REM Beginning of ChoiceExit if statement 

        REM This instructs the program what it needs to do in the event the player choose option 1
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the update subroutine so they can continue 
            Welcome()
            REM This instructs the program what it needs to do in the event the player choose option 2
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceGame subroutine so they can go back to the ChoiceGame verification screen 
            ChoiceGame()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This tells them how to try again 
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceGameWelcome()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This tells them how to try again 
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceGameWelcome()
        End If

        REM End of ChoiceGameWelcome if statement

    End Sub

    REM End of ChoiceGameWelcome subroutine 

    REM Beginning of ChoiceHelpWelcome subroutine 

    Sub ChoiceHelpWelcome()

        REM This asks the player if they are sure this is what they want 
        Console.WriteLine("Are you sure you want to return to the main menu")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them of how to continue on their chosen path 
        Console.WriteLine("If so Type 1 and press enter to return to the main menu ")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them how to get back to the basic help screen 
        Console.WriteLine("If not Type 2 and press enter to go back to the basic help screen")
        REM This will tell the program the value of the choice variable 
        Choice = Console.ReadLine()

        REM Beginning of ChoiceExit if statement 

        REM This instructs the program what it needs to do in the event the player choose option 1
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the update subroutine so they can continue 
            Welcome()
            REM This instructs the program what it needs to do in the event the player choose option 2
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceGame subroutine so they can go back to the ChoiceGame verification screen 
            ChoiceHelp()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceHelpWelcome()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceHelpWelcome()
        End If

        REM End of ChoiceHelpWelcome if statement


    End Sub

    REM End of the ChoiceHelpWelcome subroutine 

    REM Beginning of ChoiceScorboardWelcome subroutine 

    Sub ChoiceScorboardWelcome()

        REM This asks the player if they are sure this is what they want 
        Console.WriteLine("Are you sure you want to return to the main menu")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them of how to continue on their chosen path 
        Console.WriteLine("If so Type 1 and press enter to return to the main menu ")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them how to get back to the Scoreboard 
        Console.WriteLine("If not Type 2 and press enter to go back")
        REM This will tell the program the value of the choice variable 
        Choice = Console.ReadLine()

        REM Beginning of ChoiceExit if statement 

        REM This instructs the program what it needs to do in the event the player choose option 1
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the update subroutine so they can continue 
            Welcome()
            REM This instructs the program what it needs to do in the event the player choose option 2
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceGame subroutine so they can go back to the ChoiceGame verification screen 
            ChoiceScoreboard()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceScorboardWelcome()
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceScorboardWelcome()
        End If

        REM End of ChoiceScorboardWelcome if statement

    End Sub

    REM End of the ChoiceScorboardWelcome subroutine 

    REM Beginning of ChoiceExitWelcome subroutine 

    Sub ChoiceExitWelcome()

        REM This asks the player if they are sure this is what they want 
        Console.WriteLine("Are you sure you want to return to the main menu")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them of how to continue on their chosen path 
        Console.WriteLine("If so Type 1 and press enter to return to the main menu ")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them how to get back to the exit 
        Console.WriteLine("If not Type 2 and press enter to go back")
        REM This will tell the program the value of the choice variable 
        Choice = Console.ReadLine()

        REM Beginning of ChoiceExit if statement 

        REM This instructs the program what it needs to do in the event the player choose option 1
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the update subroutine so they can continue 
            Welcome()
            REM This instructs the program what it needs to do in the event the player choose option 2
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceGame subroutine so they can go back to the ChoiceGame verification screen 
            ChoiceExit()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceExitWelcome()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceExitWelcome()
        End If

        REM End of ChoiceExitWelcome if statement


    End Sub

    REM End of ChoiceExitWelcome subroutine 

    REM Beginning of the ChoiceGame subroutine

    Sub ChoiceGame()

        REM This asks the player if they are sure this is what they want 
        Console.WriteLine("Are you sure you want to play a game")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them of how to continue on their chosen path 
        Console.WriteLine("If so Type 1 and press enter to play a game")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them how to get back to the main menu 
        Console.WriteLine("If not Type 2 and press enter for main menu")
        REM This will tell the program the value of the choice variable 
        Choice = Console.ReadLine()

        REM Beginning of ChoiceGame if statement 

        REM This instructs the program what it needs to do in the event the player choose option 1
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the Game subroutine so they can continue 
            Game()
            REM This instructs the program what it needs to do in the event the player choose option 2
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceGameWelcome subroutine so they confirm they want to return to the main menu
            ChoiceGameWelcome()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceGame()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceGame()
        End If

        REM End of ChoiceGame if statement 

    End Sub

    REM End of the ChoiceGame subroutine 

    REM Beginning of the ChoiceHelp subroutine 

    Sub ChoiceHelp()

        REM This asks the player if they are sure this is what they want 
        Console.WriteLine("Are you sure you want to go to the help screen ")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them of how to continue on their chosen path 
        Console.WriteLine("If so Type 1 and press enter to go to the help screen")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them how to get back to the main menu 
        Console.WriteLine("If not Type 2 and press enter for main menu")
        REM This will tell the program the value of the choice variable 
        Choice = Console.ReadLine()

        REM Beginning of ChoiceHelp if statement 

        REM This instructs the program what it needs to do in the event the player choose option 1
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the Help subroutine so they can continue 
            Help()
            REM This instructs the program what it needs to do in the event the player choose option 2
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceHelpWelcome subroutine so they confirm they want to return to the main menu
            ChoiceHelpWelcome()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceHelp()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceHelp()
        End If

        REM End of ChoiceHelp if statement 

    End Sub

    REM End of the ChoiceHelp subroutine 

    REM Beginning of the ChoiceScoreboard subroutine 

    Sub ChoiceScoreboard()


        REM This asks the player if they are sure this is what they want 
        Console.WriteLine("Are you sure you want to view the scoreboard")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them of how to continue on their chosen path 
        Console.WriteLine("If so Type 1 and press enter to view the scoreboard")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them how to get back to the main menu 
        Console.WriteLine("If not Type 2 and press enter for main menu")
        REM This will tell the program the value of the choice variable 
        Choice = Console.ReadLine()

        REM Beginning of ChoiceScoreboard if statement 

        REM This instructs the program what it needs to do in the event the player choose option 1
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ScoreBoard subroutine so they can continue 
            ScoreBoard()
            REM This instructs the program what it needs to do in the event the player choose option 2
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceScorboardWelcome subroutine so they confirm they want to return to the main menu 
            ChoiceScorboardWelcome()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceScoreboard()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceScoreboard()
        End If

        REM End of ChoiceScoreboard if statement

    End Sub

    REM End of the ChoiceScoreboard subroutine 

    REM Beginning of the ChoiceExit subroutine 

    Sub ChoiceExit()


        REM This asks the player if they are sure this is what they want 
        Console.WriteLine("Are you sure you want to exit the program")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them of how to continue on their chosen path 
        Console.WriteLine("If so Type 1 and press enter to exit the program")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This instructs them how to get back to the main menu 
        Console.WriteLine("If not Type 2 and press enter for main menu")
        REM This will tell the program the value of the choice variable 
        Choice = Console.ReadLine()

        REM Beginning of ChoiceExit if statement 

        REM This instructs the program what it needs to do in the event the player choose option 1
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the update subroutine so they can continue 
            update()
            REM This instructs the program what it needs to do in the event the player choose option 2
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This is a call to the ChoiceExitWelcome subroutine so they confirm they want to return to the main menu 
            ChoiceExitWelcome()
            REM This is in the event they do not type a valid numerical option  
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceExit()
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the ChoiceGame subroutine so they can start over  
            ChoiceExit()
        End If

        REM End of ChoiceExit if statement

    End Sub

    REM End of the ChoiceExit subroutine

    REM Beginning of the Game subroutine 

    Sub Game()

        REM Beginning of Game loop

        REM This is the loop that will let the game run each round one after another 
        REM This is controlled through the A variable which for as long as its value is between 0 and 10 the commands in it 
        REM should be carried out 


        For A = 0 To 10

            REM This will tell the player what round the game is, as the program counts from 0 and the Chicago game starts on round two 
            REM to get the round number you add two onto the value of 'A'
            Round = A + 2
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This will tell the player what the round is at the beginning of every round 
            Console.WriteLine("The Current Round is Round" & " " & Round & " " & "of 12")
            REM This allows them to read the above information 
            Console.ReadLine()

            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()

            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")

            REM This will tell the player what turn it is for example on round 2 (round 1) the text will say "Humans Turn 2"
            Console.WriteLine("Humans Turn" & " " & Round & " " & "of 12")
            REM This allows them to read the above information 
            Console.ReadLine()

            REM This will give a random numerical value between 1 and 6 (7 should be the highest value in the code as the code never generates 
            REM the highest given number) to HumanDieRoll1 so as to simulate the roll of a die 
            HumanDieRoll1 = Die.Next(1, 7)
            REM This tells the player what they rolled first 
            Console.WriteLine("Your First roll is" & " " & HumanDieRoll1)
            REM This allows them to read the above information 
            Console.ReadLine()

            REM This will give a random numerical value between 1 and 6 (7 should be the highest value in the code as the code never generates 
            REM the highest given number) to HumanDieRoll2 so as to simulate the roll of a die
            HumanDieRoll2 = Die.Next(1, 7)
            REM This tells the player what they rolled second 
            Console.WriteLine("Your Second Roll is" & " " & HumanDieRoll2)
            REM This allows them to read the above information 
            Console.ReadLine()

            REM This will assign the value to the players round total (HumanDiceTotal) by adding their first (HumanDieRoll1) 
            REM and second (HumanDieRoll2) roll together to make this number
            HumanDieTotal = HumanDieRoll1 + HumanDieRoll2

            REM This tells the player what their score is and for which round so they can see if they have won a point
            Console.WriteLine("Your Total is" & " " & HumanDieTotal & " " & " for round" & " " & A + 2)
            REM This allows them to read the above information
            Console.ReadLine()

            REM Beginning of Player point score if statement 

            REM This will tell the player if they have scored a point or not 
            REM This section will see if the HumanDiceTotal matches the round number which is how you score a point in the Chicago game  
            If HumanDieTotal = A + 2 Then
                REM If the above statement is true then the program will add one onto the HumanScore variable  
                HumanScore = HumanScore + 1
                REM This line congratulates the player on scoring a point 
                Console.WriteLine("Congratulations you have scored a point")
                REM This allows them to read the above information
                Console.ReadLine()

                REM In the event the above statement is not true then this will activate 
            Else
                REM This line consoles the player on not scoring a point
                Console.WriteLine("Sorry you have not scored a point")
                REM This allows them to read the above information
                Console.ReadLine()

            End If

            REM End of Player point score if statement 

            REM This line tells the player what their current score for the game thus far is
            Console.WriteLine("Your current score is" & " " & HumanScore)
            REM This allows them to read the above information
            Console.ReadLine()

            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()

            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")

            REM This will tell the player what round it is for their opponent at the beginning of every turn the opponent has
            Console.WriteLine("Computers Turn" & " " & Round & " " & "of 12")
            REM This allows them to read the above information
            Console.ReadLine()

            REM This will give a random numerical value between 1 and 6 (7 should be the highest value in the code as the code never generates 
            REM the highest given number) to ComputerDie1 so as to simulate the roll of a die
            ComputerDie1 = Die.Next(1, 7)
            REM This tells the player what their opponent rolled first
            Console.WriteLine("Your Opponent rolled" & " " & ComputerDie1 & " " & "for their first roll")
            REM This allows them to read the above information
            Console.ReadLine()

            REM This will give a random numerical value between 1 and 6 (7 should be the highest value in the code as the code never generates 
            REM the highest given number) to ComputerDie2 so as to simulate the roll of a die
            ComputerDie2 = Die.Next(1, 7)
            REM This tells the player what their opponent rolled second
            Console.WriteLine("Your Opponent rolled" & " " & ComputerDie2 & " " & " for their second roll")
            REM This allows them to read the above information
            Console.ReadLine()

            REM This will assign the value to the opponents round total ( ComputerDieTotal) by adding their first (ComputerDie1) 
            REM and second (ComputerDie2) roll together to make this number 
            ComputerDieTotal = ComputerDie1 + ComputerDie2

            REM This tells the player what their opponents score is and for which round so they can see if they have won a point
            Console.WriteLine("Your opponents total is" & " " & ComputerDieTotal & " " & " for round" & " " & A + 2)
            REM This allows them to read the above information
            Console.ReadLine()

            REM Beginning of Opponent point score if statement 

            REM This will tell the player if their opponent has scored a point or not 
            REM This section will see if the ComputerDieTotal matches the round number which is how you score a point in the Chicago game 
            If ComputerDieTotal = A + 2 Then
                REM If the above statement is true then the program will add one onto the ComputerScore variable
                ComputerScore = ComputerScore + 1
                REM This line congratulates the opponent on scoring a point 
                Console.WriteLine("Congratulations you have scored a point")
                REM This allows them to read the above information
                Console.ReadLine()

                REM In the event the above statement is not true then this will activate 
            Else
                REM This line consoles the opponent on not scoring a point
                Console.WriteLine("Your opponent has not scored a point")
                REM This allows them to read the above information
                Console.ReadLine()

            End If

            REM End of Opponent point score if statement

            REM This line tells the player what their opponent’s current score for the game thus far is
            Console.WriteLine("The Computers current score is" & " " & ComputerScore)
            REM This allows them to read the above information
            Console.ReadLine()

            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()

        Next

        REM End of the Game loop 

        REM Beginning of Game result if statement 

        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")

        REM This is used to tell the player and opponent the result of the game 
        REM This first section will activate if the players score is higher than their opponents 
        If HumanScore > ComputerScore Then
            REM This will tell the player what their final score is
            Console.WriteLine("Your final score is" & " " & HumanScore)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This will tell the player what their opponents final score is
            Console.WriteLine("Opponents final score is" & " " & ComputerScore)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This line congratulates the player on winning the game 
            Console.WriteLine("Congratulations you win")
            REM This allows them to read the above information
            Console.ReadLine()
            REM This second section activates if the opponents score is higher than the players 
        ElseIf ComputerScore > HumanScore Then
            REM This will tell the player what their final score is
            Console.WriteLine("Your final score is" & " " & HumanScore)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This will tell the player what their opponents final score is
            Console.WriteLine("Your opponents final score is" & " " & ComputerScore)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This line tells the player that their opponent has won and so they have lost 
            Console.WriteLine("Your opponent has won")
            REM This allows them to read the above information
            Console.ReadLine()
            REM The final section activates if both the player and the opponent have the same score 
        ElseIf HumanScore = ComputerScore Then
            REM This will tell the player what their final score is
            Console.WriteLine("Your final score is" & " " & HumanScore)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This will tell the player what their opponents final score is
            Console.WriteLine("Your opponents final score is" & " " & ComputerScore)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This line tells the player the game is a draw as the scores are equal  
            Console.WriteLine("The game is a draw")
            REM This allows them to read the above information
            Console.ReadLine()

        End If

        REM End of Game result if statement

        REM This is a call to the Game choice subroutine so they can chose what to do next
        GameChoice()

    End Sub

    REM End of the Game subroutine 

    REM Beginning of the GameChoice subroutine

    Sub GameChoice()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This section automatically activates once the game is finished
        REM This tells them how to start a new game 
        Console.WriteLine("Do you want to play again if so type 1 and press enter")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This tells them how to get back to the main menu 
        Console.WriteLine("If you want to go to the Main menu type 2 and press enter")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This tells them how to get to the exit 
        Console.WriteLine("For Exit type 3 and press enter to exit")
        REM This assigns a value to the variable choice which will be used to take the player to where they want to go
        REM Also it allows the player to read the information above 
        Choice = Console.ReadLine()

        REM Beginning of Game Choice if statement 

        REM This tells the program what to do for each option 
        REM The first section activates if the player choses option 1 
        If Choice = "1" Then
            REM This updates the number of games the player has played by adding one for every game they play 
            players(Position).games = players(Position).games + 1
            REM This works out the player’s new balance by adding on their score for each game 
            players(Position).balance = players(Position).balance + HumanScore
            REM This works out the players new average score by dividing the new balance against the new number of games played 
            players(x).average = players(x).balance / players(x).games
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This sets the players score to zero so the score does not carry over into the next game if they play again 
            HumanScore = 0
            REM This sets the opponents score to zero so the score does not carry over into the next game if they play again 
            ComputerScore = 0
            REM This calls the ChoiceGame subroutine so that the player can verify they want play again 
            ChoiceGame()
            REM The second section activates if the player choses option 2 which is to go back to the main menu 
        ElseIf Choice = "2" Then
            REM This updates the number of games the player has played by adding one for every game they play 
            players(Position).games = players(Position).games + 1
            REM This works out the player’s new balance by adding on their score for each game 
            players(Position).balance = players(Position).balance + HumanScore
            REM This works out the players new average score by dividing the new balance against the new number of games played 
            players(x).average = players(x).balance / players(x).games
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This sets the players score to zero so the score does not carry over into the next game if they play again 
            HumanScore = 0
            REM This sets the opponent’s score to zero so the score does not carry over into the next game if they play again 
            ComputerScore = 0
            REM This is a call to the ChoiceGameWelcome subroutine so they confirm they want to return to the main menu 
            ChoiceGameWelcome()
            REM The final section activates if the player choses option three which is to exit the program 
        ElseIf Choice = "3" Then
            REM This updates the number of games the player has played by adding one for every game they play 
            players(Position).games = players(Position).games + 1
            REM This works out the player’s new balance by adding on their score for each game 
            players(Position).balance = players(Position).balance + HumanScore
            REM This works out the players new average score by dividing the new balance against the new number of games played 
            players(x).average = players(x).balance / players(x).games
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This sets the players score to zero so the score does not carry over into the next game if they play again 
            HumanScore = 0
            REM This sets the opponent’s score to zero so the score does not carry over into the next game if they play again 
            ComputerScore = 0
            REM This calls the ChoiceExit subroutine so that the player can verify they want exit the program 
            ChoiceExit()
            REM This is in the event they do not type a valid numerical option 
        ElseIf Choice > 3 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the GameChoice subroutine so they can start over  
            GameChoice()
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the GameChoice subroutine so they can start over  
            GameChoice()
        End If

        REM End of Game Choice if statement 

    End Sub

    REM End of the GameChoice subroutine 

    REM Beginning of the Help subroutine

    Sub Help()

        REM This is the simple game rules 
        REM This line tells them what this is 
        Console.WriteLine("Game rules:")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This allows them to read the above information
        Console.ReadLine()
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This line explains the players 
        Console.WriteLine("2 players, player 1 is human and player 2 is the computer")
        Console.ReadLine()
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This line explains the round layout
        Console.WriteLine("There are 11 rounds starting at round 2 as two die cannot make 1")
        Console.WriteLine("the game finishes on round 12")
        REM This allows them to read the above information
        Console.ReadLine()
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This line explains the point system
        Console.WriteLine("Each round is worth 1 point which is awarded to the player")
        REM This allows them to read the above information
        Console.ReadLine()
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This line continues on the point system explanation 
        Console.WriteLine("If their total dice roll equals the round number such as")
        REM This allows them to read the above information
        Console.ReadLine()
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This line gives an example of this 
        Console.WriteLine("In round 2 (first round) if the player rolls a one on both their dies")
        REM This allows them to read the above information
        Console.ReadLine()
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This line continues on the example
        Console.WriteLine("They will get a total of 2 so they will get a point")
        REM This allows them to read the above information
        Console.ReadLine()
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This explains this is the only way to get points 
        Console.WriteLine("However if they get anything else they get no points that round")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()
        REM This line tells the player there is a more detailed explanation and how to get to it 
        Console.WriteLine("To view a more detailed explanation with an example round type 1")
        Console.WriteLine("and press enter")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This line offers them a way back to the main menu 
        Console.WriteLine("Or type 2 and press enter to go to the main menu")
        REM This assigns a value to the variable choice which will be used to take the player to where they want to go
        REM Also it allows the player to read the information above 
        Choice = Console.ReadLine

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM Beginning of Help Choice if statement 

        REM This tells the program what to do for each option 
        REM The first section activates if the player choses option 1 
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This calls the DetailedHelp subroutine so that the player can verify they want view a more detailed explanation  
            DetailedHelp()
            REM The second section activates if the player choses option 2 which is to go back to the main menu 
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This is a call to the ChoiceHelpWelcome subroutine so they confirm they want to return to the main menu 
            ChoiceHelpWelcome()
            REM This is in the event they do not type a valid numerical option 
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the Help subroutine so they can start over  
            Help()
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the Help subroutine so they can start over  
            Help()
        End If

        REM End of Help Choice if statement 

    End Sub

    REM End of the Help subroutine 

    REM Beginning of the DetailedHelp subroutine

    Sub DetailedHelp()

        REM This tells the player where they are
        Console.WriteLine("Welcome to the detailed help screen which includes an example")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This tells them how to navigate through this section 
        Console.WriteLine("To navigate through press enter after each block of text")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This explains where you can find the rounds number 
        Console.WriteLine("This will tell what the round is at the beginning of every round")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This is an example of what it would look like in the game 
        Console.WriteLine("The Current Round is Round" & " " & "2")
        REM This allows them to read the above information 
        Console.ReadLine()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This line tells them what this is 
        Console.WriteLine("Game rules:")
        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This tells the player where they can find out what turn it is for them
        Console.WriteLine("This will tell the player what turn it is")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This gives them an example of what this would look like 
        Console.WriteLine("for example on round 2 (round 1) the text will say 'Humans Turn 2'")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This is an example of what it would look like in the game  
        Console.WriteLine("Humans Turn" & " " & "2")
        REM This allows them to read the above information 
        Console.ReadLine()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This line tells them what this is 
        Console.WriteLine("Game rules:")
        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This will give a random numerical value between 1 and 6 (7 should be the highest value in the code as the code never generates 
        REM the highest given number) to HumanDieRoll1 so as to simulate the roll of a die 
        HumanDieRoll1 = Die.Next(1, 7)
        REM This will tell the player where to find out what they rolled first
        Console.WriteLine("This Will tell you what you rolled first")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This is an example of what it would look like in game 
        Console.WriteLine("Your First roll is" & " " & HumanDieRoll1)
        REM This allows them to read the above information 
        Console.ReadLine()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This line tells them what this is 
        Console.WriteLine("Game rules:")
        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This will give a random numerical value between 1 and 6 (7 should be the highest value in the code as the code never generates 
        REM the highest given number) to HumanDieRoll2 so as to simulate the roll of a die
        HumanDieRoll2 = Die.Next(1, 7)
        REM This will tell the player where to find out what they rolled first
        Console.WriteLine("This will tell you what you rolled second")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This is an example of what it would look like in game 
        Console.WriteLine("Your Second Roll is" & " " & HumanDieRoll2)
        REM This allows them to read the above information 
        Console.ReadLine()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This line tells them what this is 
        Console.WriteLine("Game rules:")
        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This will assign the value to the players round total (HumanDiceTotal) by adding their first (HumanDieRoll1) 
        REM and second (HumanDieRoll2) roll together to make this number
        HumanDieTotal = HumanDieRoll1 + HumanDieRoll2

        REM This tells the player where they can find their round score 
        Console.WriteLine("This tells you what your score is and for which round")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This tells the why it is important 
        Console.WriteLine("so you can see if they have won a point")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This is an example of what it would look like in game 
        Console.WriteLine("Your Total is" & " " & HumanDieTotal & " " & " for round" & " " & A + 2)
        REM This allows them to read the above information
        Console.ReadLine()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This line tells them what this is 
        Console.WriteLine("Game rules:")
        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This tells the player how they would know if they scored a point
        Console.WriteLine("This tells you if you have scored a point")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This explains how they would have got this in this example 
        Console.WriteLine("In this case if you rolled two ones you would get this")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        Console.WriteLine("as in this example you want to make 2 as 2 is the round number")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This is the example of what they would see in the game 
        Console.WriteLine("Congratulations you have scored a point")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This line tells them what this is 
        Console.WriteLine("Game rules:")
        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This tells the player what it would look like if they had not scored a point
        Console.WriteLine("This tells you if you have not scored a point")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This is the example of what they would see in the game
        Console.WriteLine("Sorry you have not scored a point")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This line tells them what this is 
        Console.WriteLine("Game rules:")
        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This tells the user where they can find their total game score thus far
        Console.WriteLine("This line tells the player what your current score for the game is thus far")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This is the example of what they would see in the game
        Console.WriteLine("Your current score is" & " " & HumanScore)
        REM This allows them to read the above information
        Console.ReadLine()

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()

        REM This is a call to the DetailedHelpChoice subroutine so the player can choses what they do next
        DetailedHelpChoice()

    End Sub

    REM End of DetailedHelp subroutine 

    REM Beginning of DetailedHelpChoice subroutine 

    Sub DetailedHelpChoice()

        REM This asks if the player wants to play a game and tells them how to start 
        Console.WriteLine("Do you want to play a game if so type 1 and press enter")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This asks if the player wants to return to the main menu and how they can
        Console.WriteLine("If you want to go to the Main menu type 2 and press enter")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This asks if the player wants to exit the program and how they can
        Console.WriteLine("For Exit type 3 and press enter to exit")
        REM This assigns a value to the variable choice which will be used to take the player to where they want to go
        REM Also it allows the player to read the information above
        Choice = Console.ReadLine()

        REM Beginning of Detailed Help Choice if statement 

        REM This tells the program what to do for each option 
        REM The first section activates if the player choses option 1 which is to start a game 
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This calls the ChoiceGame subroutine so that the player can verify they want to play a game  
            ChoiceGame()
            REM The second section activates if the player choses option 2 which is to go back to the main menu 
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This is a call to the ChoiceHelpWelcome subroutine so they confirm they want to return to the main menu 
            ChoiceHelpWelcome()
            REM The third section activates if the player choses option 3 which is to exit the program 
        ElseIf Choice = "3" Then
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This is a call to the ChoiceExit subroutine so they confirm they want to return to exit the program
            ChoiceExit()
            REM This is in the event they do not type a valid numerical option
        ElseIf Choice > 3 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the Help subroutine so they can start over  
            DetailedHelpChoice()
            REM This is in the event they do not type a valid numerical option
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the Help subroutine so they can start over  
            DetailedHelpChoice()
        End If

        REM End of Detailed Help Choice if statement 

    End Sub

    REM End of DetailedHelpChoice subroutine


    REM Beginning of ScoreBoard subroutine 

    Sub ScoreBoard()

        REM Beginning of ScoreBoard loop

        For x = 0 To 9

            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM This line tells them how to navigate this page
            Console.WriteLine("Press enter after each sentence to move onto the next sentence")
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This will display each player’s name in the order they are in the arrays 
            Console.WriteLine("User name:" & " " & players(x).user)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This allows them to read the above information
            Console.ReadLine()
            REM This will display the total number of games each player has played in the order they are in the arrays 
            Console.WriteLine("Number of Games played:" & " " & players(x).games)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This allows them to read the above information
            Console.ReadLine()
            REM This will display teach players total gamer score in the order they are in the arrays 
            Console.WriteLine("Total Game Score:" & " " & players(x).balance)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This allows them to read the above information
            Console.ReadLine()
            REM This displays the average score per game for each player in the order they appear in the arrays
            Console.WriteLine("Average score:" & " " & players(x).average)
            REM This puts a space in between each line so as to space them out and make the screen look less squashed together
            Console.WriteLine(" ")
            REM This allows them to read the above information
            Console.ReadLine()
        Next

        REM End of ScoreBoard loop

        REM This will clear the screen so as to make it look less cluttered 
        Console.Clear()
        REM This line tells them how to navigate this page
        Console.WriteLine("Press enter after each sentence to move onto the next sentence")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")

        REM This asks if the player wants to return to the main menu and how they can
        Console.WriteLine("If you want to go to the Main menu type 1 and press enter")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This asks if the player wants to exit the program and how they can
        Console.WriteLine("For Exit type 2 and press enter to exit")
        REM This assigns a value to the variable choice which will be used to take the player to where they want to go
        REM Also it allows the player to read the information above
        Choice = Console.ReadLine()

        REM Beginning of Scoreboard if statement 

        REM This tells the program what to do for each option 
        REM The second section activates if the player choses option 1 which is to go back to the main menu  
        If Choice = "1" Then
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This is a call to the ChoiceHelpWelcome subroutine so they confirm they want to return to the main menu 
            ChoiceScorboardWelcome()
            REM The second section activates if the player choses option 2 which is to exit the program 
        ElseIf Choice = "2" Then
            REM This will clear the screen so as to make it look less cluttered
            Console.Clear()
            REM This is a call to the ChoiceExit subroutine so they confirm they want to return to exit the program
            ChoiceExit()
            REM This is in the event they do not type a valid numerical option
        ElseIf Choice > 2 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the Scoreboard subroutine so they can start over  
            ScoreBoard()
            REM This is in the event they do not type a valid numerical option
        ElseIf Choice < 1 Then
            REM This will clear the screen so as to make it look less cluttered 
            Console.Clear()
            REM this informs them that they have not selected a valid option and should try again 
            Console.WriteLine("This is not an option please try again")
            REM This tells them how to try again 
            Console.WriteLine("Please press enter to try again")
            REM This allows them to read the above information 
            Console.ReadLine()
            REM This is a call to the Scoreboard subroutine so they can start over  
            ScoreBoard()
        End If

        REM End of Scoreboard Choice if statement 

    End Sub

    REM End of ScoreBoard subroutine

    REM Beginning of update subroutine

    Sub update()

        REM This will update the record for the person who has played the game

        REM This closes the file we have opened so that it can be updated by outputting the programs arrays into the file 
        FileClose(TextFileNum)
        TextFileNum = FreeFile()
        REM This opens the file by telling it where the file is and what mode we want it in, in this case we want to output information 
        FileOpen(TextFileNum, "H:\Dice_Players.txt", OpenMode.Output)

        REM Beginning of output loop

        For x = 0 To 9

            REM This outputs all the player names from the array into the file 
            PrintLine(TextFileNum, players(x).user)
            REM This outputs all the player passwords from the array into the file
            PrintLine(TextFileNum, players(x).password)
            REM This outputs the amount of games each player has played from the array into the file
            PrintLine(TextFileNum, players(x).games)
            REM This outputs the balance (amount of points a player has accumulated over their career for each player from the array into the file
            PrintLine(TextFileNum, players(x).balance)
            REM This outputs the average score per game for each player from the array into the file
            PrintLine(TextFileNum, players(x).average)

        Next

        REM End of output loop

        REM This closes the file we have opened so it can save the changes 
        FileClose(TextFileNum)

        REM This is a call to the Finish subroutine as this routine will happen at the very end of the program 
        Finish()

    End Sub

    REM End of update subroutine

    REM Beginning of Finish subroutine

    Sub Finish()

        REM This tells the player we are sorry to see them go, with their name so as to make it personal 
        REM It also tells them we hope to see them again 
        Console.WriteLine("We are sorry to see you leave" & " " & PlayerUserName & " " & "we hope to see you again soon")
        REM This puts a space in between each line so as to space them out and make the screen look less squashed together
        Console.WriteLine(" ")
        REM This tells the player how to end the program
        Console.WriteLine("Press enter to exit")
        REM This allows them to read the above information
        Console.ReadLine()

        REM This force the program to end so anything that may come after this will not be executed  
        End

    End Sub

    REM End of Finish subroutine

End Module