using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Base : Building, IDamageable
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
            Sound_Mgr.instance.SoundBGM("Victory");

            // ?¸?
            if (DestoryPenal.activeSelf == false)
                DestoryPenal.SetActive(true);

            // ?ӽ? ó?? : ?¸??ϰ? ?Ǹ? 200 ???带 ȹ??
            GlobalData.UserGold += 200;

            GlobalData.SaveData();

            // ?Ͻ? ????
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.0f;

            // ?ı?
            hp[0] = 0.0f;
        }
    }
}
