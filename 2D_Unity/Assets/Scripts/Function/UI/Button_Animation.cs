using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Animation : MonoBehaviour
{
    protected Image image;
    [SerializeField]
    protected Sprite[] sprites;

    protected int animIdx;
    protected float animTimer = 0.0f;

    protected void Anim_Check()
    {
        if (sprites.Length <= animIdx)
            animIdx = 0;

        image.sprite = sprites[animIdx];
        animIdx++;
    }

    protected void AnimDelay_Check()
    {
        if (0.0f < animTimer)
        {
            animTimer -= Time.deltaTime;

            if (animTimer <= 0.0f)
            {
                Anim_Check();
                animTimer = Random_Delay();
            }
        }
    }

    protected float Random_Delay(float min = 0.25f, float max = 0.5f)
    {
        return Random.Range(min, max);
    }
}
