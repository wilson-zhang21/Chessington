using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var currenRow = currentSquare.Row;
            var currentCol = currentSquare.Col;
            var availableMoves = new List<Square>
            {
                Square.At(currenRow - 1, currentCol - 2),
                Square.At(currenRow - 1, currentCol + 2),
                Square.At(currenRow - 2, currentCol - 1),
                Square.At(currenRow - 2, currentCol + 1),
                Square.At(currenRow + 1, currentCol - 2),
                Square.At(currenRow + 1, currentCol + 2),
                Square.At(currenRow + 2, currentCol - 1),
                Square.At(currenRow + 2, currentCol + 1),
            };
            availableMoves.RemoveAll(move =>
                (move.Col < 0 || move.Col > GameSettings.BoardSize - 1 || move.Row < 0 ||
                 move.Row > GameSettings.BoardSize - 1));
            return availableMoves;

        }
    }
}