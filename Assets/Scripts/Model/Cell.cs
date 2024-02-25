
public struct Cell
{
    public int ColumnIndex;
    public int RowIndex;
    public CellMark CellValue;

    public Cell Up
    {
        get
        {
            return new Cell(RowIndex - 1,ColumnIndex);
        }

    }
    public Cell Bottom
    {
        get
        {
            return new Cell(RowIndex + 1,ColumnIndex);
        }

    }
    public Cell Right
    {
        get
        {
            return new Cell(RowIndex,ColumnIndex + 1);
        }

    }
    public Cell Left
    {
        get
        {
            return new Cell(RowIndex,ColumnIndex - 1);
        }

    }
    public Cell UpRight
    {
        get
        {
            return new Cell(RowIndex - 1, ColumnIndex + 1);
        }

    }
    public Cell UpLeft
    {
        get
        {
            return new Cell(RowIndex - 1, ColumnIndex - 1);
        }

    }
    public Cell BottomRight
    {
        get
        {
            return new Cell(RowIndex + 1, ColumnIndex + 1);
        }

    }
    public Cell BottomLeft
    {
        get
        {
            return new Cell(RowIndex + 1, ColumnIndex - 1);
        }

    }

    public Cell(int rowIndex,int columnIndex, CellMark boardValue)
    {
        ColumnIndex = columnIndex;
        RowIndex = rowIndex;
        CellValue = boardValue;
    }

    public Cell(int rowIndex, int columnIndex)
    {
        ColumnIndex = columnIndex;
        RowIndex = rowIndex;
        CellValue = CellMark.Blank;
    }

    public void SetCellMark(CellMark cellMark)
    {
        CellValue = cellMark;
    }
}

