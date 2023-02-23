using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements_Ctrl : MonoBehaviour
{
    void Awake()
    {
        var objs = FindObjectsOfType<Achievements_Ctrl>();

        if (objs.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }


}
