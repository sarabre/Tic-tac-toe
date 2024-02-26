
using System.Collections;
using UnityEngine;

public class AutoPlayer : MonoBehaviour
{
    [SerializeField] private BoardModel BoardModel;
    [SerializeField] private TurnModel TurnModel;
    [SerializeField] private LevelModel LevelModel;

    [Header("Event")]
    [SerializeField] private VoidEventSO _onGameStart;
    [SerializeField] private VoidEventSO _onAutoPlayerTurn;

    private void OnEnable()
    {
        _onGameStart.OnEventRaised += Play;
        _onAutoPlayerTurn.OnEventRaised += Play;
    }

    private void OnDisable()
    {
        _onGameStart.OnEventRaised += Play;
        _onAutoPlayerTurn.OnEventRaised += Play;
    }

    private Cell GetMove()
    {
        foreach (var strategy in LevelModel.GetStrategies())
        {
            strategy.GetAutoMove(BoardModel, TurnModel.GetUserMark(), out Cell suggestedMove);
            if (suggestedMove.RowIndex != -1 && suggestedMove.ColumnIndex != -1)
                return suggestedMove;
        }
        return new Cell();
    }

    private void Play()
    {
        StartCoroutine(WaitToPlay());
    }

    private IEnumerator WaitToPlay()
    {
        yield return new WaitForSeconds(0.5f);

        if (!TurnModel.IsUserTurn() && !BoardModel.IsGameEnd())
        {
            Cell cell = GetMove();
            ServiceLocator.GetService<GameManager>().OnPlayed?.Invoke(cell);
        }
    }

}
