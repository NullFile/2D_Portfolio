using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config_Sound_Mgr : MonoBehaviour
{
    private Slider_Value slider;
    private Toggle_OnOff_Image toggle;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Setting();

        void Setting()
        {
            if (slider == null)
                slider = GetComponentInChildren<Slider_Value>();

            if (toggle == null)
                toggle = GetComponentInChildren<Toggle_OnOff_Image>();
        }

        Refresh();

        void Refresh()
        {
            if (slider != null)
                slider.SetSliderValue(GlobalData.MainSound);

            if (toggle != null)
                toggle.SetToggleValue(GlobalData.SoundCheck);
        }
    }

    //private void Update() => UpdateFunc();

    //private void UpdateFunc()
    //{
    //}

    public void ApplySound()
    {
        GlobalData.MainSound = slider.GetSliderValue();
        GlobalData.SoundCheck = toggle.GetToggleValue();

        Sound_Mgr.instance.MuteVolumeCheck();
    }
}
