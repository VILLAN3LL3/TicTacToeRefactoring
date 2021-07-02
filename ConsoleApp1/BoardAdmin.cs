namespace TicTacToe
{
    public class BoardAdmin
    {
        public char[] CreateNewBoard()
        {
            return new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }

        public void MarkSelectedPosition(char[] board, int selectedPosition, char marker) => board[selectedPosition] = marker;
    }
}
