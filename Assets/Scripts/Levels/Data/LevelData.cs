using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class LevelData : ScriptableObject
{
    public string LevelTitle;
    public Strategy[] Strategies;

}
