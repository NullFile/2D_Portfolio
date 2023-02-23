using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Notice_Mgr : MonoBehaviour
{
    [SerializeField] private Button applyBtn;
    [SerializeField] private Button cancelBtn;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        ButtonOnClickSetting();

        void ButtonOnClickSetting()
        {
            if (applyBtn != null)
                applyBtn.onClick.AddListener(() =>
                {
                    // 데이터 초기화
                    Sound_Mgr.instance.SoundPlay("Button");

                    gameObject.SetActive(false);

                    SceneManager.LoadScene("Title");
                });           
            
            if (cancelBtn != null)
                cancelBtn.onClick.AddListener(() =>
                {
                    Sound_Mgr.instance.SoundPlay("Button");

                    gameObject.SetActive(false);
                });
        }
    }
}
