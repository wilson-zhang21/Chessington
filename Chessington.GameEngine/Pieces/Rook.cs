using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            
            for (int col = currentSquare.Col + 1; col <= GameSettings.BoardSize - 1; col++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row, col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row, col));
                }
                else
                {
                    break;
                }
            }
            
            for (int col = currentSquare.Col - 1; col >= 0; col--)
            {
                if (board.GetPiece(Square.At(currentSquare.Row, col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row, col));
                }
                else
                {
                    break;
                }
                
            }
            
            for (int row = currentSquare.Row + 1; row <= GameSettings.BoardSize - 1; row++)
            {
                if (board.GetPiece(Square.At(row, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(row, currentSquare.Col));
                }
                else
                {
                    break;
                }
            }
            
            for (int row = currentSquare.Row - 1; row >= 0; row--)
            {
                if (board.GetPiece(Square.At(row, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(row, currentSquare.Col));
                }
                else
                {
                    break;
                }
            }
            
            return availableMoves;
        }
    }
}