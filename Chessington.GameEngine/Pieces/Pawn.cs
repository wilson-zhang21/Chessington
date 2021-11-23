using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{   
    
    public class Pawn : Piece
    {
        private bool hasMoved;
        public Pawn(Player player) 
            : base(player) { }
        

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {

            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();
            var nextRow = currentSquare.Row + (Player == Player.White ? -1 : 1);
            var nextSquare = Square.At(nextRow, currentSquare.Col);
            if (board.IsInRange(nextSquare) && board.GetPiece(nextSquare) == null )
            {
                availableMoves.Add(nextSquare);
            }
            
            if (board.IsInRange(nextSquare)&& !hasMoved && board.GetPiece(nextSquare) == null)
            {   
                var nextTwoRow = currentSquare.Row + (Player == Player.White ? -2 : 2);
                var nextTwoSquare = Square.At(nextTwoRow, currentSquare.Col);
                if (board.GetPiece(nextTwoSquare) == null)
                {
                    availableMoves.Add(nextTwoSquare);
                }
                
            }
            
            return availableMoves;
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            base.MoveTo(board, newSquare);
            hasMoved = true;
        }
    
    }
}