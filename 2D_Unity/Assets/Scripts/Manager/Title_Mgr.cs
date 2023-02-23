using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Mgr : MonoBehaviour
{
    public static Title_Mgr instance;

    #region Group
    [SerializeField] 
    private GameObject uiCanvas;

    [SerializeField] 
    private GameObject config;
    private GameObject configPenal;
    #endregion

    #region Button
    [SerializeField] private Button startBtn;
    [SerializeField] private Button loadBtn;
    [SerializeField] private Button configBtn;
    [SerializeField] private Button exitBtn;
    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("UserGold"))
        {
            if (loadBtn != null)
                loadBtn.gameObject.SetActive(true);
        }
        else
        {
            if (loadBtn != null)
                loadBtn.gameObject.SetActive(false);
        }

        ButtonOnClickSetting();

        void ButtonOnClickSetting()
        {
            if (startBtn != null)
                startBtn.onClick.AddListener(() =>
                {
                    Sound_Mgr.instance.SoundPlay("Button");

                    GlobalData.ResetData();

                    SceneManager.LoadScene("Lobby");
                });

            if (configBtn != null)
                configBtn.onClick.AddListener(() =>
                {
                    Sound_Mgr.instance.SoundPlay("Button");

                    configPenal = Instantiate(config);
                    configPenal.transform.SetParent(uiCanvas.transform, false);
                });

            if (exitBtn != null)
                exitBtn.onClick.AddListener(() =>
                {
                    Sound_Mgr.instance.SoundPlay("Button");

                    Application.Quit();
                });

            if (loadBtn != null)
                loadBtn.onClick.AddListener(() =>
                {
                    Sound_Mgr.instance.SoundPlay("Button");

                    // 세이브 데이터
                    GlobalData.LoadData();

                    SceneManager.LoadScene("Lobby");
                });
        }

        Sound_Mgr.instance.SoundBGM("BGM_1");
    }

    public GameObject GetCanvas()
    {
        return uiCanvas;
    }
}
