using UnityEngine;
using UnityEngine.UI;

public class Cost_Mgr : MonoBehaviour
{
    [SerializeField]
    private Image_FillAmount image;
    [SerializeField]
    private Text text;
    private float curCost = 0.0f;
    private float maxCost = 10.0f;

    private float animCost = 1.0f;

    void Start()
    {
         
    }

    void Update()
    {
        if (curCost < maxCost)
        {
            curCost += Time.deltaTime;

            if (text != null)
                text.text = ((int)curCost).ToString();

            if (image != null)
                image.FillAmount((curCost % animCost), animCost);

            if (maxCost <= curCost)
            {
                if (image.GetActive() == true)
                    image.SetActive(false);

                curCost = maxCost;
            }
            else
            {
                if (image.GetActive() == false)
                    image.SetActive(true);
            }
        }
    }

    public float GetCost()
    {
        return curCost;
    }

    public bool UseCost(int cost)
    {
        if (curCost <= 0.0f)
            return false;

        if (curCost < cost)
            return false;

        curCost -= cost;
        text.text = ((int)curCost).ToString();

        return true;
    }
}
