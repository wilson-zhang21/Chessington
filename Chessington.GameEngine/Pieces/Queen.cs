using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMovesLateral = GetAvailableMovesLateral(board).ToList();
            var availableMovesDiagonal = GetAvailableMovesDiagonal(board).ToList();
            availableMovesLateral.AddRange(availableMovesDiagonal);
            return availableMovesLateral;

        }
        
        private IEnumerable<Square> GetAvailableMovesLateral(Board board)
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

        private IEnumerable<Square> GetAvailableMovesDiagonal(Board board)
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