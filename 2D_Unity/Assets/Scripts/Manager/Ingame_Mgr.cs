using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingame_Mgr : MonoBehaviour
{
    [SerializeField]
    private Button configBtn;
    [SerializeField]
    private GameObject uiCanvas;

    [SerializeField] 
    private GameObject config;
    private GameObject configPenal;
    [SerializeField]
    private Click_Skill_Btn[] skillBtns;

    void Start()
    {
        if (configBtn != null)
            configBtn.onClick.AddListener(() =>
            {
                Time.timeScale = 0.0f;

                configPenal = Instantiate(config);
                configPenal.transform.SetParent(uiCanvas.transform, false);
            });

        for (int i = 0; i < skillBtns.Length; i++)
        {
            if (GlobalData.skill[i] == false)
                skillBtns[i].SetLock(true);
            else
                skillBtns[i].SetLock(false);
        }

        Sound_Mgr.instance.SoundBGM("BGM_2");
    }
}
