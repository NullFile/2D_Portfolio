using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luna_Btn : Store_Character
{
    [SerializeField]
    private GameObject achievementsPanel;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Start_Button()
    {
        base.Start_Button();

        if (clickBtn[0] != null)
            clickBtn[0].onClick.AddListener(() =>
            {
                Typing_Text();

                isClick = !isClick;
            });

        if (clickBtn[1] != null)
            clickBtn[1].onClick.AddListener(() =>
            {
                Open_AchievementsPanel();

                isClick = !isClick;
            });
    }

    void Open_AchievementsPanel()
    {
        if (achievementsPanel != null)
        {
            achievementsPanel.SetActive(true);
        }
    }
}
