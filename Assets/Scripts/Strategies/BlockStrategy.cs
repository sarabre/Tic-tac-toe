using UnityEngine;

[CreateAssetMenu(fileName = "BlockStrategy", menuName = "Strategy/Block")]
public class BlockStrategy : Strategy
{
    public override bool GetAutoMove(BoardModel board,CellMark userMark,out Cell move)
    {
        for (int i = 0; i < board.GetBoardSide(); i++)
        {
            for (int j = 0; j < board.GetBoardSide(); j++)
            {
                Cell cell = new Cell(i, j);

                if(board.GetCellMark(cell) == userMark)
                {

                    if (CanBlock(board, cell, cell.Up, cell.Bottom, out move))
                        return true;
                    if (CanBlock(board, cell, cell.Bottom, cell.Up, out move))
                        return true;

                    if (CanBlock(board, cell, cell.Right, cell.Left, out move))
                        return true;
                    if (CanBlock(board, cell, cell.Left, cell.Right, out move))
                        return true;

                    if (CanBlock(board, cell, cell.UpLeft, cell.BottomRight, out move))
                        return true;
                    if (CanBlock(board, cell, cell.BottomRight, cell.UpLeft, out move))
                        return true;

                    if (CanBlock(board, cell, cell.UpRight, cell.BottomLeft, out move))
                        return true;
                    if (CanBlock(board, cell, cell.BottomLeft, cell.UpRight, out move))
                        return true;
                }
                }
        }
        move = new Cell(-1, -1);
        return false;
    }

    private bool CanBlock(BoardModel board, Cell cell, Cell neighborCell, Cell empthyCell, out Cell move)
    {
        move = empthyCell;
        if (board.IsCellValidInBoard(cell) && board.IsCellValidInBoard(neighborCell) && board.IsCellValidInBoard(empthyCell))
        {
            return (board.GetCellMark(cell) == board.GetCellMark(neighborCell) && board.GetCellMark(empthyCell) == CellMark.Blank);
        }
        return false;
    }

}
