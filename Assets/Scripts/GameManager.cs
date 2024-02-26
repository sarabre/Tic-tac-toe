using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [Header("Event")]
    [SerializeField] private VoidEventSO _onAppStart;
    [SerializeField] private VoidEventSO _onSpecifiedTurn;
    [SerializeField] private VoidEventSO _onAutoPlayerTurn;
    [SerializeField] private VoidEventSO _onGameEnd;
    [SerializeField] private CellEventSO _onPlayed;

    public Action<int> OnLevelSelected;

    [Header("Model")]
    [SerializeField] private LevelModel LevelModel;
    [SerializeField] private TurnModel TurnModel;
    [SerializeField] private BoardModel Board;

    private void OnEnable()
    {
        ServiceLocator.RegisterService(this);
        OnLevelSelected += LevelSelected;
        _onPlayed.OnEventRaised += Play;
        _onPlayed.OnEventRaised += CheckGameEnd;
        _onAppStart.OnEventRaised += ClearModel;
    }

    private void OnDisable()
    {
        OnLevelSelected -= LevelSelected;
        _onPlayed.OnEventRaised -= Play;
        _onPlayed.OnEventRaised -= CheckGameEnd;
        _onAppStart.OnEventRaised -= ClearModel;
    }

    private void Start()
    {
        _onAppStart.RaiseEvent();
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
            _onAutoPlayerTurn.RaiseEvent();
        }
    }


    private void LevelSelected(int levelIndex)
    {
        TurnModel.OnSpeciyTurn?.Invoke();
        LevelModel.LevelSelected(levelIndex);
        _onSpecifiedTurn.RaiseEvent();
    }

    private void CheckGameEnd(Cell cell)
    {
        if(Board.IsGameEnd())
            _onGameEnd.RaiseEvent();
    }
   
    private void ClearModel()
    {
        Board.Clear();
        TurnModel.Clear();
        LevelModel.Clear();
    }
}
