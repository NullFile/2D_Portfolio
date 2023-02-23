using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_OnOff_Image : MonoBehaviour
{
    private Toggle toggle;

    [SerializeField]
    private Image on_Image;
    [SerializeField]
    private Image off_Image;

    void Start()
    {
        if (toggle == null)
            toggle = GetComponent<Toggle>();

        if (toggle != null)
        {
            OnOff_Check(toggle.isOn);

            toggle.onValueChanged.AddListener((isTrue) =>
            {
                if (isTrue)
                {
                    OnOff_Check(true);
                }
                else
                {
                    OnOff_Check(false);
                }
            });
        }
    }

    void OnOff_Check(bool check)
    {
        on_Image.gameObject.SetActive(check);
        off_Image.gameObject.SetActive(!check);
    }

    public void SetToggleValue(bool check)
    {
        if (toggle == null)
            toggle = GetComponent<Toggle>();

        if (toggle != null)
        {
            toggle.isOn = check;
            OnOff_Check(toggle.isOn);
        }
    }
    
    public bool GetToggleValue()
    {
        return toggle.isOn;
    }
}
