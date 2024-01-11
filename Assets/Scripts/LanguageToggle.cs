using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class LanguageToggle : MonoBehaviour
{
    public static bool translation = false;

    [SerializeField]
    public UnityEngine.UI.Image SLOImage;
    [SerializeField]
    public UnityEngine.UI.Image ENGImage;



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
        if (translation)
        {
            SLOImage.enabled = true;
            ENGImage.enabled = false;
        }
        else
        {
            SLOImage.enabled = false;
            ENGImage.enabled = true;
        }
    }


}
