using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack_Mgr : MonoBehaviour
{
    //RaycastHit2D hit2D;

    //[SerializeField]
    //private LayerMask checkLayer;
    //[SerializeField]
    //private Camera mainCamera;

    ////private float attackTimer = 0.0f;
    ////private float attackDelay = 2.0f;
    //private Vector3 pos = Vector3.zero;

    void Start()
    {
         
    }

    void Update()
    {
        DelayCheck();
        ClickEnemy();
    }

    void DelayCheck()
    {
        //if (0 < attackTimer)
        //{
        //    attackTimer -= Time.deltaTime;

        //    if (attackTimer <= 0.0f)
        //    {
        //        attackTimer = 0.0f;
        //    }
        //}
    }

    void ClickEnemy()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        //    if (hit2D = Physics2D.Raycast(pos, Vector3.forward, Mathf.Infinity, checkLayer))
        //    {
        //        if (hit2D.collider.name.Contains("Tower"))
        //            return;

        //        Debug.Log("Àû Ã¼Å©");
        //    }
        //}
    }
}
