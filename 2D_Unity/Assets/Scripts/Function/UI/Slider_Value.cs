using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Value : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Text text;

    void Start()
    {
        if (slider == null)
            slider = GetComponent<Slider>();

        if (slider != null)
            slider.onValueChanged.AddListener((value) =>
            {
                text.text = ((int)(value * 100.0f)).ToString();
            });
    }

    public void SetSliderValue(float value)
    {
        if (slider == null)
            slider = GetComponent<Slider>();

        if (slider != null)
        {
            slider.value = value;
            text.text = ((int)(slider.value * 100.0f)).ToString();
        }
    }

    public float GetSliderValue()
    {
        return slider.value;
    }
}
