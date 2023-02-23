using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject attacker;
    GameObject target;

    Vector3 targetVec;

    Vector3 vec;
    float dist;

    float attack = 100.0f;
    float speed = 5.0f;

    void Update()
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
            transform.position += (vec * speed * Time.deltaTime);
        }
        else
        {
            vec = (targetVec - transform.position).normalized;
            dist = (targetVec - transform.position).magnitude;

            if (dist < 0.01f)
                Destroy(gameObject);

            transform.position += (vec * speed * Time.deltaTime);
        }
    }

    public void SetTarget(GameObject attack, GameObject go)
    {
        if (attack == null)
            return;

        attacker = attack;
        target = go;
        targetVec = target.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            bool b = collision.TryGetComponent(out IDamageable outDamageable);

            if (b == true)
            {
                outDamageable.OnDamage(attack);
            }

            Destroy(gameObject);
        }
    }
}
