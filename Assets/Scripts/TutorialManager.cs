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
