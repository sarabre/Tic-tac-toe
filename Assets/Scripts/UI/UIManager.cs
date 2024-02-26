using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public LevelModel LevelModel;
    public TurnModel TurnModel;
    public Action<Cell> OnButtonSelect;

    private PopupDictionary _popupDictionary = new PopupDictionary();

    [Header("Event")]
    [SerializeField] private VoidEventSO _onAppStart;
    [SerializeField] private VoidEventSO _onSpecifiedTurn;
    [SerializeField] private VoidEventSO _onGameStart;
    [SerializeField] private VoidEventSO _onGameEnd;

    private void Awake()
    {
        _onAppStart.OnEventRaised += StartApp;
        _onSpecifiedTurn.OnEventRaised += SpecifyTurn;
        _onGameStart.OnEventRaised += StartGame;
        _onGameEnd.OnEventRaised += GameEnd;
    }

    private void OnDestroy()
    {
        _onAppStart.OnEventRaised -= StartApp;
        _onSpecifiedTurn.OnEventRaised -= SpecifyTurn;
        _onGameStart.OnEventRaised -= StartGame;
        _onGameEnd.OnEventRaised -= GameEnd;
    }

    private void OnEnable()
    {
        ServiceLocator.RegisterService(this);
    }

    public (string, int)[] GetLevelTitle()
    {
        return LevelModel.GetLevelTitle();
    }

    public bool GetIsUserFirstPlayer()
    {
        return TurnModel.GetIsFirstTurnUser;
    }

    public void RegisterPopup<T>(T popup) where T : UIPopup
    {
        _popupDictionary.RegisterPopup<T>(popup);
    }

    private void StartApp()
    {
        _popupDictionary.GetPopup<UIStartPopup>().Open();
    }

    private void SpecifyTurn()
    {
        _popupDictionary.GetPopup<UITurnPopup>().Open();
    }

    private void StartGame()
    {
        _popupDictionary.GetPopup<UIGamePlayPopup>().Open();
    }

    private void GameEnd()
    {
        _popupDictionary.GetPopup<UIGameoverPopup>().Open();
    }
}
