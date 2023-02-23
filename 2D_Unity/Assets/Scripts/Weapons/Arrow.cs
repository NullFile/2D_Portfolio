using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject attacker;
    GameObject target;

    [SerializeField]
    Rigidbody2D rigid2D;

    Vector3 targetVec;

    Vector3 vec;
    float dist;

    float damage;
    float speed;

    void FixedUpdate()
    {
        if (target != null)
        {
            if (target.TryGetComponent(out Status outStatus))
            {
                if (outStatus.Get_CurHp() <= 0.0f)
                {
                    Destroy(gameObject);
                }
            }

            vec = (target.transform.position - transform.position).normalized;

            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.position += (vec * speed * Time.deltaTime);
            rigid2D.MovePosition(rigid2D.position + (speed * Time.fixedDeltaTime * (Vector2)vec));
        }
        else
        {
            vec = (targetVec - transform.position).normalized;
            dist = (targetVec - transform.position).magnitude;

            if (dist < 0.01f)
                Destroy(gameObject);

            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.position += (vec * speed * Time.deltaTime);
            rigid2D.MovePosition(rigid2D.position + (speed * Time.fixedDeltaTime * (Vector2)vec));
        }
    }

    public void SetTarget(GameObject attack, GameObject go, float dmg)
    {
        if (attack == null)
            return;

        attacker = attack;
        target = go;
        damage = dmg;

        speed = Random.Range(2.5f, 3.5f);

        targetVec = target.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            bool b = collision.TryGetComponent(out IDamageable outDamageable);

            if (b == true)
            {
                Sound_Mgr.instance.SoundPlay("Atk Range Hit");

                outDamageable.OnDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
