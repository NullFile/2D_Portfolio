using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ludo_Btn : Store_Character
{
    [SerializeField]
    private GameObject buyPenal;

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
                Open_BuyPenal();

                isClick = !isClick;
            });
    }
    void Open_BuyPenal()
    {
        if (buyPenal != null)
        {
            buyPenal.SetActive(true);
        }
    }
}
