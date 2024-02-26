using System;
using UnityEngine;

public class UIGamePlayPopup : UIPopup
{
    private UIButton[,] _gameButton;

    [Header("Event")]
    [SerializeField] private VoidEventSO _onAppStart;
    [SerializeField] private VoidEventSO _onGameEnd;

    [Header("Model")]
    [SerializeField] private BoardModel Board;
    [SerializeField] private TurnModel TurnModel;
    [SerializeField] private UIButton Button;

    private void OnEnable()
    {
        OnActive += Clear;
        OnActive += Init;
    }

    private void Start()
    {
        ServiceLocator.GetService<UIManager>().OnButtonSelect += ButtonSubmit;
        _onGameEnd.OnEventRaised += DeactiveButton;
        _onAppStart.OnEventRaised += ClosePage;
    }

    public override void Register()
    {
        ServiceLocator.GetService<UIManager>().RegisterPopup(this);
    }

    private void Init()
    {
        var boardSide = Board.GetBoardSide();
        _gameButton = new UIButton[boardSide, boardSide];

        for (int i = 0; i < boardSide; i++)
        {
            for (int j = 0; j < boardSide; j++)
            {
                var obj = Instantiate(Button, transform);
                obj.Text.text = string.Empty;
                Cell cell = new Cell(i, j); 
                obj.Button.onClick.AddListener(() => OnButtonSelect(cell));
                _gameButton[i, j] = obj;
            }
        }
    }

    private void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnButtonSelect(Cell cell)
    {
        if (!TurnModel.IsUserTurn())
            return;
        ServiceLocator.GetService<GameManager>().OnPlayed?.Invoke(cell);
    }

    private void ButtonSubmit(Cell move)
    {
        _gameButton[move.RowIndex,move.ColumnIndex].Text.text = move.CellValue.ToString();
    }

    private void DeactiveButton()
    {
        foreach(var button in _gameButton)
        {
            button.Button.interactable = false;
        }
    }

    private void ClosePage()
    {
        Close();
    }
}
