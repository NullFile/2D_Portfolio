using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Base : Building, IDamageable
{
    private Image_FillAmount fillAmount;

    [SerializeField]
    private GameObject DestoryPenal;

    void Start()
    {
        Building_Status(BuildingType.Base);

        fillAmount = GetComponentInChildren<Image_FillAmount>();
    }

    void Update()
    {

    }

    public void OnDamage(float Dmg)
    {
        if (hp[0] <= 0.0f)
            return;

        hp[0] -= Dmg;
        fillAmount.FillAmount(hp[0], hp[1]);

        if (hp[0] <= 0.0f)
        {
            Sound_Mgr.instance.SoundBGM("Defeat");

            // 패배
            if (DestoryPenal.activeSelf == false)
                DestoryPenal.SetActive(true);

            // 일시 정지
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.0f;

            // 파괴
            hp[0] = 0.0f;
        }
    }
}
