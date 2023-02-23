using UnityEngine;

#region Enum Data
    public enum Behavior
    {
        Idle,
        Search,
        Attack,
        Dead,
    }

    public enum Character
    {
        Normal_0,
        Normal_1,
        Normal_2,
        Normal_3,
        Normal_4,
        Normal_5,
        Normal_6,
        Null,
    }

    public enum Skill
    {
        Click,
        Heal,
        Level_Up,
        Buff,
        Nerf,
        Silence,
        Reset,
        Destory,
        Null,
    }

    public enum State
    {
        Idle,
        RedHit,
        Hit,
        Dead,
        Null,
    }

    public enum Team
            {
                Blue,
                Red,
                Null,
            }

    public enum Weapon
    {
        Archer,
        Guard,
        Soldier,
        Wizard,
        Null,
    }
#endregion

public class UnitData : MonoBehaviour
{
    public static UnitData Inst = null;

    public GameObject[] playerSkill;

    [HideInInspector]
    public Sprite[] weaponSprites;
    [HideInInspector]
    public Sprite[] blueSprites;
    [HideInInspector]
    public Sprite[] redSprites;    

    [HideInInspector]
    public Sprite[] blueTowerSprites;
    [HideInInspector]
    public Sprite[] redTowerSprites;

    [HideInInspector]
    public Sprite[] baseSprites;

    void Awake()
    {
        Inst = this;

        weaponSprites = Resources.LoadAll<Sprite>("Images/Weapon/Weapons");
        blueSprites = Resources.LoadAll<Sprite>("Images/Characters/Blue_Characters");
        redSprites = Resources.LoadAll<Sprite>("Images/Characters/Red_Characters");

        blueTowerSprites = Resources.LoadAll<Sprite>("Images/Building/Blue_Tower");
        redTowerSprites = Resources.LoadAll<Sprite>("Images/Building/Red_Tower");

        baseSprites = Resources.LoadAll<Sprite>("Images/Building/Base");
    }

    //void Start()
    //{
  
    //}
}
