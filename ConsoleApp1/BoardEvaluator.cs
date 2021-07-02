using System.Linq;

namespace TicTacToe
{
    public class BoardEvaluator
    {
        public MatchStatus CheckMatchStatus(char[] board)
        {

            if (CheckIfRowIsWon(board, 1, 2, 3)
                || CheckIfRowIsWon(board, 4, 5, 6)
                || CheckIfRowIsWon(board, 7, 8, 9)
                || CheckIfRowIsWon(board, 1, 4, 7)
                || CheckIfRowIsWon(board, 2, 5, 8)
                || CheckIfRowIsWon(board, 3, 6, 9)
                || CheckIfRowIsWon(board, 1, 5, 9)
                || CheckIfRowIsWon(board, 3, 5, 7))
            {
                return MatchStatus.IsWon;
            }

            return board.Any(val => CheckIfPositionIsFree(val))
                ? MatchStatus.IsRunning
                : MatchStatus.HasDraw;
        }

        public bool CheckIfSelectedPositionIsFree(char[] board, int selectedPosition) => CheckIfPositionIsFree(board[selectedPosition]);

        private bool CheckIfPositionIsFree(char value) => value < 58 && value > 48;

        private static bool CheckIfRowIsWon(char[] arr, int position1, int position2, int position3) =>
            arr[position1] == arr[position2]
            && arr[position2] == arr[position3];
    }
}
