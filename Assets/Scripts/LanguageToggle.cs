using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageToggle : MonoBehaviour
{
    public static bool translation = false;

    [SerializeField]
    public UnityEngine.UI.Image SLOImage;
    [SerializeField]
    public UnityEngine.UI.Image ENGImage;

    //Main menu
    [SerializeField]
    public TMPro.TextMeshProUGUI startText;
    [SerializeField]
    public TMPro.TextMeshProUGUI settingsText;
    [SerializeField]
    public TMPro.TextMeshProUGUI exitText;
    [SerializeField]
    public TMPro.TextMeshProUGUI backText;





    void Start()
    {
        toggleImages();
    }

    void OnDisable()
    {
        PlayerPrefs.SetString("translation", translation.ToString());
    }

    public void setSLO()
    {
        translation = true;
        toggleImages();
    }
    public void setENG()
    {
        translation = false;
        toggleImages();
    }


    private void toggleImages()
    {
        //SLO
        if (translation)
        {
            SLOImage.enabled = true;
            ENGImage.enabled = false;
        }//ENG
        else
        {
            SLOImage.enabled = false;
            ENGImage.enabled = true;
        }
        toggleMainMenuText();
    }

    private void toggleMainMenuText()
    {
        //SLO
        if (translation)
        {
            startText.text = "Start";
            settingsText.text = "Nastavitve";
            exitText.text = "Izhod";
            backText.text = "Nazaj";
        }//ENG
        else
        {
            startText.text = "Start";
            settingsText.text = "Settings";
            exitText.text = "Exit";
            backText.text = "Back";
        }
    }


}
