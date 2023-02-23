using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField]
    private Unit unit;
    [SerializeField]
    private Tower tower;
    [SerializeField]
    private Team team;

    void Start()
    {
        if (unit == null)
            unit = GetComponentInParent<Unit>();

        if (tower == null)
            tower = GetComponentInParent<Tower>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(team.ToString()))
        {
            if (unit != null)
            {
                if (collision.name.Contains("Bullet"))
                    return;

                if (collision.name.Contains("Arrow"))
                    return;

                unit.Add_Target(collision.gameObject);
            }

            if (tower != null)
            {
                tower.Add_Target(collision.gameObject);
            }

            Base_Check_Enter(collision);
            //if (tower != null)
            //{
            //    if (tower.target == null)
            //    {
            //        tower.SetTarget(collision.gameObject, true);
            //    }
            //}
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag(team.ToString()))
    //    {
    //        if (tower != null)
    //        {
    //            if (tower.target == null)
    //            {
    //                tower.SetTarget(collision.gameObject, true);
    //            }
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(team.ToString()))
        {
            if (unit != null)
            {
                unit.Remove_Target(collision.gameObject);
            }

            if (tower != null)
            {
                tower.Remove_Target(collision.gameObject);
            }

            //Base_Check_Exit(collision);

            //if (tower != null)
            //{
            //    tower.SetTarget(collision.gameObject, false);
            //}
        }
    }

    void Base_Check_Enter(Collider2D collision)
    {
        if (unit == null)
            return;

        switch (team)
        {
            case Team.Blue:
                {
                    if (collision.TryGetComponent(out Red_Base outBase))
                    {
                        unit.Add_Target(outBase.gameObject);
                    }
                }
                break;
            case Team.Red:
                {
                    if (collision.TryGetComponent(out Blue_Base outBase))
                    {
                        unit.Add_Target(outBase.gameObject);
                    }
                }
                break;
        }
    }

    //void Base_Check_Exit(Collider2D collision)
    //{
    //    if (unit == null)
    //        return;

    //    switch (team)
    //    {
    //        case Team.Blue:
    //            {

    //            }
    //            break;
    //        case Team.Red:
    //            {

    //            }
    //            break;
    //    }
    //}
}
