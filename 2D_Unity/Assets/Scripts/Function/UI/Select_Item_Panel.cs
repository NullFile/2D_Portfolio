using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Item_Panel : MonoBehaviour
{
    private int index = 0;

    [SerializeField]
    private Button okBtn;
    [SerializeField]
    private Button cencalBtn;
    [SerializeField]
    private Text selectText;
    [SerializeField]
    private Text explanationText;

    void Start()
    {
        if (okBtn != null)
            okBtn.onClick.AddListener(() =>
            {
                Sound_Mgr.instance.SoundPlay("Sell");

                Add_Item();
                Destroy(gameObject);
            });        
        
        if (cencalBtn != null)
            cencalBtn.onClick.AddListener(() => 
            {
                Sound_Mgr.instance.SoundPlay("Button");

                Destroy(gameObject);
            });
    }

    void Add_Item()
    {
        if (GlobalData.skill[index] == false)
        {
            StoreData.Inst.SetSList_GsLock(index, true);
            int value = StoreData.Inst.GetSList(index).GetGold();
            int gold = Store_Mgr.Inst.GetGold();

            Store_Mgr.Inst.SetGold(gold - value);
            GlobalData.UserGold = Store_Mgr.Inst.GetGold();

            GlobalData.skill[index] = true;
        }
        //else
        //    Debug.Log("이미 아이템을 구매했습니다.");

        GlobalData.SaveData();

        StoreData.Inst.SkillRefresh();
        Store_Mgr.Inst.GoldRefresh();
    }
    
    public void Data_Init(int idx, string select, string explanation)
    {
        index = idx;
        selectText.text = select;
        explanationText.text = explanation;
    }
}
