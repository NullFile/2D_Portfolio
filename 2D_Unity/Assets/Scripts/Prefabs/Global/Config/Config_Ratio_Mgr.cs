using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Config_Ratio_Mgr : MonoBehaviour
{
    private Dropdown dropdown;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Setting();

        void Setting()
        {
            if (dropdown == null)
                dropdown = GetComponentInChildren<Dropdown>();
        }

        Refresh();

        void Refresh()
        {
            if (dropdown != null)
                dropdown.value = (int)GlobalData.ScreenRatio;
        }
    }

    //private void Update() => UpdateFunc();

    //private void UpdateFunc()
    //{
    //}

    public void ApplyRatio()
    {
        GlobalData.ScreenRatio = (GlobalData.ScreenRatioType)dropdown.value;
    }
}
