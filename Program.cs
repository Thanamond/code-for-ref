using System;

class Program
{
    static void Main(string[] args)
    {
        char[] board = {'1','2','3','4','5','6','7','8','9'};
        int player = 1;
        bool Win = false;
        int count = 1;

        do
        {
        PrintGameDescription(player);
        PrintBoard(board);
        int choice = UserInputChoice(player,board);
        if(Isplayer(player))
        {
            board[choice-1]='O';
            player++;
        }
        else
        {
            board[choice-1]='X';
            player++;
        }
        count++;
        Win = CheckWin(board);
        }while(!Win && count != 9);

        PrintResult(Win,player,board);
    }

    static void PrintBoard(char[] board)
    {
    Console.WriteLine("     |     |");
    Console.WriteLine("  {0}  |  {1}  |  {2}",board[0],board[1],board[2]);
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |");
    Console.WriteLine("  {0}  |  {1}  |  {2}",board[3],board[4],board[5]);
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |");
    Console.WriteLine("  {0}  |  {1}  |  {2}",board[6],board[7],board[8]);
    Console.WriteLine("     |     |");
    }

    static void PrintGameDescription(int player)
    {
        Console.Clear();
        Console.WriteLine("Player 1 is : x, Player 2 is : o");
        Console.WriteLine("----------------------------------");

        if (Isplayer(player))
        {
            Console.WriteLine("Player 2 Turn");
        }
        else
        {
            Console.WriteLine("Player 1 Turn");
        }
    }

    static bool Isplayer(int player)
    {
        return player % 2 == 0;
    }

    static int UserInputChoice(int player,char[] board)
    {
        int input;
        while(true)
        {
            Console.Write(PrintPlayDescription(player));
            input = int.Parse(Console.ReadLine());

            if (CheckInvalidInput(input,board))
            {
                Console.WriteLine("Please enter only numbers 1-9");
            }
            else
            {
                break;
            }

        }
        return input;
    }

    static string PrintPlayDescription(int player)
    {
        return Isplayer(player) ? "input O at: " : "input X at: ";
    }
    
    static bool CheckInvalidInput(int input,char[] board)
    {
        return ((input < 1) || (input > 9)
        || (board[input-1]=='X') || (board[input-1]=='O'));
    }

    static bool CheckWin(char[] board)
    {
        return WinFromHorizontal(board)
        || WinFromVertical(board)
        || WinFromCrossing(board);
    }

    static bool WinFromHorizontal(char[] board)
    {
        return ((board[0] == board[1]) && (board[1] == board[2]))
        || ((board[3] == board[4]) && (board[4] == board[5]))
        || ((board[6] == board[7]) && (board[7] == board[8]));
    }

    static bool WinFromVertical(char[] board)
    {
        return ((board[0] == board[3]) && (board[3] == board[6]))
        || ((board[1] == board[4]) && (board[4] == board[7]))
        || ((board[2] == board[5]) && (board[5] == board[8]));
    }

    static bool WinFromCrossing(char[] board)
    {
        return ((board[0] == board[4]) && (board[4] == board[8]))
        || ((board[2] == board[4]) && (board[4] == board[6]));
    }

    static void PrintResult(bool Win,int player,char[] board)
    {
        Console.Clear();
        PrintBoard(board);
        if(Win)
        {
            Console.WriteLine("Player {0} is the winner",(player % 2) + 1); 
        }
        else
        {
            Console.WriteLine("Draw");
        }
    }

}
