Module Module1
    REM Chicago Game version 7 Patrick Ali 05/02/14

    REM This structe is to create the Arays for the player 
    Structure player
        REM This will hold the players username which will be stored as a string as there will be multiple letters and possible numbers 
        Dim user As String
        REM This will hold the players Password which will be stored as a string as there will be multiple letters and should contain
        REM Numbers as this will make the pasword strong   
        Dim password As String
        REM This will be their total score over all the games they have played 0
        Dim balance As Integer
        REM This will eb the total number of games they ahve played wu=ith that acciunt 
        Dim games As Integer
        REM This will be their average score based on their total score (balance) devided by the number of games played (games) so as to
        REM Generate their average score per game
        Dim average As Double
    End Structure

    REM This is the players arays set as the structure I have made
    Dim players(10) As player
    REM This is the variable to open the file (TextFileNum), the variablle to loop the information into the arrays (x), 
    REM the variable to loop the username verification (loop1) and the variable to loop the Password verification (loop2)
    Dim TextFileNum, x, loop1, loop2, loop3 As Integer
    REM The PlayerUserName variable is to record what the player types as there username and compare it to the usernames in the array
    REM The PlayerPassword variable is to record what the player types as there password and compare it to the password in the array
    REM The PlayerPassword variable is used after the username verification test
    Dim PlayerUserName, PlayerPassword As String
    REM The Die variable is used to create the number on the die roll and is set to random so as to generate a random number between a 
    REM Given parameter in this case 1-7 as you give one above the highest number you want so as to generate the higheest numer you want 
    Dim Die As New Random
    REM HumanDieRoll1 is used to generate the first die roll for the human for that round 
    REM HumanDieRoll2 is used to generate the second die roll for the human for that round 
    REM HumanDieTotal is used to generate the total score for the human for that round 
    Dim HumanDieRoll1, HumanDieRoll2, HumanDiceTotal, ComputerDie1, ComputerDie2, ComputerDieTotal, A, Round, HumanScore As Integer
    Dim ComputerScore As Integer
    Dim Choice As Char

    Sub Main()

        TextFileNum = FreeFile()
        FileOpen(TextFileNum, "H:\Dice_Players.txt", OpenMode.Input)
        For x = 0 To 9
            players(x).user = LineInput(TextFileNum)

            players(x).password = LineInput(TextFileNum)

            players(x).games = LineInput(TextFileNum)

            players(x).balance = LineInput(TextFileNum)

            players(x).average = LineInput(TextFileNum)

        Next
        UserName()
    End Sub

    Sub UserName()

        Console.WriteLine("Please enter username")
        PlayerUserName = Console.ReadLine()
        For loop1 = 0 To 9
            If players(loop1).user = PlayerUserName Then
                Console.Clear()
                Password()
            End If
        Next

        If players(loop1).user <> PlayerUserName Then
            Console.WriteLine("User name incorect")
            Console.WriteLine("Please press enter to go back")
            Console.ReadLine()
            UserName()
        End If

    End Sub

    Sub Password()
        Console.WriteLine("Please enter password")
        PlayerPassword = Console.ReadLine()

        For loop2 = 0 To 9

            If players(loop2).password = PlayerPassword Then
                Console.Clear()
                Welcome()
            End If

        Next

        If players(loop2).password <> PlayerPassword Then
            Console.WriteLine("Password Incorect")
            Console.WriteLine("Please press enter to go back")
            Console.ReadLine()
            Console.Clear()
            Password()
        End If

    End Sub

    Sub Welcome()
        Console.WriteLine("Hello" & " " & PlayerUserName & " " & "Do you want to play a game If so type Y and prese enter")
        Console.WriteLine(" ")
        Console.WriteLine("Type E and press enter to exit")
        Console.WriteLine(" ")
        Console.WriteLine("For Help type H and press enter to enter the help screen")
        Console.WriteLine(" ")
        Console.WriteLine("To View the leaderboard type L and press enter to view the leader board")
        Choice = Console.ReadLine()

        If Choice = "Y" Then
            Console.Clear()
            Game()
        ElseIf Choice = "E" Then
            Console.Clear()
            Finish()
        ElseIf Choice = "H" Then
            Console.Clear()
            Help()
        ElseIf Choice = "L" Then
            Console.Clear()
            ScoreBoard()
        End If

    End Sub

    Sub Game()
        For A = 0 To 10

            Round = A + 2
            Console.WriteLine("The Current Round is Round" & " " & Round)
            Console.ReadLine()

            Console.WriteLine("Humans Turn" & " " & Round)
            HumanDieRoll1 = Die.Next(1, 7)
            Console.WriteLine("Your First roll is" & " " & HumanDieRoll1)
            Console.ReadLine()

            HumanDieRoll2 = Die.Next(1, 7)
            Console.WriteLine("Your Second Roll is" & " " & HumanDieRoll2)
            Console.ReadLine()

            HumanDiceTotal = HumanDieRoll1 + HumanDieRoll2

            Console.WriteLine("Your Total is" & " " & HumanDiceTotal & " " & " for round" & " " & A + 2)
            Console.ReadLine()

            If HumanDiceTotal = A + 2 Then
                HumanScore = HumanScore + 1
                Console.WriteLine("Congragulations You have scored a point")
                Console.ReadLine()

            Else
                Console.WriteLine("Sorry you have not scored a point")
                Console.ReadLine()

            End If

            Console.WriteLine("Your current score is" & " " & HumanScore)
            Console.ReadLine()

            Console.Clear()

            Console.WriteLine("Computers Turn" & " " & Round)
            Console.ReadLine()

            ComputerDie1 = Die.Next(1, 7)
            Console.WriteLine("Your Opponent rolled" & " " & ComputerDie1 & " " & "for their first roll")
            Console.ReadLine()

            ComputerDie2 = Die.Next(1, 7)
            Console.WriteLine("Your Opponent rolled" & " " & ComputerDie2 & " " & " for their second roll")
            Console.ReadLine()

            ComputerDieTotal = ComputerDie1 + ComputerDie2

            Console.WriteLine("Your oppents total is" & " " & ComputerDieTotal & " " & " for round" & " " & A + 2)
            Console.ReadLine()

            If ComputerDieTotal = A + 2 Then
                ComputerScore = ComputerScore + 1
                Console.WriteLine("Congragulations You have scored a point")
                Console.ReadLine()

            Else
                Console.WriteLine("Your opponent has not scored a point")
                Console.ReadLine()

            End If

            Console.WriteLine("The Computers current score is" & " " & ComputerScore)
            Console.ReadLine()

            Console.Clear()

        Next

        If HumanScore > ComputerScore Then
            Console.WriteLine("Congragulation you win")
            Console.ReadLine()
        ElseIf ComputerScore > HumanScore Then
            Console.WriteLine("Your opponent has won")
            Console.ReadLine()
        ElseIf HumanScore = ComputerScore Then
            Console.WriteLine("The game is a draw")
            Console.ReadLine()

        End If

        Console.WriteLine("Do you want to go back to the Main menu or exit")
        Console.WriteLine(" ")
        Console.WriteLine("If You want to go to the Main menu type M and press enter")
        Console.WriteLine(" ")
        Console.WriteLine("For Exit type E and press enter to exit")
        Choice = Console.ReadLine()

        If Choice = "M" Then
            Console.Clear()
            Welcome()
        ElseIf Choice = "E" Then
            Console.Clear()
            Finish()
        End If

    End Sub

    Sub Help()
        Console.WriteLine("Game rules:")
        Console.ReadLine()
        Console.WriteLine("2 players, player 1 is human and player 2 is the computer")
        Console.ReadLine()
        Console.WriteLine("There is 11 rounds starting at round 2 as two die cannot make 1, it finishes at round 12")
        Console.ReadLine()
        Console.WriteLine("Each round is worth 1 point which is awarded to the player")
        Console.ReadLine()
        Console.WriteLine("If their die roll equals the round number such as")
        Console.ReadLine()
        Console.WriteLine("In round 2 (first round) if the player rolls a one on both their dies")
        Console.ReadLine()
        Console.WriteLine("They will get a total of 2 so they will get a point")
        Console.ReadLine()
        Console.WriteLine("However if they get anything else they get no points that round")
        Console.ReadLine()

        Console.WriteLine("Type M to go back to the Main Menu or E to exit")
        Console.ReadLine()
        Console.WriteLine("Do you want to go back to the Main menu or exit")
        Console.WriteLine(" ")
        Console.WriteLine("If You want to go to the Main menu type M and press enter")
        Console.WriteLine(" ")
        Console.WriteLine("For Exit type E and press enter to exit")
        Choice = Console.ReadLine()

        If Choice = "M" Then
            Console.Clear()
            Welcome()
        ElseIf Choice = "E" Then
            Console.Clear()
            Finish()
        End If

    End Sub

    Sub ScoreBoard()
        For x = 0 To 9
            Console.WriteLine("User name" & players(x).user)
            Console.WriteLine("Number of Games played" & players(x).games)
            Console.WriteLine("Total Game Score" & players(x).balance)
            Console.WriteLine("Average score" & players(x).average)
        Next
        Console.ReadLine()

        Console.WriteLine("Do you want to go back to the Main menu or exit")
        Console.WriteLine(" ")
        Console.WriteLine("If You want to go to the Main menu type M and press enter")
        Console.WriteLine(" ")
        Console.WriteLine("For Exit type E and press enter to exit")
        Choice = Console.ReadLine()

        If Choice = "M" Then
            Console.Clear()
            Welcome()
        ElseIf Choice = "E" Then
            Console.Clear()
            Finish()
        End If
    End Sub
    Sub Finish()

        FileClose(TextFileNum)

        TextFileNum = FreeFile()
        FileOpen(TextFileNum, "H:\Dice_Players.txt", OpenMode.Output)

        For x = 0 To 9
     
            PrintLine(TextFileNum, players(x).user)

            PrintLine(TextFileNum, players(x).password)

            PrintLine(TextFileNum, players(x).games)

            PrintLine(TextFileNum, players(x).balance)

            PrintLine(TextFileNum, players(x).average)

        Next

        FileClose(TextFileNum)

        Console.WriteLine("Press enter to exit")
        Console.ReadLine()

        End

    End Sub

End Module

