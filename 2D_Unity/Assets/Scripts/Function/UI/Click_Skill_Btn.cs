using UnityEngine;
using UnityEngine.UI;

public class Click_Skill_Btn : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private GameObject node;
    [SerializeField]
    private Skill skill;
    private Image_FillAmount fillAmount;

    [SerializeField]
    private Image noticeImg;
    private Text noticeText;

    private Vector3[] v = new Vector3[4];
    private Vector3 mousePos;

    private bool isPick = false;

    private float check = 0.0f;
    [SerializeField]
    private float delay = 5.0f;

    private bool isLock = false;
    [SerializeField]
    private GameObject skillLock;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        fillAmount = GetComponentInChildren<Image_FillAmount>();

        //isLock = false;

        //skillLock.SetActive(isLock);

        GetComponent<RectTransform>().GetWorldCorners(v);

        if (noticeImg != null)
            noticeText = noticeImg.GetComponentInChildren<Text>();

        if (noticeText != null)
            noticeText.text = skill.ToString();
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
                fillAmount.FillAmount(delay - check, delay);

            if (check <= 0.0f)
            {
                check = 0.0f; 
                
                if (fillAmount != null)
                    fillAmount.SetFillAmount(check);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPick = Inside();

                if (isPick == true)
                    Create();
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
        if (isLock == true)
            return;

        GameObject go = Instantiate(node);

        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0.0f;

        bool b = go.TryGetComponent(out Create_Skill outSkill);

        if (b == true)
        {
            outSkill.skillBtn = this;
            outSkill.skill = skill;
        }

        go.transform.position = vec;
    }

    public void Delay()
    {
        check = delay;
    }

    public void SetLock(bool b)
    {
        isLock = b;

        if (skillLock != null)
            skillLock.SetActive(isLock);
    }
}
