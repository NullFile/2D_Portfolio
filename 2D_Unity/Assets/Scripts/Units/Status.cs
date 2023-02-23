using UnityEngine;

public class Status : MonoBehaviour
{
    // 레벨 변수
    protected int level;
    // 체력 변수 // cur, max
    protected float[] hp = new float[2];
    // 공격력 변수 // min, max
    protected float[] damage = new float[2] { 0.0f, 0.0f };
    // 방어력 변수 // min, max
    protected float[] defence = new float[2] { 0.0f, 0.0f };
    // 거리 변수
    protected float searchDist; // 현재 Trigger Enter 2D 로 사용
    protected float attackDist;
    // 공격 시간 변수 // Timer, Delay
    protected float[] attackTimer = new float[] { 0.0f, 0.0f };
    // 이동 속도 변수
    protected float moveSpeed;
    // 버프 시간 변수 // Timer, Delay
    protected float[] buffTimer = new float[2];
    // 처리 시간 변수 // Timer, Delay
    protected float[] deadTimer = new float[] { 0.0f, 1.5f };

    // Temp 변수
    protected float[] damageTemp = new float[2];
    protected float[] defenceTemp = new float[2];

    protected void Unit_Status(Weapon weapon)
    {
        switch (weapon)
        {
            case Weapon.Archer:
                {
                    hp[1] = 150.0f;

                    damage[0] = 35.0f;
                    damage[1] = 50.0f;

                    damageTemp = damage;
                    defenceTemp = defence;

                    attackDist = 3.5f;
                    attackTimer[1] = 1.5f;
                }
                break;
            case Weapon.Guard:
                {
                    hp[1] = 400.0f;

                    damage[0] = 15.0f;
                    damage[1] = 25.0f;

                    damageTemp = damage;
                    defenceTemp = defence;

                    attackDist = 1.0f;
                    attackTimer[1] = 1.0f;
                }
                break;
            case Weapon.Soldier:
                {
                    hp[1] = 300.0f;

                    damage[0] = 25.0f;
                    damage[1] = 40.0f;

                    damageTemp = damage;
                    defenceTemp = defence;

                    attackDist = 1.0f;
                    attackTimer[1] = 1.0f;
                }
                break;
            case Weapon.Wizard:
                {
                    hp[1] = 100.0f;

                    damage[0] = 45.0f;
                    damage[1] = 90.0f;

                    damageTemp = damage;
                    defenceTemp = defence;

                    attackDist = 4.0f;
                    attackTimer[1] = 2.0f;
                }
                break;
        }

        hp[0] = hp[1];
    }

    protected void Building_Status(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Base:
                {
                    hp[1] = 3000.0f;
                }
                break;
            case BuildingType.Tower:
                {
                    hp[1] = 1000.0f;
                }
                break;
        }

        hp[0] = hp[1];
    }

    public float Get_CurHp() { return hp[0]; }
}
