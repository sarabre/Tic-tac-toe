using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITurnPopup : UIPopup
{
    public Button NextButton;
    public Text TurnText;

    [Header("Event")]
    private void OnEnable()
    {
        OnActive += Init;
        OnActive += SetTurnText;
    }

    public override void Register()
    {
        ServiceLocator.GetService<UIManager>().RegisterPopup(this);
    }

    public void Init()
    {
        NextButton.onClick.AddListener(StartGamePlay);
    }

    private void SetTurnText()
    {
        bool isUserFirstTurn = ServiceLocator.GetService<UIManager>().GetIsUserFirstPlayer();
        string turnText = (isUserFirstTurn) ? "One" : "Two" ;
        TurnText.text = $"You are player {turnText}";
    }

    private void StartGamePlay()
    {
        Close();
        ServiceLocator.GetService<GameManager>().OnGameStart?.Invoke();
    }
}
