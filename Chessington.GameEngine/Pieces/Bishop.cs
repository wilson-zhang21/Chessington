using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);

            //Checking the backwards diagonal, i.e. 0,0 1,1, 2,2
            for (var i = currentSquare.Row + 1; i <= GameSettings.BoardSize - 1; i++)
            {
                if (board.GetPiece(Square.At(i,i)) == null)
                {
                    availableMoves.Add(Square.At(i, i));
                }
                else
                {
                    break;
                }
                
            }
            for (var i = currentSquare.Row - 1; i >= 0; i--)
            {
                
                if (board.GetPiece(Square.At(i,i)) == null)
                {
                    availableMoves.Add(Square.At(i, i));
                }
                else
                {
                    break;
                }
                
            }

            var j = currentSquare.Col - 1;
            for (var i = currentSquare.Row + 1; i <= GameSettings.BoardSize - 1 && j >= 0; i++)
            {
                
                if (board.GetPiece(Square.At(i,j)) == null)
                {
                    availableMoves.Add(Square.At(i, j));
                    j--;
                }
                else
                {
                    break;
                }
                
            }
            

            
            j = currentSquare.Col + 1;
            for (var i = currentSquare.Row - 1; i >= 0 && j <= GameSettings.BoardSize - 1; i--)
            {
               
                if (board.GetPiece(Square.At(i,j)) == null)
                {
                    availableMoves.Add(Square.At(i, j));
                    j++;
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