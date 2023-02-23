using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Config_Fullscreen_Mgr : MonoBehaviour
{
    private Toggle toggle;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Setting();

        void Setting()
        {
            if (toggle == null)
                toggle = GetComponentInChildren<Toggle>();
        }

        Refresh();

        void Refresh()
        {
            if (toggle != null)
                toggle.isOn = GlobalData.FullScreen;
        }
    }

    //private void Update() => UpdateFunc();

    //private void UpdateFunc()
    //{
    //}

    public void ApplyFullscreen()
    {
        GlobalData.FullScreen = toggle.isOn;
    }
}
