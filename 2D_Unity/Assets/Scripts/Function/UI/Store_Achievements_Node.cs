using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store_Achievements_Node : MonoBehaviour
{
    private string achievementsName;
    private string achievementsExplanation;
    bool isClear;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Text nameText;    
    [SerializeField]
    private Text explanationText;
    [SerializeField]
    private GameObject checker;

    void Start()
    {

    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        
    }

    public void Data_Init(string name, string explanation)
    {
        achievementsName = name;
        achievementsExplanation = explanation;

        nameText.text = achievementsName;
        explanationText.text = achievementsExplanation;
    }
}
