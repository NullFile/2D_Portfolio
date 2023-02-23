using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

//public interface IAttackable
//{
//    void Attack();
//}

//public interface IDamegeable
//{
//    void TakeDamage(float dmg);
//}

public class Unit : Status, IDamageable, IHealable
{
    protected AIPath aiPath;
    protected AILerp aiLerp;

    [SerializeField]
    protected Team team;
    [SerializeField]
    protected Character character;
    // 애니메이션 현재 상태
    protected State state;

    [SerializeField]
    protected Behavior behavior = Behavior.Idle;

    // 걸린 버프
    protected Skill skill;
    float skillTime = 0.0f; 

    //[SerializeField]
    //protected LayerMask checkLayer;

    // 현재 이미지
    protected SpriteRenderer spriteRenderer;
    // 캐릭터 별 상태에 따른 이미지
    protected Sprite[] sprites = new Sprite[4];

    protected List<GameObject> targetList = new List<GameObject>();
    // 공격 대상
    protected GameObject target;
    protected GameObject refTarget;
    // 최종 공격 대상
    protected GameObject baseTarget;

    protected CircleCollider2D circleCollider;
    
    // 체력 확인
    protected Image_FillAmount fillAmount;

    float[] temp = new float[2];

    public void Add_Target(GameObject go)
    {
        if (go == this.gameObject)
            return;

        if (0 < targetList.Count)
        {
            for (int i = 0; i < targetList.Count; i++)
            {
                if (targetList[i] == go)
                    return;
            }
        }

        targetList.Add(go);

        if (attackTimer[0] <= 0.0f)
            attackTimer[0] = attackTimer[1];
    }

    protected void Anim_Check()
    {
        switch (state)
        {
            case State.Idle:
                spriteRenderer.sprite = sprites[(int)State.Idle];
                break;
            case State.RedHit:
                spriteRenderer.sprite = sprites[(int)State.RedHit];
                break;
            case State.Hit:
                spriteRenderer.sprite = sprites[(int)State.Hit];
                break;
            case State.Dead:
                spriteRenderer.sprite = sprites[(int)State.Dead];
                break;
            case State.Null:
                break;
        }
    }

    protected virtual void Attack() { }

    protected virtual void Base_Target() 
    {
        if (aiLerp != null)
            aiLerp.destination = baseTarget.transform.position;

        if (aiPath != null)
            aiPath.destination = baseTarget.transform.position;
    }

    protected virtual void Behavior_State() 
    {
        switch (behavior)
        {
            case Behavior.Idle:
                {
                    if (0 < targetList.Count)
                    {
                        behavior = Behavior.Search;
                        return;
                    }
                }
                break;
            case Behavior.Search:
                {

                }
                break;
            case Behavior.Attack:
                {
                    Attack();
                }
                break;
            case Behavior.Dead:
                {
                    if (aiPath != null)
                        aiPath.enabled = false;

                    state = State.Dead;
                }
                break;
        }
    }

