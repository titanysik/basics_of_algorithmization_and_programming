using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int currentPlayer = 1;

            while (true)
            {
                Console.Clear();
                DrawBoard(board);

                Console.WriteLine($"Ход игрока {currentPlayer} (X или O)");

                int choice = GetValidInput(board);
                board[choice - 1] = currentPlayer == 1 ? 'X' : 'O';

                if (CheckWin(board))
                {
                    Console.Clear();
                    DrawBoard(board);
                    Console.WriteLine($"Игрок {currentPlayer} победил!");
                    break;
                }

                if (CheckDraw(board))
                {
                    Console.Clear();
                    DrawBoard(board);
                    Console.WriteLine("Ничья!");
                    break;
                }

                currentPlayer = currentPlayer == 1 ? 2 : 1;
            }
        }

        static void DrawBoard(char[] board)
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }

        static int GetValidInput(char[] board)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) &&
                    choice >= 1 &&
                    choice <= 9 &&
                    board[choice - 1] != 'X' &&
                    board[choice - 1] != 'O')
                {
                    return choice;
                }
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }

        static bool CheckWin(char[] board)
        {
            return (board[0] == board[1] && board[1] == board[2]) ||
                   (board[3] == board[4] && board[4] == board[5]) ||
                   (board[6] == board[7] && board[7] == board[8]) ||
                   (board[0] == board[3] && board[3] == board[6]) ||
                   (board[1] == board[4] && board[4] == board[7]) ||
                   (board[2] == board[5] && board[5] == board[8]) ||
                   (board[0] == board[4] && board[4] == board[8]) ||
                   (board[2] == board[4] && board[4] == board[6]);
        }

        static bool CheckDraw(char[] board)
        {
            foreach (char cell in board)
            {
                if (cell != 'X' && cell != 'O')
                    return false;
            }
            return true;
        }
    }
}