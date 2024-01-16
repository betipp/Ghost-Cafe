using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    public UnityEngine.UI.Image ShakeTutorialImage;
    [SerializeField]
    public UnityEngine.UI.Image CoffeeTutorialImage;
    [SerializeField]
    public UnityEngine.UI.Image JuiceTutorialImage;

    private bool isTutorialEnabled;

    void Awake()
    {

        isTutorialEnabled = PlayerPrefs.GetString("isTutorialEnabled") == "True";
        if (!isTutorialEnabled)
        {
            ShakeTutorialImage.enabled = false;
            CoffeeTutorialImage.enabled = false;
            JuiceTutorialImage.enabled = false;
        }
        else if (isTutorialEnabled)
        {
            ShakeTutorialImage.enabled = true;
            CoffeeTutorialImage.enabled = true;
            JuiceTutorialImage.enabled = true;
        }

    }


    public void hideTutorialImage(String juiceName)
    {
        switch (juiceName)
        {
            case "Chocolate":
                ShakeTutorialImage.enabled = false;
                break;
            case "Strawberry":
                ShakeTutorialImage.enabled = false;
                break;
            case "Coffee":
                CoffeeTutorialImage.enabled = false;
                break;
            case "Juice":
                JuiceTutorialImage.enabled = false;
                break;
        }

    }

}
