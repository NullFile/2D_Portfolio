using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store_Character : Button_Animation
{
    // ≈ÿΩ∫∆Æ
    protected Coroutine[] refCoroutine = new Coroutine[2];

    [SerializeField]
    protected GameObject balloon;
    [SerializeField]
    protected Text balloonText;
    [SerializeField]
    protected string[] temp;

    protected Button characterBtn;

    [SerializeField]
    protected GameObject clickGroup;
    [SerializeField]
    protected Button[] clickBtn;

    protected bool isClick = false;
    protected float clickTimer = 0.0f;
    protected float clickDelay = 1.5f;

    protected int textIdx = 0;
    protected float textTimer = 0.05f;

    protected virtual void Start()
    {
        Start_Anim();
        Start_Button();
        Start_Text();
    }

    protected virtual void Update()
    {
        if (image != null && 0 < sprites.Length)
            AnimDelay_Check();

        ClickDelay_Check();
        Click_Check();
    }

    void ClickDelay_Check()
    {
        if (0.0f < clickTimer)
        {
            clickTimer -= Time.deltaTime;

            if (clickTimer <= 0.0f)
            {
                clickTimer = 0.0f;
            }
        }
    }

    void Click_Check()
    {
        if (isClick == true)
        {
            if (clickGroup.activeSelf == false)
            {
                clickGroup.SetActive(true);
            }
        }
        else
        {
            if (clickGroup.activeSelf == true)
            {
                clickGroup.SetActive(false);
            }
        }
    }

    void Start_Anim()
    {
        animIdx = 0;
        animTimer = Random_Delay();
        image = GetComponent<Image>();
    }

    protected virtual void Start_Button()
    {
        characterBtn = GetComponent<Button>();

        if (characterBtn != null)
            characterBtn.onClick.AddListener(() =>
            {
                isClick = !isClick;
                clickTimer = clickDelay;
            });
    }

    void Start_Text()
    {
        Typing_Text();
    }

    public void Typing_Text()
    {
        if (balloon.activeSelf == false)
            balloon.SetActive(true);

        if (refCoroutine[1] != null)
        {
            StopCoroutine(refCoroutine[1]);
            refCoroutine[1] = null;
        }

        if (refCoroutine[0] != null)
        {
            StopCoroutine(refCoroutine[0]);
            refCoroutine[0] = null;
        }

        refCoroutine[0] = StartCoroutine(Typing(balloonText, temp[textIdx], textTimer));
        refCoroutine[1] = StartCoroutine(ActiveCheck());

        textIdx++;

        if (temp.Length <= textIdx)
        {
            textIdx = 0;

            if (balloon.activeSelf == true)
                balloon.SetActive(false);
        }
    }

    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
    }

    IEnumerator ActiveCheck(float wfs = 1.5f)
    {
        if (balloon.activeSelf == false)
            balloon.SetActive(true);

        yield return new WaitForSeconds(wfs);

        AddTextIdx();

        if (balloon.activeSelf == true)
            balloon.SetActive(false);
    }

    void AddTextIdx()
    {
        textIdx++;

        if (temp.Length <= textIdx)
        {
            textIdx = 0;
        }
    }
}
