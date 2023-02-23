using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold_Check_Panel : MonoBehaviour
{
    [SerializeField]
    private Button button;

    void Start()
    {
        if (button != null)
            button.onClick.AddListener(() => 
            {
                Sound_Mgr.instance.SoundPlay("Button");

                Destroy(gameObject);
            });
    }
}
