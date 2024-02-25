using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurnModel", menuName = "Model/TurnModel")]
public class TurnModel : ScriptableObject, IModel
{
    public bool GetIsFirstTurnUser => _isFirstTurnUser;

    public Action OnPlayed;
    public Action OnSpeciyTurn;

    private bool _isFirstTurnUser;
    private bool _isUserTurnNow;

    private void OnEnable()
    {
        OnSpeciyTurn += SpecifyTurn;
        OnSpeciyTurn += InitTurn;
        OnPlayed += Played;
    }

    public bool IsUserTurn()
    {
        return _isUserTurnNow;
    }

    public CellMark GetTurnMark()
    {
        return (_isFirstTurnUser == IsUserTurn()) ? CellMark.X : CellMark.O;
    }

    public CellMark GetUserMark()
    {
        return (_isFirstTurnUser) ? CellMark.X : CellMark.O;
    }

    public void Clear()
    {
        _isFirstTurnUser = default(bool);
        _isUserTurnNow = default(bool);
    }

    private void SpecifyTurn()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, 2);
        _isFirstTurnUser = Convert.ToBoolean(randomNumber);
    }

    private void InitTurn()
    {
        _isUserTurnNow = _isFirstTurnUser;
    }

    private void Played()
    {
        _isUserTurnNow = !_isUserTurnNow;
    }
}
