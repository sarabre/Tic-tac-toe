using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelModel",menuName = "Model/LevelModel")]
public class LevelModel : ScriptableObject, IModel
{
    [SerializeField]
    private LevelData[] _alllevels;

    private LevelData _currentLevel;

    public Strategy[] GetStrategies()
    {
        return _currentLevel.Strategies;
    }

    public (string title, int index)[] GetLevelTitle()
    {
        (string, int)[] titles = new (string, int)[_alllevels.Length];
        for (int i = 0; i < _alllevels.Length; i++)
        {
            titles[i].Item1 = _alllevels[i].LevelTitle;
            titles[i].Item2 = i;
        }
        return titles;
    }

    public void LevelSelected(int SelectedIndex)
    {
        _currentLevel = _alllevels[SelectedIndex];
    }

    public void Clear()
    {
        _currentLevel = null;
    }
}
