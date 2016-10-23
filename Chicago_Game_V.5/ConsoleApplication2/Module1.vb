Module Module1
    Structure player
        Dim user As String
        Dim password As String
        Dim balance As Integer
        Dim games As Integer
        Dim average As Double
    End Structure

    Dim players(10) As Player
    Dim TextFileNum, x, loop1, loop2, loop3 As Integer
    Dim PlayerUserName, PlayerPassword, PlayerUserName2 As String
    Dim Die As New Random
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
        Compare()
    End Sub

    Sub Compare()


        Console.WriteLine("Please enter username")
        PlayerUserName = Console.ReadLine()

        Console.WriteLine("Please enter password")
        PlayerPassword = Console.ReadLine()

        For loop1 = 0 To 9

            If players(loop1).user <> PlayerUserName Then

                For loop3 = 0 To 9
                    Do Until players(loop3).user = PlayerUserName2

                        Console.WriteLine("Username not recognised" & " " & "Please try again")
                        Console.ReadLine()

                        Console.WriteLine("Please Re-enter username")
                        PlayerUserName2 = Console.ReadLine()
                    Loop
                Next


            ElseIf players(loop1).user = PlayerUserName Then
                For loop2 = 0 To 9
                    If players(loop2).password <> PlayerPassword Then
                        Console.WriteLine("Password not recognised" & " " & "Please try again")
                        Console.ReadLine()
                    ElseIf players(loop2).password = PlayerPassword Then
                        Console.Clear()
                        Welcome()
                    End If
                Next
            End If
                Next

           



    End Sub

    Sub Welcome()
        Console.WriteLine("Hello" & " " & PlayerUserName & "Do you want to play a game If so type y and prese enter")
        Console.WriteLine("or type e and press enter to exit")
        Console.WriteLine("For Help type h and press enter to enter the help screen")
        Console.WriteLine("To View the leaderboard type L and press enter to view leadter board")
        Choice = Console.ReadLine()

        If Choice = "y" Then
            Game()
        ElseIf Choice = "e" Then
            Finish()
        ElseIf Choice = "h" Then
            Help()
        ElseIf Choice = "L" Then

        End If

    End Sub

    Sub Game()
        For A = 0 To 10

            Round = A + 2
            Console.WriteLine("The Current Round is Round" & " " & Round)
            Console.ReadLine()

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

    End Sub

    Sub Help()


    End Sub

    Sub ScoreBoard()

    End Sub

    Sub Finish()
        Console.WriteLine("Press enter to exit")
        Console.ReadLine()
    End Sub

End Module
