using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tower : Building, IDamageable
{
    [SerializeField]
    private Transform attackPos;
    [SerializeField]
    private GameObject linePrefab;
    [SerializeField]
    private GameObject attackPrefab;

    //[SerializeField]
    //private LayerMask checkLayer;

    private List<GameObject> targetList = new List<GameObject>();
    [HideInInspector]
    public GameObject target;
    private GameObject refTarget;

    private GameObject line;

    private Image_FillAmount fillAmount;

    [SerializeField]
    private GameObject DestroyPrefab;

    //private bool inside;

    //private Collider2D[] checks = new Collider2D[32];
    //private Vector3 originPos;

    void Start()
    {
        line = Instantiate(linePrefab);
        line.transform.SetParent(gameObject.transform);

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        Building_Status(BuildingType.Tower);

        fillAmount = GetComponentInChildren<Image_FillAmount>();

        //trackingDist = 3.0f;
        //attackDist = 3.0f;
        attackTimer[1] = 1.5f;

        GetAnim(team);
    }

    void GetAnim(Team team)
    {
        switch (team)
        {
            case Team.Blue:
                {
                    sprites = new Sprite[UnitData.Inst.blueTowerSprites.Length];

                    for (int i = 0; i < UnitData.Inst.blueTowerSprites.Length; i++)
                    {
                        sprites[i] = UnitData.Inst.blueTowerSprites[i];
                    }
                }
                break;
            case Team.Red:
                {
                    sprites = new Sprite[UnitData.Inst.redTowerSprites.Length];

                    for (int i = 0; i < UnitData.Inst.redTowerSprites.Length; i++)
                    {
                        sprites[i] = UnitData.Inst.redTowerSprites[i];
                    }
                }
                break;
        }
    }

    void Update()
    {
        if (hp[0] <= 0.0f)
        {
            if (line != null)
                Destroy(line);

            return;
        }

        Target_Active_Check();
        Setting_Target();
        Draw_Attack_Line();
        Attack_Delay_Check();

        //Debug.Log(target);

        //if (target == null)
        //{
        //    originPos = transform.position;
        //    originPos.z = 0.0f;

        //    if (0 < Physics2D.OverlapCircleNonAlloc(originPos, trackingDist, checks, checkLayer))
        //    {
        //        if (target == null)
        //        {
        //            target = checks[0].gameObject;
        //            attackTimer = attackDelay;
        //        }
        //    }
        //}
        //else
        //{
        //    if (trackingDist < (target.transform.position - transform.position).magnitude)
        //    {
        //        target = null;
        //    }
        //}

        //if (target != null)
        //{
        //    if (line != null)
        //    {
        //        line.GetComponent<LineRenderer>().SetPosition(0, (Vector2)attackPos.position);
        //        line.GetComponent<LineRenderer>().SetPosition(1, (Vector2)target.transform.position);
        //    }
        //}
        //else
        //{
        //    if (target != null)
        //        target = null;

        //    if (line != null && line.activeSelf == true)
        //        line.SetActive(false);
        //    //Destroy(line);
        //}
    }

    void Target_Active_Check()
    {
        if (targetList.Count <= 0)
        {
            target = null;
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

            //if (targetList[i] == null || targetList[i].activeSelf == false)
            //    targetList.Remove(targetList[i]);
        }
    }

    void Setting_Target()
    {
        if (targetList.Count <= 0)
            return;

        target = targetList[0];
        refTarget = target;
    }

    void Draw_Attack_Line()
    {
        if (line == null || refTarget == null)
            return;

        if (refTarget.TryGetComponent(out Status outStatus))
        {
            if (outStatus.Get_CurHp() <= 0.0f)
            {
                refTarget = null;
                return;
            }
        }

        if (line != null && line.activeSelf == false)
            line.SetActive(true);

        line.GetComponent<LineRenderer>().SetPosition(0, (Vector2)attackPos.position);
        line.GetComponent<LineRenderer>().SetPosition(1, (Vector2)refTarget.transform.position);
    }

    void Attack_Delay_Check()
    {
        if (0 < attackTimer[0])
        {
            attackTimer[0] -= Time.deltaTime;

            if (attackTimer[0] <= 0.0f)
            {
                if (refTarget != null)
                {
                    Sound_Mgr.instance.SoundPlay("Atk Magic");

                    GameObject go = Instantiate(attackPrefab);
                    go.tag = gameObject.tag;
                    //go.layer = gameObject.layer;

                    bool b = go.TryGetComponent(out Bullet outBullet);

                    if (b == true)
                    {
                        if (line != null && line.activeSelf == true)
                            line.SetActive(false);

                        outBullet.SetTarget(gameObject, refTarget);
                        refTarget = null;

                        //if (line != null && line.activeSelf == true)
                        //    line.SetActive(false);
                    }
                    
                    go.transform.position = attackPos.position;

                    attackTimer[0] = attackTimer[1];
                }
                else
                {
                    attackTimer[0] = 0.0f;
                }

                if (line != null && line.activeSelf == true)
                    line.SetActive(false);

                //GameObject go = Instantiate(attackPrefab);
                //go.tag = gameObject.tag;
                //go.layer = gameObject.layer;

                //bool b = go.TryGetComponent(out Bullet outBullet);

                //if (b == true)
                //{
                //    if (line != null && line.activeSelf == true)
                //        line.SetActive(false);

                //    if (refTarget != null)
                //    {
                //        //if (line != null && line.activeSelf == true)
                //        //    line.SetActive(false);

                //        outBullet.SetTarget(refTarget);
                //        refTarget = null;
                //    }
                //    else
                //    {
                //        //if (line != null && line.activeSelf == true)
                //        //    line.SetActive(false);
                //    }

                //    // 거리 값 내에 있으면 계속 공격
                //    //if (inside == false)
                //    //{
                //        //if (target != null)
                //        //    target = null;

                //        //if (line != null && line.activeSelf == true)
                //        //    line.SetActive(false);
                //        //Destroy(line);
                //    //}
                //}

                //go.transform.position = attackPos.position;

                ////if (target != null)
                ////    attackTimer = attackDelay;
                ////else
                ////    attackTimer = 0.0f;
            }
            else
            {
                if (refTarget == null)
                {
                    if (line != null && line.activeSelf == true)
                        line.SetActive(false);
                }
            }
        }
    }

    //public void SetTarget(GameObject go, bool isBool)
    //{
    //    target = go;
    //    inside = isBool;

    //    if (inside == true)
    //    {
    //        if (line != null && line.activeSelf == false)
    //            line.SetActive(true);

    //        attackTimer = attackDelay;
    //    }
    //}

    public void Add_Target(GameObject go)
    {
        targetList.Add(go);

        if (attackTimer[0] <= 0.0f)
            attackTimer[0] = attackTimer[1];
    }

    public void OnDamage(float Dmg)
    {
        if (hp[0] <= 0.0f)
            return;

        hp[0] -= Dmg;
        fillAmount.FillAmount(hp[0], hp[1]);

        if (hp[0] <= 0.0f)
        {
            GameObject go = Instantiate(DestroyPrefab);

            Vector3 vec = transform.position;
            vec.y -= 0.5f; 

            go.transform.position = vec;

            if (go.TryGetComponent(out ParticleSystem ps))
                ps.Play();

            spriteRenderer.sprite = sprites[2];
            // 파괴
            hp[0] = 0.0f;
        }
    }

    public void Remove_Target(GameObject go)
    {
        targetList.Remove(go);
    }

    //private void OnDrawGizmos()
    //{
    //    Handles.color = Color.red;
    //    originPos.z = 0.0f;
    //    Handles.DrawWireDisc(originPos, transform.forward, trackingDist);
    //}
}
