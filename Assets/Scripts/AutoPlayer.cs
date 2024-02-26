
using System.Collections;
using UnityEngine;

public class AutoPlayer : MonoBehaviour
{
    [SerializeField] private BoardModel BoardModel;
    [SerializeField] private TurnModel TurnModel;
    [SerializeField] private LevelModel LevelModel;

    [Header("Event")]
    private void OnEnable()
    {
        ServiceLocator.GetService<GameManager>().OnGameStart += Play;
        ServiceLocator.GetService<GameManager>().OnAutoPlayerTurn += Play;
    }

    private void OnDisable()
    {
        ServiceLocator.GetService<GameManager>().OnGameStart += Play;
        ServiceLocator.GetService<GameManager>().OnAutoPlayerTurn += Play;

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