    public bool Buff_or_Nerf(Skill skill)
    {
        bool apply = false;

        switch (skill)
        {
            case Skill.Click:
                {
                    if (hp[0] <= 0.0f)
                        return apply;

                    GameObject go = Instantiate(UnitData.Inst.playerSkill[(int)skill]);
                    go.transform.position = transform.position;
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));

                    OnDamage(40.0f);
                }
                break;
            case Skill.Heal:
                {
                    if (hp[1] <= hp[0])
                        return apply;

                    GameObject go = Instantiate(UnitData.Inst.playerSkill[(int)skill]);

                    Vector3 vec = transform.position;
                    vec.z -= 0.1f;

                    go.transform.position = vec;

                    OnHeal(20.0f);
                }
                break;
            case Skill.Level_Up:
                {
                    GameObject go = Instantiate(UnitData.Inst.playerSkill[(int)skill]);

                    Vector3 vec = transform.position;
                    vec.z -= 0.1f;

                    go.transform.position = vec;

                    level++;
                    // 레벨 업
                }
                break;
            case Skill.Buff:
                {
                    GameObject go = Instantiate(UnitData.Inst.playerSkill[(int)skill]);

                    Vector3 vec = transform.position;
                    vec.z -= 0.1f;

                    go.transform.position = vec;

                    // 공격 버프
                    temp = damage;

                    damage[0] += temp[0] * 0.25f;
                    damage[1] += temp[1] * 0.25f;

                    // 방어 버프
                    temp = defence;

                    defence[0] += temp[0] * 0.25f;
                    defence[1] += temp[1] * 0.25f;

                    skillTime = 10.0f;
                }
                break;
            case Skill.Nerf:
                {
                    GameObject go = Instantiate(UnitData.Inst.playerSkill[(int)skill]);

                    Vector3 vec = transform.position;
                    vec.z -= 0.1f;

                    go.transform.position = vec;

                    // 공격 너프
                    temp = damage;

                    damage[0] -= temp[0] * 0.25f;
                    damage[1] -= temp[1] * 0.25f;

                    // 방어 너프
                    temp = defence;

                    defence[0] -= temp[0] * 0.25f;
                    defence[1] -= temp[1] * 0.25f;

                    skillTime = 10.0f;
                }
                break;
            case Skill.Silence:
                {
                    GameObject go = Instantiate(UnitData.Inst.playerSkill[(int)skill]);

                    Vector3 vec = transform.position;
                    vec.z -= 0.1f;

                    go.transform.position = vec;

                    attackTimer[0] = attackTimer[1] * 5.0f;
                    // 침묵
                }
                break;
            case Skill.Reset:
                {
                    if (hp[1] <= hp[0])
                        return apply;

                    GameObject go = Instantiate(UnitData.Inst.playerSkill[(int)skill]);

                    Vector3 vec = transform.position;
                    vec.z -= 0.1f;

                    go.transform.position = vec;

                    // 전체 회복
                    hp[0] = hp[1];
                    fillAmount.FillAmount(hp[0], hp[1]);
                    
                    // 버프, 너프 해제
                    Buff_Clear();
                }
                break;
            case Skill.Destory:
                {
                    GameObject go = Instantiate(UnitData.Inst.playerSkill[(int)skill]);

                    if (go.TryGetComponent(out Dead_Effect outDead))
                    {
                        outDead.Dead(sprites[(int)State.Dead], spriteRenderer.flipX);
                    }
                    
                    go.transform.position = transform.position;

                    circleCollider.enabled = false;

                    behavior = Behavior.Dead;
                    deadTimer[0] = deadTimer[1];
                    hp[0] = 0.0f;
                }
                break;
            case Skill.Null:
                break;
        }

        apply = true;

        return apply;
    }

    protected virtual void Buff_Check()
    {
        if (0.0f < skillTime)
        {
            skillTime -= Time.deltaTime;

            if (skillTime <= 0.0f)
            {
                skillTime = 0.0f;

                switch (skill)
                {
                    case Skill.Buff:
                    case Skill.Nerf:
                    case Skill.Silence:
                        {
                            damage = damageTemp;
                            defence = defenceTemp;

                            skill = Skill.Null;
                        }
                        break;
                }
            }
        }
    }    
    
    void Buff_Clear()
    {
        skillTime = 0.0f;

        damage = damageTemp;
        defence = defenceTemp;

        skill = Skill.Null;
    }

    public void Dead_Check()
    {
        if (0.0f < deadTimer[0])
        {
            deadTimer[0] -= Time.deltaTime;

            if (deadTimer[0] <= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    protected virtual void Random_Character(Team team)
    {
        if (team == Team.Null)
            return;

        int percentage = Random.Range(0, 100 + 1);

        int value = 0;

        if (60 < percentage)
        {
            value = Random.Range((int)Character.Normal_1, (int)Character.Null);
        }

        character = (Character)value;

        for (int i = 0; i < (int)State.Null; i++)
        {
            if (team == Team.Blue)
                sprites[i] = UnitData.Inst.blueSprites[(value * 4) + i];
            else
                sprites[i] = UnitData.Inst.redSprites[(value * 4) + i];
        }
    }

    public void Remove_Target(GameObject go) { targetList.Remove(go); }

    public bool Set_FilpX() { return spriteRenderer.flipX; }

    protected virtual void Setting_Ai()
    {
        Setting_AiLerp();
        Setting_AiPath();
    }

    protected virtual void Setting_AiLerp() { aiLerp = GetComponent<AILerp>(); }

    protected virtual void Setting_AiPath() { aiPath = GetComponent<AIPath>(); }

    protected virtual void Setting_Target()
    {
        if (targetList.Count <= 0)
            return;

        target = targetList[0];
        refTarget = target;
    }

    protected virtual void Target_Active_Check()
    {
        if (state == State.Dead)
            return;

        if (targetList.Count <= 0)
        {
            target = null;

            if (aiPath != null)
                aiPath.enabled = true;

            behavior = Behavior.Idle;
            return;
        }

        for (int i = 0; i < targetList.Count; i++)
        {
            if (targetList[i].TryGetComponent(out Status outStatus))
            {
                if (outStatus.Get_CurHp() <= 0.0f)
                {
                    targetList.Remove(targetList[i]);
                    continue;
                }
            }
        }
    }

    public void OnDamage(float value)
    {
        if (hp[0] <= 0.0f)
            return;

        hp[0] -= value;
        fillAmount.FillAmount(hp[0], hp[1]);

        if (hp[0] <= 0.0f)
        {
            if (aiPath != null)
                aiPath.enabled = false;

            GameObject go = Instantiate(UnitData.Inst.playerSkill[(int)Skill.Destory]);

            if (go.TryGetComponent(out Dead_Effect outDead))
            {
                outDead.Dead(sprites[(int)State.Dead], spriteRenderer.flipX);
            }

            go.transform.position = transform.position;

            circleCollider.enabled = false;

            state = State.Dead;
            behavior = Behavior.Dead;

            deadTimer[0] = deadTimer[1];
            hp[0] = 0.0f;
        }
    }

    public void OnHeal(float value)
    {
        if (hp[1] <= hp[0])
            return;

        hp[0] += value;
        fillAmount.FillAmount(hp[0], hp[1]);

        if (hp[1] <= hp[0])
        {
            hp[0] = hp[1];
        }
    }
}
