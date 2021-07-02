using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TicTacToe
{
    internal class Program
    {
        private static int playerCounter;
        private static int CurrentPlayer => playerCounter % 2 == 1 ? 1 : 2;
        private static readonly IDictionary<int, char> playerMarkers = new Dictionary<int, char>
        {
            { 1, 'X' },
            { 2, 'O' }
        };

        private static MatchStatus matchStatus;

        private static void Main(string[] args)
        {
            var boardEvaluator = new BoardEvaluator();
            var boardAdmin = new BoardAdmin();
            var boardDrawer = new BoardDrawer();

            char[] board = boardAdmin.CreateNewBoard();

            do
            {
                playerCounter++;
                Console.Clear();
                Console.WriteLine(string.Join(" and ", playerMarkers.Keys.Select(key => $"Player{key}:{playerMarkers[key]}")));
                WriteEmptyLine();

                CheckChance();

                WriteEmptyLine();

                foreach (string line in boardDrawer.DrawBoard(board))
                {
                    Console.WriteLine(line);
                }

                int selectedPosition = int.Parse(Console.ReadLine());

                if (boardEvaluator.CheckIfSelectedPositionIsFree(board, selectedPosition))
                {
                    boardAdmin.MarkSelectedPosition(board, selectedPosition, playerMarkers[CurrentPlayer]);
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", selectedPosition, board[selectedPosition]);
                    WriteEmptyLine();
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }

                matchStatus = boardEvaluator.CheckMatchStatus(board);
            } while (matchStatus == MatchStatus.IsRunning);

            Console.Clear();
            foreach (string line in boardDrawer.DrawBoard(board))
            {
                Console.WriteLine(line);
            }

            if (matchStatus == MatchStatus.IsWon)
            {
                Console.WriteLine("Player {0} has won", CurrentPlayer);
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }

        private static void WriteEmptyLine() => Console.WriteLine("\n");
        private static void CheckChance() => Console.WriteLine($"Player {CurrentPlayer} Chance");
    }
}
