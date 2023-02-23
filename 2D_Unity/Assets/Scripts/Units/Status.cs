using UnityEngine;

public class Status : MonoBehaviour
{
    // ���� ����
    protected int level;
    // ü�� ���� // cur, max
    protected float[] hp = new float[2];
    // ���ݷ� ���� // min, max
    protected float[] damage = new float[2] { 0.0f, 0.0f };
    // ���� ���� // min, max
    protected float[] defence = new float[2] { 0.0f, 0.0f };
    // �Ÿ� ����
    protected float searchDist; // ���� Trigger Enter 2D �� ���
    protected float attackDist;
    // ���� �ð� ���� // Timer, Delay
    protected float[] attackTimer = new float[] { 0.0f, 0.0f };
    // �̵� �ӵ� ����
    protected float moveSpeed;
    // ���� �ð� ���� // Timer, Delay
    protected float[] buffTimer = new float[2];
    // ó�� �ð� ���� // Timer, Delay
    protected float[] deadTimer = new float[] { 0.0f, 1.5f };

    // Temp ����
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
