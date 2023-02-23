using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby_Mgr : MonoBehaviour
{
    [SerializeField]
    private Button titleBtn;    
    [SerializeField]
    private Button storeBtn;    
    [SerializeField]
    private Button ingameBtn;    
    [SerializeField]
    private Button resetBtn;

    [SerializeField]
    private GameObject reset_Penal;

    void Start()
    {
        if (Time.timeScale == 0.0f)
        {
            //Debug.Log(Time.timeScale);
            Time.timeScale = 1.0f;
        }

        if (titleBtn != null)
            titleBtn.onClick.AddListener(() =>
            {
                Achievements_Ctrl ctrl = FindObjectOfType<Achievements_Ctrl>();

                if (ctrl != null)
                    Destroy(ctrl.gameObject);

                Sound_Mgr.instance.SoundPlay("Button");

                SceneManager.LoadScene("Title");
            });        
        
        if (storeBtn != null)
            storeBtn.onClick.AddListener(() =>
            {
                Sound_Mgr.instance.SoundPlay("Button");

                SceneManager.LoadScene("Store");
            });        
        
        if (ingameBtn != null)
            ingameBtn.onClick.AddListener(() =>
            {
                Sound_Mgr.instance.SoundPlay("Button");

                SceneManager.LoadScene("Ingame");
            });

        if (resetBtn != null)
            resetBtn.onClick.AddListener(() =>
            {
                Sound_Mgr.instance.SoundPlay("Button");

                GlobalData.ResetData();

                reset_Penal.SetActive(true);
            });

        Sound_Mgr.instance.SoundBGM("BGM_1");
    }
}
