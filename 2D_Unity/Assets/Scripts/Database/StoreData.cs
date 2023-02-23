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
        InitSkillData(0, "Heal", 150, "�ش� ĳ������ ü���� ������ ȸ���մϴ�.");
        InitSkillData(1, "Level_Up", 250, "�ش� ĳ������ ������ ������ŵ�ϴ�.", 10.0f);
        InitSkillData(2, "Buff", 250, "�ش� ĳ������ ���ݷ°� ������ �����ð� ���� ������ŵ�ϴ�.", 5.0f);
        InitSkillData(3, "Nerf", 250, "�ش� ĳ������ ���ݷ°� ������ �����ð� ���� ���ҽ�ŵ�ϴ�.", 5.0f);
        InitSkillData(4, "Silence", 400, "�ش� ĳ���Ͱ� ���� �ð� ���� ������ �� ������ ����ϴ�.", 5.0f);
        InitSkillData(5, "Reset", 600, "�ش� ĳ������ ��� ü���� ȸ���ϰ�, ������ ������ �����մϴ�.", 10.0f);
        InitSkillData(6, "Destory", 900, "�ش� ĳ���͸� ���� ���� �ı��մϴ�.", 20.0f);
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
