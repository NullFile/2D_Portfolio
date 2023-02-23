using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    Base,
    Tower,
}

public class Building : Status
{
    [SerializeField]
    protected Team team;
    [SerializeField]
    protected BuildingType bType;

    protected SpriteRenderer spriteRenderer;
    protected Sprite[] sprites = new Sprite[3];
}
