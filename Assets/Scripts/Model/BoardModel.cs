using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardModel", menuName = "Model/BoardModel")]
public class BoardModel : ScriptableObject, IModel
{
    private const int _boardSide = 3;
    private CellMark[,] _board = new CellMark[_boardSide, _boardSide];
    private CellMark _winner;

    public int GetLength()
    {
        return _board.Length;
    }

    public int GetBoardSide()
    {
        return _boardSide;
    }

    public CellMark GetWinner() 
    {
        return _winner;
    }

    public bool CanSubmit(Cell move)
    {
        return IsEmpthy(move);
    }

    public bool IsGameEnd()
    {
        FindWinner(out _winner);

        
        if (HaveEmpthy() && _winner == CellMark.Blank)
            return false;

        Debug.Log($"Game End _winner = {_winner}");
        return true;
    }

    public CellMark GetCellMark(Cell cell)
    {
        return _board[cell.RowIndex, cell.ColumnIndex];
    }

    public void Submit(Cell move)
    {
        _board[move.RowIndex, move.ColumnIndex] = move.CellValue;
    }

    public bool IsEmpthy(Cell move)
    {
        return (_board[move.RowIndex, move.ColumnIndex] == CellMark.Blank);
    }

    private bool HaveEmpthy()
    {
        for (int i = 0; i < _boardSide; i++)
        {
            for (int j = 0; j < _boardSide; j++)
            {
                if (_board[i, j] == CellMark.Blank)
                    return true;
            }
        }
        return false;
    }

    private bool IsInBoardRange(int index)
    {
        return (index >= 0 && index < _boardSide);
    }

    public bool IsCellValidInBoard(Cell cell)
    {
        return (IsInBoardRange(cell.RowIndex) && IsInBoardRange(cell.ColumnIndex));
    }

    private bool IsEqualMark(Cell cell, Cell neighborCell)
    {
        return (_board[cell.RowIndex, cell.ColumnIndex] == _board[neighborCell.RowIndex, neighborCell.ColumnIndex]);
    }

    public bool IsEqualToNeighborCell(Cell cell, Cell neighborCell)
    {
        return (IsCellValidInBoard(neighborCell) && IsEqualMark(cell, neighborCell));
    }

    public void Clear()
    {
        _board = new CellMark[_boardSide, _boardSide];
        _winner = CellMark.Blank;
    }
    private bool IsWin(Cell cell)
    {
        return (
                cell.CellValue != CellMark.Blank && (
                IsEqualToNeighborCell(cell, cell.Up) && IsEqualToNeighborCell(cell, cell.Bottom) ||
                IsEqualToNeighborCell(cell, cell.Right) && IsEqualToNeighborCell(cell, cell.Left) ||
                IsEqualToNeighborCell(cell, cell.UpRight) && IsEqualToNeighborCell(cell, cell.BottomLeft) ||
                IsEqualToNeighborCell(cell, cell.BottomRight) && IsEqualToNeighborCell(cell, cell.UpLeft)
               ));
    }

    private void FindWinner(out CellMark cellMark)
    {
        cellMark = CellMark.Blank;

        for (int i = 0; i < _boardSide; i++)
        {
            for (int j = 0; j < _boardSide; j++)
            {
                Cell cell = new Cell(i, j, _board[i, j]);
                if (IsWin(cell))
                    cellMark = cell.CellValue;
            }
        }
    }

    
}
