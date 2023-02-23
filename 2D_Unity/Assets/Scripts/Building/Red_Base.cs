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

            // ½Â¸®
            if (DestoryPenal.activeSelf == false)
                DestoryPenal.SetActive(true);

            // ÀÓ½Ã Ã³¸® : ½Â¸®ÇÏ°Ô µÇ¸é 200 °ñµå¸¦ È¹µæ
            GlobalData.UserGold += 200;

            GlobalData.SaveData();

            // ÀÏ½Ã Á¤Áö
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.0f;

            // ÆÄ±«
            hp[0] = 0.0f;
        }
    }
}
