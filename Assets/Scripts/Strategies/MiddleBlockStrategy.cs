using UnityEngine;

[CreateAssetMenu(fileName = "MiddleBlockStrategy", menuName = "Strategy/MiddleBlock")]
public class MiddleBlockStrategy : Strategy
{
    public override bool GetAutoMove(BoardModel board, CellMark userMark, out Cell move)
    {
        for (int i = 0; i < board.GetBoardSide(); i++)
        {
            for (int j = 0; j < board.GetBoardSide(); j++)
            {
                Cell cell = new Cell(i, j);

                if (board.GetCellMark(cell) == CellMark.Blank)
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

    private bool CanBlock(BoardModel board, Cell cell, Cell neighborACell, Cell neighborBCell, out Cell move)
    {
        move = cell;
        if (board.IsCellValidInBoard(cell) && board.IsCellValidInBoard(neighborACell) && board.IsCellValidInBoard(neighborBCell))
        {
            return (board.GetCellMark(neighborACell) == board.GetCellMark(neighborBCell) && board.GetCellMark(neighborACell) != CellMark.Blank);
        }
        return false;
    }
}
