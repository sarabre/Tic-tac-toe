using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameoverPopup : UIPopup
{
    [SerializeField] private BoardModel BoardModel;
    [SerializeField] private TurnModel TurnModel;

    [SerializeField] private UIButton StartButton;
    [SerializeField] private UIButton ExitButton;
    [SerializeField] private Text ResultText;

    [Header("Event")]
    [SerializeField] private VoidEventSO _onAppStart;

    private string _winText = "Congratulations :) \r\nYou Win";
    private string _failText = "Sorry :( \r\nYou failed";
    private string _tiedText = "Tied";

    public override void Register()
    {
        ServiceLocator.GetService<UIManager>().RegisterPopup(this);
    }

    private void OnEnable()
    {
        OnActive += Init;
        StartButton.Button.onClick.AddListener(() => StartApp());
        ExitButton.Button.onClick.AddListener(() => Application.Quit());
    }

    private void Init()
    {
        if (BoardModel.GetWinner() == CellMark.Blank)
            ResultText.text = _tiedText;
        else if ((BoardModel.GetWinner() == TurnModel.GetUserMark()))
            ResultText.text = _winText;
        else
            ResultText.text = _failText ;
    }

    private void StartApp()
    {
        Close();
        _onAppStart.RaiseEvent();
    }

}
