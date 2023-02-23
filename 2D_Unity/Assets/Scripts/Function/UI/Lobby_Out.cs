using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby_Out : MonoBehaviour
{
    private Button lobby_Btn;

    void Start()
    {
        lobby_Btn = GetComponentInChildren<Button>();

        if (lobby_Btn != null)
            lobby_Btn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Lobby");
            });
    }
}
