using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Red_Mgr : Create_Mgr
{
    void Start()
    {
        delay = 3.0f;
    }

    void Update()
    {
        if (check <= delay)
        {
            check += Time.deltaTime;

            if (delay < check)
            {
                Create();
                check = 0.0f;
            }
        }
    }

    protected override void Create()
    {
        int r = Random.Range(0, prefabs.Length);

        for (int i = 0; i < respawnPos.Length; i++)
        {
            GameObject go = Instantiate(prefabs[r]);
            go.transform.SetParent(parent);
            go.transform.position = respawnPos[i].position;
        }
    }
}
