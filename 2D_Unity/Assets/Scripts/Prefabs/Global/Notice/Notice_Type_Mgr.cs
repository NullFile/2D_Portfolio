using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eNoticeType
{
    Notice,
    Warning,
    Error,
}

public class Notice_Type_Mgr : MonoBehaviour
{
    private eNoticeType noticeType;

    private GameObject[] noticeImages = new GameObject[3];

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Setting();

        void Setting()
        {
            for (int i = 0; i < noticeImages.Length; i++)
            {
                noticeImages[i] = transform.GetChild(i).gameObject;
            }
        }
    }

    public void SetNoticeType(eNoticeType type)
    {
        noticeType = type;

        for (int i = 0; i < noticeImages.Length; i++)
        {
            noticeImages[i].SetActive(false);
        }

        noticeImages[(int)noticeType].SetActive(true);
    }
}
