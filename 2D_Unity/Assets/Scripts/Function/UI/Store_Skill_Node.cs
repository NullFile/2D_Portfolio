using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store_Skill_Node : MonoBehaviour
{
    private Button button;

    private int index;
    private string skillName;
    private string skillExplanation;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Text text;
    private int skillGold;

    [SerializeField]
    private GameObject lockImage;
    [SerializeField]
    private GameObject buyImage;

    void Start()
    {
        button = GetComponentInChildren<Button>();

        if (button != null)
            button.onClick.AddListener(() =>
            {
                Sound_Mgr.instance.SoundPlay("Button");

                if (Store_Mgr.Inst.GetGold() < skillGold)
                {
                    GameObject go = Instantiate(StoreData.Inst.goldCheck);
                    go.transform.SetParent(StoreData.Inst.canvas, false);
                }
                else
                {
                    GameObject go = Instantiate(StoreData.Inst.select);
                    go.transform.SetParent(StoreData.Inst.canvas, false);

                    bool b = go.TryGetComponent(out Select_Item_Panel outSelect);

                    if (b == true)
                    {
                        outSelect.Data_Init(index, skillName, skillExplanation);
                    }
                }
            });
    }

    public void Set_LockImage(bool b)
    {
        if (lockImage != null)
            lockImage.SetActive(b);
    }

    public void Data_Init(int idx, string name, 
        string explanation, Sprite sprite, int gold, bool i)
    {
        index = idx;
        skillName = name;
        skillExplanation = explanation;
        image.sprite = sprite;
        skillGold = gold;
        text.text = skillGold.ToString();

        Set_LockImage(i);
    }
}
