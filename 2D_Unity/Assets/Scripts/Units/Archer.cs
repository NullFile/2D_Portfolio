using UnityEngine;

public class Archer : Unit
{
    [SerializeField]
    private GameObject arrow;

    void Start()
    {
        Setting_Ai();
        //Setting_AiLerp();
        //Setting_AiPath();
        Team_Check();
        Base_Target();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        // 해당 스테이터스 값
        Unit_Status(Weapon.Archer);

        // 유닛 캐릭터
        Random_Character(team);

        circleCollider = GetComponent<CircleCollider2D>();
        fillAmount = GetComponentInChildren<Image_FillAmount>();
        spriteRenderer.sprite = sprites[0];
    }

    void Team_Check()
    {
        switch (team)
        {
            case Team.Blue:
                {
                    baseTarget = FindObjectOfType<Red_Base>().gameObject;
                }
                break;
            case Team.Red:
                {
                    baseTarget = FindObjectOfType<Blue_Base>().gameObject;
                }
                break;
        }
    }

    void Update()
    {
        Anim_Check();
        Behavior_State();
        Dead_Check();
        Movement();
        Setting_Target();
        Target_Active_Check();
        ZPos_to_YPos();

        Buff_Check();
    }

    void Movement()
    {
        if (aiPath == null)
            return;

        Right_Left_Check(aiPath.desiredVelocity.x);
    }

    void Right_Left_Check(float value)
    {
        if (value == 0.0f)
            return;

        if (value < 0.0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (0.0f < value)
        {
            spriteRenderer.flipX = false;
        }
    }

    void ZPos_to_YPos()
    {
        Vector3 vec = transform.position;

        if (vec.z != vec.y)
            vec.z = vec.y;

        transform.position = vec;
    }

    protected override void Attack()
    {
        if (state == State.Dead)
            return;

        if (0 < attackTimer[0])
        {
            attackTimer[0] -= Time.deltaTime;

            if (attackTimer[0] <= 0.0f)
            {
                if (refTarget != null)
                {
                    Sound_Mgr.instance.SoundPlay("Atk Range");

                    GameObject go = Instantiate(arrow);
                    go.tag = gameObject.tag;
                    //go.layer = gameObject.layer;

                    bool b = go.TryGetComponent(out Arrow outArrow);

                    if (b == true)
                    {
                        outArrow.SetTarget(gameObject, refTarget, Random.Range(damage[0], damage[1]));
                        refTarget = null;
                    }

                    Vector3 vec = transform.position;
                    vec.z = vec.y - 0.1f;
                    vec.y -= 0.1f;

                    go.transform.position = vec;

                    attackTimer[0] = attackTimer[1];
                }
                else
                {
                    attackTimer[0] = 0.0f;
                }
            }
        }
    }

    protected override void Behavior_State()
    {
        base.Behavior_State();

        switch (behavior)
        {
            case Behavior.Search:
                {
                    if (targetList.Count <= 0)
                    {
                        if (aiPath != null)
                            aiPath.enabled = true;

                        behavior = Behavior.Idle;
                        return;
                    }
                    else
                    {
                        if (aiPath != null)
                            aiPath.enabled = false;

                        if (target != null)
                        {
                            float dist = (target.transform.position - transform.position).magnitude;

                            if (dist < attackDist)
                            {
                                behavior = Behavior.Attack;
                            }
                        }
                    }
                }
                break;
        }
    }
}
