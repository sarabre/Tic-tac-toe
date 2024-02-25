using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomStrategy", menuName = "Strategy/ Random")]
public class RandomStrategy : Strategy
{
    public override bool GetAutoMove(BoardModel board, CellMark userMark, out Cell move)
    {
        List<Cell> empthyCells = new List<Cell>();

        for (int i = 0; i < board.GetBoardSide(); i++)
        {
            for (int j = 0; j < board.GetBoardSide(); j++)
            {
                Cell cell = new Cell(i, j);
                
                if (board.GetCellMark(cell) == CellMark.Blank)
                {
                    empthyCells.Add(cell);
                }
            }
        }

        int RandomIndex = Random.Range(0, empthyCells.Count);
        move = empthyCells[RandomIndex];
        return true;
    }
}
