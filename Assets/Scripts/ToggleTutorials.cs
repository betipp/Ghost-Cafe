using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTutorials : MonoBehaviour
{
    private bool isTutorialEnabled;
    public void setTutorial(bool status)
    {
        isTutorialEnabled = status;
        PlayerPrefs.SetString("isTutorialEnabled", isTutorialEnabled.ToString());
    }


    void OnDisable()
    {
        PlayerPrefs.SetString("isTutorialEnabled", isTutorialEnabled.ToString());
    }

}
