using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public Action OnAppStart;
    public Action<int> OnLevelSelected;
    public Action OnSpecifiedTurn;
    public Action OnGameStart;
    public Action<Cell> OnPlayed;
    public Action OnAutoPlayerTurn;
    public Action OnGameEnd;

    [SerializeField] private LevelModel LevelModel;
    [SerializeField] private TurnModel TurnModel;
    [SerializeField] private BoardModel Board;

    private void OnEnable()
    {
        ServiceLocator.RegisterService(this);
        OnLevelSelected += LevelSelected;
        OnPlayed += Play;
        OnPlayed += CheckGameEnd;
        OnAppStart += ClearModel;
    }

    private void OnDisable()
    {
        OnLevelSelected -= LevelSelected;
        OnPlayed -= Play;
        OnPlayed -= CheckGameEnd;
        OnAppStart -= ClearModel;
    }

    private void Start()
    {
        OnAppStart?.Invoke();
    }

    public bool TrySelectCell(Cell move, out CellMark mark)
    {
        mark = CellMark.Blank;
        
        if (!Board.CanSubmit(move))
            return false;

        mark = TurnModel.GetTurnMark();
        move.SetCellMark(mark);
        Board.Submit(move);
        return true;
    }

    private void Play(Cell cell)
    {
        if (TrySelectCell(cell, out CellMark mark))
        {
            cell.SetCellMark(mark);
            ServiceLocator.GetService<UIManager>().OnButtonSelect?.Invoke(cell);
            TurnModel.OnPlayed?.Invoke();
            OnAutoPlayerTurn?.Invoke();
        }
    }


    private void LevelSelected(int levelIndex)
    {
        TurnModel.OnSpeciyTurn?.Invoke();
        LevelModel.LevelSelected(levelIndex);
        OnSpecifiedTurn?.Invoke();
    }

    private void CheckGameEnd(Cell cell)
    {
        if(Board.IsGameEnd())
            OnGameEnd?.Invoke();
    }
   
    private void ClearModel()
    {
        Board.Clear();
        TurnModel.Clear();
        LevelModel.Clear();
    }
}
