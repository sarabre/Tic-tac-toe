using UnityEngine;

public abstract class Strategy : ScriptableObject
{
    public abstract bool GetAutoMove(BoardModel board, CellMark userMark, out Cell move);

}
