using UnityEngine;
using UnityEngine.UI;

public class Image_FillAmount : MonoBehaviour
{
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public bool GetActive()
    {
        return image.gameObject.activeSelf;
    }

    public void SetActive(bool b)
    {
        image.gameObject.SetActive(b);
    }

    public void FillAmount(float cur, float max)
    {
        image.fillAmount = cur / max;
    }

    public void SetFillAmount(float value)
    {
        image.fillAmount = value;
    }
}
