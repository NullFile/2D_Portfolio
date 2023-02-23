using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillData
{
    bool isLock;
    public bool GsLock { get { return isLock; } set { isLock = value; } }

    int Index;
    string Name;
    int Gold;
    string Explanation;
    float CoolTime;

    public void InitData(int idx, string name, int gold, string explanation, float cooltime = 1.0f)
    {
        isLock = false;
        //isBuy = false;

        Index = idx;
        Name = name;
        Gold = gold; 
        Explanation = explanation;
        CoolTime = cooltime;
    }

    public int GetIndex() { return Index; }
    public string GetName() { return Name; }
    public int GetGold() { return Gold; }
    public string GetExplanation() { return Explanation; }
    public float GetCoolTime() { return CoolTime; }
}

public class StoreData : MonoBehaviour
{
    public static StoreData Inst = null;

    [Header("Skill")]
    List<SkillData> sList = new List<SkillData>();
    List<GameObject> sgList = new List<GameObject>();

    public GameObject sNode;
    public Transform sContents;

    [SerializeField]
    private Sprite[] sSprites;

    public GameObject select;
    public Transform canvas;

    public GameObject goldCheck;

    void Awake()
    {
        Inst = this;

        Setting_SkillData();
        InitSkillBuyButton();
        SkillRefresh();
    }

    public void SetSList_GsLock(int index, bool b)
    {
        sList[index].GsLock = b;
    }

    public SkillData GetSList(int index)
    {
        return sList[index];
    }

    public void SkillRefresh()
    {
        for (int i = 0; i < sList.Count; i++)
        {
            if (sList[i].GsLock == true)
            {
                if (sgList[i].TryGetComponent(out Store_Skill_Node outStore))
                {
                    if (GlobalData.skill[i] == true)
                        outStore.Set_LockImage(true);
                    else 
                        outStore.Set_LockImage(false);
                }
            }
        }
    }

    void Setting_SkillData()
    {
        InitSkillData(0, "Heal", 150, "해당 캐릭터의 체력을 일정량 회복합니다.");
        InitSkillData(1, "Level_Up", 250, "해당 캐릭터의 레벨을 증가시킵니다.", 10.0f);
        InitSkillData(2, "Buff", 250, "해당 캐릭터의 공격력과 방어력을 일정시간 동안 증가시킵니다.", 5.0f);
        InitSkillData(3, "Nerf", 250, "해당 캐릭터의 공격력과 방어력을 일정시간 동안 감소시킵니다.", 5.0f);
        InitSkillData(4, "Silence", 400, "해당 캐릭터가 일정 시간 동안 공격할 수 없도록 만듭니다.", 5.0f);
        InitSkillData(5, "Reset", 600, "해당 캐릭터의 모든 체력을 회복하고, 버프와 너프를 해제합니다.", 10.0f);
        InitSkillData(6, "Destory", 900, "해당 캐릭터를 조건 없이 파괴합니다.", 20.0f);
    }

    void InitSkillData(int idx, string name, int gold, string explanation, float cooltime = 1.0f)
    {
        SkillData node = new SkillData();
        node.InitData(idx, name, gold, explanation, cooltime);
        sList.Add(node);
    }
    
    void InitSkillBuyButton()
    {
        for (int i = 0; i < sList.Count; i++)
        {
            GameObject go = Instantiate(sNode);
            go.transform.SetParent(sContents, false);

            bool b = go.TryGetComponent(out Store_Skill_Node outNode);

            if (b == true)
            {
                outNode.Data_Init(sList[i].GetIndex(), sList[i].GetName(), 
                    sList[i].GetExplanation(), sSprites[i], sList[i].GetGold(), GlobalData.skill[i]);
            }

            sgList.Add(go);
        }
    }
}
