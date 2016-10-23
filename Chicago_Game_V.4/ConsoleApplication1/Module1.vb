Module Module1
    REM Chicago Game version 4 Patrick Ali 15/01/14

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
    Dim TextFileNum, x, loop1, loop2 As Integer
    REM The PlayerUserName variable is to record what the player types as there username and compare it to the usernames in the array
    REM The PlayerPassword variable is to record what the player types as there password and compare it to the password in the array
    REM The PlayerPassword variable is used after the username verification test
    Dim PlayerUserName, PlayerPassword As String
    

    Sub Main()

        TextFileNum = FreeFile()
        REM This tells the program what file you want to open and what you want to do with it 
        REM in this case we want it to input the information fromn the file into the arrays 
        FileOpen(TextFileNum, "H:\Dice_Players.txt", OpenMode.Input)

        REM Beginning of Arrays write loop, this will input the desired infromation into the arrays  

        For x = 0 To 9
            REM This is the players usernames 
            players(x).user = LineInput(TextFileNum)
            REM This is the players Passowrds 
            players(x).password = LineInput(TextFileNum)
            REM This is the amount of Games each player has played 
            players(x).games = LineInput(TextFileNum)
            REM This is the total amount of points each player has achieved over their carer in this game 
            players(x).balance = LineInput(TextFileNum)
            REM This is where each players average amount of points per game is input 
            REM Total Balance devided by the Total number of games played 
            players(x).average = LineInput(TextFileNum)

        Next

        REM End of Arrays write loop

        REM Call to the subroutine called UserName to begine login process 
        UserName()
    End Sub

    REM Beginning of Sub for the username 

    Sub UserName()

        REM This is where they will enter their username
        Console.WriteLine("Please enter username")
        REM This is where the Players Typed Username will be recorded  
        PlayerUserName = Console.ReadLine()

        REM start of Username Check Loop 

        For loop1 = 0 To 9

            REM Begining of Username If statement 

            REM This will check the typed username against the usernames in the arrays 
            If players(loop1).user = PlayerUserName Then
                REM If the typed username is the same as the username in the array then it will clear the screen
                Console.Clear()
                REM Then it will take the user to the password screen so they can continue the login process  
                Password()
            End If

            REM End of Username If statement 

        Next

        REM End of Username Check Loop 

        REM Beginning of failed username If statement 

        REM This will check the typed username against the usernames in the arrays and be displayed if the typed username and the 
        REM arrays username(s) do not match 
        If players(loop1).user <> PlayerUserName Then
            REM This will infomnr them that the username does not match any on record 
            Console.WriteLine("User name incorect")
            REM This tells them how to get back to the login screen 
            Console.WriteLine("Please press enter to go back")
            REM This is so the users can read the information 
            Console.ReadLine()
            REM This will clear the failed login details and the login failed details so they have a clearer screen  
            Console.Clear()
            REM This takes them back to the log in screen so they can re enter their username 
            UserName()
        End If

        REM End of the login in failure If statement 

    End Sub

    REM End of Sub for the username 

    REM Beginning of Sub for the passowrd  

    Sub Password()

        REM This is where they will enter their Password 
        Console.WriteLine("Please enter password")
        REM This is where the Players typed Password will be recorded 
        PlayerPassword = Console.ReadLine()

        REM start of Password Check Loop 

        For loop2 = 0 To 9

            REM Begining of Password If statement 

            REM This will check the typed Password against the Passwords in the arrays 

            If players(loop2).password = PlayerPassword Then
                REM If the typed Password is the same as the Password in the array then it will clear the screen
                Console.Clear()
                REM Then it will take the user to the password screen so they can continue the login process 
                Welcome()
            End If

            REM End of Password If statement  

        Next

        REM End of Password Check Loop 

        REM Beginning of failed Password If statement 

        REM This will check the typed Password against the Password in the arrays and be displayed if the typed Password and the 
        REM arrays Password(s) do not match 
        If players(loop2).password <> PlayerPassword Then
            REM This will infomnr them that the Password does not match any on record 
            Console.WriteLine("Password Incorect")
            REM This tells them how to get back to the login screen 
            Console.WriteLine("Please press enter to go back")
            REM This is so the users can read the information
            Console.ReadLine()
            REM This will clear the failed login details and the login failed details so they have a clearer screen  
            Console.Clear()
            REM Then it will take the user to the Password screen so they can re-enter their Password 
            Password()
        End If

        REM End of failed Password If statement  

    End Sub

    REM End of Sub for the username 

    REM Begining of Welcomne Sub  

    Sub Welcome()

    End Sub

    REM Begining of Welcomne Sub

End Module
