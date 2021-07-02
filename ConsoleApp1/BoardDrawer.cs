using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class BoardDrawer
    {
        public IEnumerable<string> DrawBoard(char[] board)
        {
            var listToReturn = new List<string>();
            for (int i = 1; i < board.Length; i += 3)
            {
                listToReturn.Add(DrawOuterBoarder());
                listToReturn.Add(DrawValueLine(board[i], board[i + 1], board[i + 2]));
                listToReturn.Add(DrawInnerBoarder());
            }
            listToReturn.Remove(listToReturn.Last());
            listToReturn.Add(DrawOuterBoarder());
            return listToReturn;
        }

        private string DrawOuterBoarder() => "     |     |      ";
        private string DrawInnerBoarder() => "_____|_____|_____ ";

        private string DrawValueLine(char value1, char value2, char value3) => $"  {value1}  |  {value2}  |  {value3}";
    }
}
