using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Mgr : MonoBehaviour
{
    [SerializeField]
    protected Transform parent;

    [SerializeField]
    protected Transform[] respawnPos;

    [SerializeField]
    protected GameObject[] prefabs;

    protected int formation = 0;

    protected float check = 0.0f;
    protected float delay = 0.0f;

    protected virtual void Create() { }
}