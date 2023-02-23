using UnityEngine;
using UnityEngine.UI;

public class Click_Unit_Btn : MonoBehaviour
{
    private Cost_Mgr costMgr;
    private Camera cam;

    [SerializeField]
    private GameObject node;
    [SerializeField]
    private Weapon weapon;
    private Image_FillAmount fillAmount;
    private Text costText;

    //private string timeStr = "\n<color=#FF0000>Cooldown is in Progress.</color>";
    //private string costStr = "\n<color=#FF0000>Cost is insufficient.</color>";

    [SerializeField]
    private Image noticeImg;
    private Text noticeText;

    private Vector3[] v = new Vector3[4];
    private Vector3 mousePos;

    private bool isPick = false;

    [SerializeField]
    private int cost;

    private float check = 0.0f;
    [SerializeField] 
    private float delay = 5.0f;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        costMgr = FindObjectOfType<Cost_Mgr>();

        fillAmount = GetComponentInChildren<Image_FillAmount>();
        costText = GetComponentInChildren<Text>();

        if (costText != null)
            costText.text = cost.ToString();

        GetComponent<RectTransform>().GetWorldCorners(v);

        if (noticeImg != null)
            noticeText = noticeImg.GetComponentInChildren<Text>();

        if (noticeText != null)
            noticeText.text = weapon.ToString();
    }

    void Update()
    {
        TextChange();
        DelayCheck();
    }

    void TextChange()
    {
        if (Inside() == true)
        {
            if (noticeImg.gameObject.activeSelf == false)
                noticeImg.gameObject.SetActive(true);
        }
        else
        {
            if (noticeImg.gameObject.activeSelf == true)
                noticeImg.gameObject.SetActive(false);
        }
    }

    void DelayCheck()
    {
        if (0.0f < check)
        {
            check -= Time.deltaTime;

            if (fillAmount != null)
                fillAmount.FillAmount(check, delay);

            if (check <= 0.0f)
                check = 0.0f;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPick = Inside();

                if (isPick == true)
                {
                    if (cost <= (int)costMgr.GetCost())
                        Create();
                }
            }
        }
    }

    bool Inside()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (v[0].x + cam.transform.position.x <= mousePos.x && 
            mousePos.x <= v[2].x + cam.transform.position.x &&
            v[0].y + cam.transform.position.y <= mousePos.y && 
            mousePos.y <= v[2].y + cam.transform.position.y)
        {
            return true;
        }

        return false;
    }

    void Create()
    {
        GameObject go = Instantiate(node);

        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0.0f;

        bool b = go.TryGetComponent(out Create_Node outNode);

        if (b == true)
        {
            outNode.unitBtn = this;
            outNode.weapon = weapon;
            outNode.cost = cost;
        }

        go.transform.position = vec;
    }

    public void Delay()
    {
        check = delay;
    }
}
