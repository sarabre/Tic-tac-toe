using UnityEngine;

[CreateAssetMenu(fileName = "WinStrategy", menuName = "Strategy/Win")]

public class WinStrategy : Strategy
{
    public override bool GetAutoMove(BoardModel board, CellMark userMark, out Cell move)
    {
        CellMark autoPlayerMark = (userMark == CellMark.X) ? CellMark.O : CellMark.X;

        for (int i = 0; i < board.GetBoardSide(); i++)
        {
            for (int j = 0; j < board.GetBoardSide(); j++)
            {
                Cell cell = new Cell(i, j);

                if (board.GetCellMark(cell) == userMark)
                {

                    if (IsWin(board, cell, cell.Up, cell.Bottom, autoPlayerMark, out move))
                        return true;
                    if (IsWin(board, cell, cell.Bottom, cell.Up, autoPlayerMark, out move))
                        return true;

                    if (IsWin(board, cell, cell.Right, cell.Left, autoPlayerMark, out move))
                        return true;
                    if (IsWin(board, cell, cell.Left, cell.Right, autoPlayerMark, out move))
                        return true;

                    if (IsWin(board, cell, cell.UpLeft, cell.BottomRight, autoPlayerMark, out move))
                        return true;
                    if (IsWin(board, cell, cell.BottomRight, cell.UpLeft, autoPlayerMark, out move))
                        return true;

                    if (IsWin(board, cell, cell.UpRight, cell.BottomLeft, autoPlayerMark, out move))
                        return true;
                    if (IsWin(board, cell, cell.BottomLeft, cell.UpRight, autoPlayerMark, out move))
                        return true;
                }

            }
        }
        move = new Cell(-1, -1);
        return false;
    }

    private bool IsWin(BoardModel board, Cell cell, Cell neighborCell, Cell empthyCell, CellMark winMark, out Cell move)
    {
        move = empthyCell;
        
        if (board.IsCellValidInBoard(cell) && board.IsCellValidInBoard(neighborCell) && board.IsCellValidInBoard(empthyCell))
        {
            return (board.GetCellMark(cell) == board.GetCellMark(neighborCell)
                && board.GetCellMark(cell) == winMark
                && board.GetCellMark(empthyCell) == CellMark.Blank);
        }
        return false;
    }
}
