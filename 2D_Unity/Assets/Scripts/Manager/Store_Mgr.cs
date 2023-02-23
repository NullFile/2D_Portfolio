using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store_Mgr : MonoBehaviour
{
    public static Store_Mgr Inst = null;

    [SerializeField]
    private Button lobbyBack_Btn;

    [SerializeField]
    private Button ludo_Btn;

    [SerializeField]
    private GameObject buyPanel;    
    
    [SerializeField]
    private GameObject achievementsPanel;

    [SerializeField]
    private Button buyPanelBack_Btn;

    [SerializeField]
    private Text gold_Text;

    private int gold;

    void Awake()
    {
        Inst = this;
    }

    void Start()
    {
        if (lobbyBack_Btn != null)
            lobbyBack_Btn.onClick.AddListener(() => 
            {
                Sound_Mgr.instance.SoundPlay("Button");

                SceneManager.LoadScene("Lobby");
            });        

        if (buyPanelBack_Btn != null)
            buyPanelBack_Btn.onClick.AddListener(() =>
            {
                Sound_Mgr.instance.SoundPlay("Button");

                if (buyPanel != null)
                {
                    buyPanel.SetActive(false);
                }
            });        

        gold = GlobalData.UserGold;

        GoldRefresh();
    }

    void Update()
    {
        
    }

    public void GoldRefresh()
    {
        if (gold_Text != null)
            gold_Text.text = gold.ToString();
    }

    public int GetGold() { return gold; }
    public void SetGold(int value) { gold = value; }
}
