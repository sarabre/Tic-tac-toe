using System;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class UIStartPopup : UIPopup
{
    public UIButton LevelButton;

    private void OnEnable()
    {
        OnActive += Clear;
        OnActive += Init;
    }

    public override void Register()
    {
        ServiceLocator.GetService<UIManager>().RegisterPopup(this);
    }

    public void Init()
    {
        (string,int)[] texts = ServiceLocator.GetService<UIManager>().GetLevelTitle();
        
        foreach ((string title, int index) level in texts)
        {
            var obj = Instantiate(LevelButton, transform);
            obj.Text.text = level.title;
            obj.Button.onClick.AddListener(() => OnLevelSelect(level.index));
        }
    }

    private void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void OnLevelSelect(int selectedLevelIndex)
    {
        Close();
        ServiceLocator.GetService<GameManager>().OnLevelSelected?.Invoke(selectedLevelIndex);
    }
}
