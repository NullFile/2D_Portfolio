using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Config_Mgr : MonoBehaviour
{
    private Config_Sound_Mgr sound;
    private Config_Fullscreen_Mgr fullscreen;
    private Config_Ratio_Mgr ratio;

    private Transform configButtonGroup;

    private Button applyBtn;
    private Button cancelBtn;

    private void OnEnable()
    {
        Setting();

        void Setting()
        {
            if (sound == null)
                sound = transform.Find("Sound_Text").GetComponent<Config_Sound_Mgr>();
            if (fullscreen == null)
                fullscreen = transform.Find("Fullscreen_Text").GetComponent<Config_Fullscreen_Mgr>();
            if (ratio == null)
                ratio = transform.Find("Ratio_Text").GetComponent<Config_Ratio_Mgr>();

            if (configButtonGroup == null)
                configButtonGroup = transform.Find("Config_Button_Group");

            if (configButtonGroup != null)
            {
                if (applyBtn == null)
                    applyBtn = configButtonGroup.Find("ConfigApply_Btn").GetComponent<Button>();
                if (cancelBtn == null)
                    cancelBtn = configButtonGroup.Find("ConfigCancel_Btn").GetComponent<Button>();
            }
        }
    }

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Setting();

        void Setting()
        {
            sound = transform.Find("Sound_Text").GetComponent<Config_Sound_Mgr>();
            fullscreen = transform.Find("Fullscreen_Text").GetComponent<Config_Fullscreen_Mgr>();
            ratio = transform.Find("Ratio_Text").GetComponent<Config_Ratio_Mgr>();

            configButtonGroup = transform.Find("Config_Button_Group");

            applyBtn = configButtonGroup.Find("ConfigApply_Btn").GetComponent<Button>();
            cancelBtn = configButtonGroup.Find("ConfigCancel_Btn").GetComponent<Button>();
        }

        ButtonOnClickSetting();

        void ButtonOnClickSetting()
        {
            if (applyBtn != null)
                applyBtn.onClick.AddListener(() =>
                {
                    Sound_Mgr.instance.SoundPlay("Button");

                    sound.ApplySound();
                    fullscreen.ApplyFullscreen();
                    ratio.ApplyRatio();
                });           
            
            if (cancelBtn != null)
                cancelBtn.onClick.AddListener(() =>
                {
                    if (Time.timeScale == 0.0f)
                        Time.timeScale = 1.0f;

                    Sound_Mgr.instance.SoundPlay("Button");

                    Destroy(gameObject);
                });
        }
    }

    //private void Update() => UpdateFunc();

    //private void UpdateFunc()
    //{

    //}
}
