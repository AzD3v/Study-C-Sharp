using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] boardArr =
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };

        static bool isWinner = false;
        static int currentPlayer = 1;

        static void Main(string[] args)
        {

            while(!isWinner)
            {
                DisplayBoard(boardArr);
                PlayGame();
            }
            
            Console.Read();
        }

        private static void PlayGame()
        {
            int winner = -1;
            bool chosenFieldValid = false;
            char chosenField = char.MinValue;

            Console.WriteLine(chosenField);

            while (!chosenFieldValid)
            {
                Console.Write("Player {0}: Choose your field: ", currentPlayer);
                chosenField = Console.ReadKey().KeyChar;

                foreach (char field in boardArr)
                {
                    if (chosenField == field)
                    {
                        chosenFieldValid = true;
                    } 
                }

                // chosenFieldValid = currentPlayer == 1 ? chosenField != 'X' : chosenField != 'O';

                if (!chosenFieldValid)
                {
                    Console.WriteLine("\n Incorrect input! Please select another field!");
                }
            }

            for (int i = 0; i < boardArr.GetLength(0); i++)
            {
                for (int j = 0; j < boardArr.GetLength(1); j++)
                {
                    if (boardArr[i, j] == chosenField)
                    {
                        boardArr[i, j] = currentPlayer == 1 ? 'O' : 'X';
                    }
                    
                    if (
                        boardArr[0, 0] == boardArr[0, 1] && boardArr[0, 1] == boardArr[0, 2] ||
                        boardArr[1, 0] == boardArr[1, 1] && boardArr[1, 1] == boardArr[1, 2] ||
                        boardArr[2, 0] == boardArr[2, 1] && boardArr[2, 1] == boardArr[2, 2]
                        ) 
                    {
                        winner = currentPlayer;
                    } else if (
                        boardArr[0, 0] == boardArr[1, 0] && boardArr[1, 0] == boardArr[2, 0] ||
                        boardArr[0, 1] == boardArr[1, 1] && boardArr[1, 1] == boardArr[2, 1] ||
                        boardArr[0, 2] == boardArr[1, 2] && boardArr[1, 2] == boardArr[2, 2]
                        ) 
                    {
                        winner = currentPlayer;
                    } else if (
                        boardArr[0, 0] == boardArr[1, 1] && boardArr[1, 1] == boardArr[2, 2] || 
                        boardArr[0, 2] == boardArr[1, 1] && boardArr[1, 1] == boardArr[2, 0]
                        )
                    {
                        winner = currentPlayer;
                    }
                }
            }

            if (winner == -1)
            {
                currentPlayer = currentPlayer == 1 ? 2 : 1;
                Console.Clear();
            } else
            {
                isWinner = true;
                Console.Clear();
                DisplayBoard(boardArr);
            }


            if (winner == 1 || winner == 2)
            {
                Console.WriteLine("Player {0} has won!", winner);
                Console.WriteLine("Press any key to reset the game");
                Console.ReadKey();
                Reset();
            }

            Console.WriteLine("");
        }

        private static void DisplayBoard(char[,] boardArr)
        {
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", boardArr[0, 0], boardArr[0, 1], boardArr[0, 2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", boardArr[1, 0], boardArr[1, 1], boardArr[1, 2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", boardArr[2, 0], boardArr[2, 1], boardArr[2, 2]);

            Console.WriteLine("     |     |      ");
        }

        private static void Reset()
        {
            Console.Clear();

            boardArr[0, 0] = '1';
            boardArr[0, 1] = '2';
            boardArr[0, 2] = '3';
            boardArr[1, 0] = '4';
            boardArr[1, 1] = '5';
            boardArr[1, 2] = '6';
            boardArr[2, 0] = '7';
            boardArr[2, 1] = '8';
            boardArr[2, 2] = '9';

            isWinner = false;
            currentPlayer = 1;
        }
    }
}
