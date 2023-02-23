using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Effect : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private float curTimer = 0.0f;
    [SerializeField]
    private float endTimer = 0.0f;

    void Start()
    {
        curTimer = 0.0f;
    }

    void Update()
    {
        if (curTimer < endTimer)
        {
            curTimer += Time.deltaTime;

            if (endTimer <= curTimer)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Dead(Sprite sprite, bool value)
    {
        spriteRenderer.sprite = sprite;
        spriteRenderer.flipX = value;
    }
}
